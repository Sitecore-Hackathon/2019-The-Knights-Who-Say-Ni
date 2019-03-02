using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using Knights.Feature.KeywordFieldHelper.Models;
using Newtonsoft.Json;
using Sitecore;
using Sitecore.Configuration;
using Sitecore.Diagnostics;

namespace Knights.Feature.KeywordFieldHelper.Services
{
    public class KeywordsEverywhereKeywordRankingProvider : IKeywordRankingProvider
    {
        #region Implementation of IKeywordRankingProvider

        public RankedKeyword RankKeyword(string keyword)
        {
            var rankedKeyword = new RankedKeyword
            {
                Text = keyword
            };

            try
            {
                var url = GetRequestUrl(keyword);

                using (var client = new WebClient {Encoding = Encoding.UTF8})
                {
                    var jsonString = client.DownloadString(url);

                    if (string.IsNullOrWhiteSpace(jsonString))
                    {
                        Log.Error($"Cannot get ranking information for '{keyword}'.", this);
                        return rankedKeyword;
                    }

                    var response = JsonConvert.DeserializeObject<KeywordsEverywhereResponse>(jsonString);

                    if (response == null || !string.IsNullOrWhiteSpace(response.Error))
                    {
                        Log.SingleError($"Cannot get ranking information for '{keyword}'. Error: {response?.Error}",
                            this);
                        return rankedKeyword;
                    }

                    if (!string.IsNullOrWhiteSpace(response.Alert))
                        Log.Warn($"Got an alert({response.Alert}) while was ranking '{keyword}'.", this);

                    CopyRankedData(rankedKeyword, response.Data?.SingleOrDefault(x => x.Keyword.Equals(keyword, StringComparison.InvariantCultureIgnoreCase)));
                }
            }
            catch (Exception e)
            {
                Log.Error($"Cannot rank keyword '{keyword}' using {nameof(KeywordsEverywhereKeywordRankingProvider)}.",
                    e, this);
            }

            return rankedKeyword;
        }

        public IEnumerable<RankedKeyword> RankKeywords([NotNull] IEnumerable<string> keywords)
        {
            var rankedKeywords = keywords.Select(x => new RankedKeyword {Text = x}).ToList();

            try
            {
                var url = GetRequestUrl(keywords);

                using (var client = new WebClient {Encoding = Encoding.UTF8})
                {
                    var jsonString = client.DownloadString(url);

                    if (string.IsNullOrWhiteSpace(jsonString))
                    {
                        Log.Error($"Cannot get ranking information for '{string.Join(", ", keywords)}'.", this);
                        return rankedKeywords;
                    }

                    var response = JsonConvert.DeserializeObject<KeywordsEverywhereBatchResponse>(jsonString);

                    if (response == null || !string.IsNullOrWhiteSpace(response.Error))
                    {
                        Log.SingleError(
                            $"Cannot get ranking information for '{string.Join(", ", keywords)}'. Error: {response?.Error}",
                            this);
                        return rankedKeywords;
                    }

                    if (!string.IsNullOrWhiteSpace(response.Alert))
                        Log.Warn($"Got an alert({response.Alert}) while was ranking '{string.Join(", ", keywords)}'.",
                            this);

                    foreach (var rankedKeyword in rankedKeywords)
                        CopyRankedData(rankedKeyword,
                            response.Data?.SingleOrDefault(x =>
                                x.Value.Keyword.Equals(rankedKeyword.Text, StringComparison.InvariantCultureIgnoreCase)).Value);
                }
            }
            catch (Exception e)
            {
                Log.Error(
                    $"Cannot rank keyword '{string.Join(", ", keywords)}' using {nameof(KeywordsEverywhereKeywordRankingProvider)}.",
                    e, this);
            }

            return rankedKeywords.OrderByDescending(x=>x.Volume).ToList();
        }

        #endregion

        #region Protected members

        protected virtual string GetUrl()
        {
            return
                $"{Settings.GetSetting("KeywordsEverywhere.Api.Url")}?apiKey={Settings.GetSetting("KeywordsEverywhere.Api.Key")}&country={Settings.GetSetting("KeywordsEverywhere.Api.Country")}&currency={Settings.GetSetting("KeywordsEverywhere.Api.Currency")}&source={Settings.GetSetting("KeywordsEverywhere.Api.Source")}&t={DateTime.Now.Ticks}";
        }

        protected virtual string GetRequestUrl([NotNull] string keyword)
        {
            var url = GetUrl();
            return $"{url}&kw[]={keyword}";
        }

        protected virtual string GetRequestUrl([NotNull] IEnumerable<string> keywords)
        {
            var url = GetUrl();
            return keywords.Aggregate(url, (current, keyword) => $"{current}&kw[]={keyword}");
        }

        protected virtual void CopyRankedData([NotNull] RankedKeyword keyword, [NotNull] KeywordsEverywhereResponseItem item)
        {
            if (int.TryParse(item.Vol, out var volume)) keyword.Volume = volume;
            keyword.CostPerClick = item.Cpc;
            if (double.TryParse(item.Competition, out var competition)) keyword.Competition = competition;
        }

        #endregion
    }
}