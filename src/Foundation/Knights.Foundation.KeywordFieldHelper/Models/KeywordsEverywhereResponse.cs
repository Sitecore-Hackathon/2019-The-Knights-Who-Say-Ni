using System.Collections.Generic;
using Newtonsoft.Json;

namespace Knights.Foundation.KeywordFieldHelper.Models
{
    [JsonObject]
    public class KeywordsEverywhereResponse : KeywordsEverywhereResponseBase
    {
        [JsonProperty("data")] public List<KeywordsEverywhereResponseItem> Data { get; set; }
    }
}