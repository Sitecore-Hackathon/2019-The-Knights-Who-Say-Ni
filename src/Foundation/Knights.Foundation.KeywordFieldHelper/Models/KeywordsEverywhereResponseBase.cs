using Newtonsoft.Json;

namespace Knights.Feature.KeywordFieldHelper.Models
{
    public class KeywordsEverywhereResponseBase
    {
        [JsonProperty("error")] public string Error { get; set; }

        [JsonProperty("alert")] public string Alert { get; set; }

        [JsonProperty("banner")] public string Banner { get; set; }

        [JsonProperty("time")] public long Time { get; set; }
    }
}