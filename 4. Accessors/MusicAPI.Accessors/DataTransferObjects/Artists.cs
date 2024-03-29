﻿using System.Text.Json.Serialization;

namespace MusicAPI.Accessors.DataTransferObjects
{
    public class Artists : BaseSearchResult
    {
        [JsonPropertyName("items")]
        public Artist[] Items { get; set; } = [];
    }
}
