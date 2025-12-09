using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PruebaTecnicaCarsales.DTO
{
    public class CharacterApiResponseDto
    {
        [JsonPropertyName("id")]
        public int Id { get; init; }

        [JsonPropertyName("name")]
        public required string Name { get; init; }

        [JsonPropertyName("status")]
        public required string Status { get; init; }

        [JsonPropertyName("species")]
        public required string Species { get; init; }

        [JsonPropertyName("gender")]
        public required string Gender { get; init; }

        [JsonPropertyName("origin")]
        public required LocationInfoDto Origin { get; init; } // Objeto anidado

        [JsonPropertyName("location")]
        public required LocationInfoDto Location { get; init; } // Objeto anidado

        [JsonPropertyName("image")]
        public required string ImageUrl { get; init; } // Nombre en JSON es 'image'

        [JsonPropertyName("episode")]
        public required List<string> EpisodeUrls { get; init; } // Lista de URLs de episodios

        [JsonPropertyName("created")]
        public required string Created { get; init; } // La API lo da como string
    }

    //Me sirve para location y origin
    public record LocationInfoDto
    {
        [JsonPropertyName("name")]
        public required string Name { get; init; }
    }
}
