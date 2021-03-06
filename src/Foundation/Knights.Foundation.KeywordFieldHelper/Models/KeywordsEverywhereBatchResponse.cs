﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace Knights.Foundation.KeywordFieldHelper.Models
{
    [JsonObject]
    public class KeywordsEverywhereBatchResponse : KeywordsEverywhereResponseBase
    {
        [JsonProperty("data")] public Dictionary<string, KeywordsEverywhereResponseItem> Data { get; set; }
    }
}