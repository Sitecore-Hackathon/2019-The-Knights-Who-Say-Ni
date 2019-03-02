using System.Collections.Generic;
using Knights.Feature.KeywordFieldHelper.Models;

namespace Knights.Foundation.KeywordFieldHelper.Services
{
    public interface IKeywordHelperService
    {
        IEnumerable<RankedKeyword> GetRankedSuggestions(string keyword);
    }
}