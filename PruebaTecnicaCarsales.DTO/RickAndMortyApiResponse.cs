using System;
using System.Text.Json.Serialization;

namespace PruebaTecnicaCarsales.DTO
{
    // DTO para la información de paginación
    public record ApiInfo
    {
        [JsonPropertyName("count")]
        public int Count { get; init; }

        [JsonPropertyName("pages")]
        public int Pages { get; init; }

        [JsonPropertyName("next")]
        public string? Next { get; init; }

        [JsonPropertyName("prev")]
        public string? Prev { get; init; }
        public int CurrentPage { get; set; }
    }

    // DTO genérico para la respuesta completa de la API
    public record RickAndMortyApiResponse<T> where T : class
    {
        [JsonPropertyName("info")]
        public required ApiInfo Info { get; init; }

        [JsonPropertyName("results")]
        public required List<T> Results { get; init; }
    }
}