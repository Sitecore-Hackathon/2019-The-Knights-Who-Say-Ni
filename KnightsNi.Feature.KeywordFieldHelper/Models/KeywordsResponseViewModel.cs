using System.Collections.Generic;
using Newtonsoft.Json;

namespace Knights.Feature.KeywordFieldHelper.Models
{
    [JsonObject]
    public class KeywordsResponseViewModel
    {
        [JsonProperty("volumeLabel")] public string VolumeLabel { get; set; }

        [JsonProperty("cpcLabel")] public string CpcLabel { get; set; }

        [JsonProperty("competitionLabel")] public string CompetitionLabel { get; set; }

        [JsonProperty("keywords")] public List<RankedKeyword> Keywords { get; set; }
    }
}