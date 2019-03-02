using Newtonsoft.Json;

namespace Knights.Feature.KeywordFieldHelper.Models
{
    [JsonObject]
    public class Keyword
    {
        [JsonProperty("text")] public string Text { get; set; }
    }
}