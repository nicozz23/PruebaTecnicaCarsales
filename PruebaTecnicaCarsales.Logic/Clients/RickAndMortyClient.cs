using PruebaTecnicaCarsales.Core.Interfaces;
using PruebaTecnicaCarsales.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PruebaTecnicaCarsales.Logic.Clients
{
    public class RickAndMortyClient : IRickAndMortyClient
    {
        private readonly HttpClient _httpClient;
        public RickAndMortyClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<RickAndMortyApiResponse<EpisodeApiResponseDto>> GetEpisodesAsync(int page)
        {
            var url = $"episode?page={page}";
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            var result = JsonSerializer.Deserialize<RickAndMortyApiResponse<EpisodeApiResponseDto>>(content, options);

            return result ?? throw new InvalidOperationException("La respuesta de la API externa fue nula o inválida.");
        }

        public async Task<RickAndMortyApiResponse<CharacterApiResponseDto>> GetCharactersAsync(int page)
        {
            var url = $"character/?page={page}";
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            var result = JsonSerializer.Deserialize<RickAndMortyApiResponse<CharacterApiResponseDto>>(content, options);

            return result ?? throw new InvalidOperationException("La respuesta de la API externa fue nula o inválida.");
        }

        public async Task<RickAndMortyApiResponse<LocationsApiResponseDto>> GetLocationsAsync(int page)
        {
         var url = $"location?page={page}";
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var result = JsonSerializer.Deserialize<RickAndMortyApiResponse<LocationsApiResponseDto>>(content, options);
            return result ?? throw new InvalidOperationException("La respuesta de la API externa fue nula o inválida.");
        }






    }

}


