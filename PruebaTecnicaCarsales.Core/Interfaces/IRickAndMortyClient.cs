using PruebaTecnicaCarsales.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaCarsales.Core.Interfaces
{
    public interface IRickAndMortyClient
    {
        
        // Retorna el DTO que modela la respuesta de la API externa.
        Task<RickAndMortyApiResponse<EpisodeApiResponseDto>> GetEpisodesAsync(int page);
        Task<RickAndMortyApiResponse<CharacterApiResponseDto>> GetCharactersAsync(int page);
        
        Task<RickAndMortyApiResponse<LocationsApiResponseDto>> GetLocationsAsync(int page);
    }
}
