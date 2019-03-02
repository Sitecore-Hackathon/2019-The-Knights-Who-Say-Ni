using Newtonsoft.Json;

namespace Knights.Feature.KeywordFieldHelper.Models
{
    [JsonObject]
    public class RankedKeyword : Keyword
    {
        [JsonProperty("volume")] public int Volume { get; set; }

        [JsonProperty("costPerClick")] public string CostPerClick { get; set; }

        [JsonProperty("competition")] public double Competition { get; set; }

        [JsonProperty("ranked")] public bool Ranked => Volume > 0;
    }
}