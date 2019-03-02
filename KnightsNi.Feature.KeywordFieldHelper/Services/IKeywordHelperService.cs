using System.Collections.Generic;
using Knights.Feature.KeywordFieldHelper.Models;

namespace Knights.Feature.KeywordFieldHelper.Services
{
    public interface IKeywordHelperService
    {
        IEnumerable<RankedKeyword> GetRankedSuggestions(string keyword);
    }
}