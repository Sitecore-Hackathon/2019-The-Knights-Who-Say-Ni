using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Xml.Linq;
using Sitecore;
using Sitecore.Configuration;
using Sitecore.Diagnostics;

namespace Knights.Feature.KeywordFieldHelper.Services
{
    public class GoogleKeywordSuggestionsProvider : IKeywordSuggestionsProvider
    {
        #region Implementation of IKeywordSuggestionsProvider

        public virtual IEnumerable<string> GetSuggestions([NotNull] string keyword)
        {
            var suggestions = new List<string>();
            try
            {
                var url = GetRequestUrl(keyword);
                using (var client = new WebClient {Encoding = Encoding.UTF8})
                {
                    var xmlString = client.DownloadString(url);

                    if (string.IsNullOrWhiteSpace(xmlString))
                    {
                        Log.Error($"Cannot get suggestions for {keyword}.", this);
                        return suggestions;
                    }

                    var xml = XDocument.Parse(xmlString);

                    var topLevelElement = xml.Element(TOP_LEVEL_ELEMENT);
                    if (topLevelElement != null)
                    {
                        var completeSuggestionsElements = topLevelElement.Elements(COMPLETE_SUGGESTION_ELEMENT);
                        foreach (var completeSuggestionsElement in completeSuggestionsElements)
                        {
                            var suggestion = completeSuggestionsElement.Element(SUGGESTION_ELEMENT)
                                ?.Attribute(DATA_ATTRIBUTE)?.Value;
                            if (!string.IsNullOrWhiteSpace(suggestion)) suggestions.Add(suggestion);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Log.Error($"Cannot parse suggestions for {keyword} from {nameof(GoogleKeywordSuggestionsProvider)}.", e,
                    this);
            }

            return suggestions;
        }

        #endregion

        #region Protected Members

        protected virtual string GetRequestUrl([NotNull] string keyword)
        {
            return string.Format(
                Settings.GetSetting(
                    "KeywordSuggestionsProvider.Google.Url",
                    "https://www.google.com/complete/search?output=toolbar&q={0}&hl={1}"),
                keyword,
                Context.Language.CultureInfo.ThreeLetterISOLanguageName);
        }

        #endregion

        #region Constants

        private const string TOP_LEVEL_ELEMENT = "toplevel";
        private const string COMPLETE_SUGGESTION_ELEMENT = "CompleteSuggestion";
        private const string SUGGESTION_ELEMENT = "suggestion";
        private const string DATA_ATTRIBUTE = "data";

        #endregion
    }
}