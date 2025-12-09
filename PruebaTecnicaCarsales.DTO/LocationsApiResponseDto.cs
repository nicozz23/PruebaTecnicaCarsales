using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PruebaTecnicaCarsales.DTO
{
    public record LocationsApiResponseDto
    {
        [JsonPropertyName("id")]
        public int Id { get; init; }
        [JsonPropertyName("name")]
        public required string Name { get; init; }

        [JsonPropertyName("type")]
        public required string Type { get; init; }
        [JsonPropertyName("dimension")]
        public required string Dimension { get; init; }
        [JsonPropertyName("url")]
        public required string Url { get; init; }
        [JsonPropertyName("created")]
        public required string Created { get; init; }
        [JsonPropertyName("residents")]
        public required List<string> ResidentUrls { get; init; }


        /*
         public required int Id { get; init; }
        public required string Name { get; init; }
        public required string Type { get; init; }
        public required string Dimension { get; init; }
        public required string Url { get; init; }
        public required string Created { get; init; }
        public required List<string> ResidentUrls { get; init; }*/
    }
}
