using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PruebaTecnicaCarsales.DTO
{
    public record EpisodeApiResponseDto
    {
        // Usa JsonPropertyName para mapear nombres snake_case a PascalCase
        [JsonPropertyName("id")]
        public int Id { get; init; }

        [JsonPropertyName("name")]
        public required string Name { get; init; }

        [JsonPropertyName("air_date")]
        public required string AirDate { get; init; } 

        [JsonPropertyName("episode")]
        public required string Code { get; init; }

        [JsonPropertyName("characters")]
        public required List<string> CharacterUrls { get; init; }

        [JsonPropertyName("url")]
        public required string Url { get; init; }

        [JsonPropertyName("created")]
        public required string Created { get; init; } // Será convertido a DateTime en la capa de Logic
    }
}
