using System.Collections.Generic;
using Newtonsoft.Json;

namespace Knights.Feature.KeywordFieldHelper.Models
{
    [JsonObject]
    public class KeywordsEverywhereResponse
    {
        [JsonProperty("error")] public string Error { get; set; }

        [JsonProperty("alert")] public string Alert { get; set; }

        [JsonProperty("banner")] public string Banner { get; set; }

        [JsonProperty("data")] public Dictionary<string, KeywordsEverywhereResponseItem> Data { get; set; }

        [JsonProperty("time")] public long Time { get; set; }
    }
}