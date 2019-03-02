using System.Collections.Generic;

namespace Knights.Foundation.KeywordFieldHelper.Services
{
    public interface IKeywordSuggestionsProvider
    {
        IEnumerable<string> GetSuggestions(string keyword);
    }
}