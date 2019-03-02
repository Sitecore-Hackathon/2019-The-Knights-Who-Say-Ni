using System.Collections.Generic;

namespace Knights.Feature.KeywordFieldHelper.Services
{
    public interface IKeywordSuggestionsProvider
    {
        IEnumerable<string> GetSuggestions(string keyword);
    }
}