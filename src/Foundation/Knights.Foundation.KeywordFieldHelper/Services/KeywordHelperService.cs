using System;
using System.Collections.Generic;
using Knights.Feature.KeywordFieldHelper.Models;
using Sitecore.Diagnostics;

namespace Knights.Foundation.KeywordFieldHelper.Services
{
    public class KeywordHelperService : IKeywordHelperService
    {
        #region Ctors

        public KeywordHelperService(IKeywordSuggestionsProvider keywordSuggestionsProvider,
            IKeywordRankingProvider keywordRankingProvider)
        {
            _keywordSuggestionsProvider = keywordSuggestionsProvider;
            _keywordRankingProvider = keywordRankingProvider;
        }

        #endregion

        #region Implementation of IKeywordHelperService

        public IEnumerable<RankedKeyword> GetRankedSuggestions(string keyword)
        {
            try
            {
                var suggestedKeywords = _keywordSuggestionsProvider.GetSuggestions(keyword);
                var rankedKeywords = _keywordRankingProvider.RankKeywords(suggestedKeywords);
                return rankedKeywords;
            }
            catch (Exception e)
            {
                Log.Error($"Cannot get ranked suggestions for '{keyword}.'", e, this);
            }

            return new List<RankedKeyword>();
        }

        #endregion

        #region Fields

        private readonly IKeywordSuggestionsProvider _keywordSuggestionsProvider;
        private readonly IKeywordRankingProvider _keywordRankingProvider;

        #endregion
    }
}