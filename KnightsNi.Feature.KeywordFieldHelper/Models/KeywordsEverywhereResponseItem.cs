using Newtonsoft.Json;

namespace Knights.Feature.KeywordFieldHelper.Models
{
    [JsonObject]
    public class KeywordsEverywhereResponseItem
    {
        [JsonProperty("vol")] public string Vol { get; set; }

        [JsonProperty("cpc")] public string Cpc { get; set; }

        [JsonProperty("keyword")] public string Keyword { get; set; }

        [JsonProperty("competition")] public string Competition { get; set; }
    }
}