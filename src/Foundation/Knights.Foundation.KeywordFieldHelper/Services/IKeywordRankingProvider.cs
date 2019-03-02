using System.Collections.Generic;
using Knights.Feature.KeywordFieldHelper.Models;

namespace Knights.Feature.KeywordFieldHelper.Services
{
    public interface IKeywordRankingProvider
    {
        RankedKeyword RankKeyword(string keyword);

        IEnumerable<RankedKeyword> RankKeywords(IEnumerable<string> keywords);
    }
}