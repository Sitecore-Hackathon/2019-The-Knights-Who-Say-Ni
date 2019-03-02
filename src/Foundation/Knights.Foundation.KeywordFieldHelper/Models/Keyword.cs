using Newtonsoft.Json;

namespace Knights.Foundation.KeywordFieldHelper.Models
{
    [JsonObject]
    public class Keyword
    {
        [JsonProperty("text")] public string Text { get; set; }
    }
}