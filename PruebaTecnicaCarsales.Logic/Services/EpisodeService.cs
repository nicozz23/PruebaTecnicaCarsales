using PruebaTecnicaCarsales.Core.Interfaces;
using PruebaTecnicaCarsales.Domain;
using PruebaTecnicaCarsales.DTO;

namespace PruebaTecnicaCarsales.Logic.Services;


/// <summary>
/// Implementación del IEpisodeService. Contiene la lógica del Backend for Frontend (BFF).
/// Se encarga de llamar al cliente HTTP (IRickAndMortyClient), realizar el mapeo 
/// de los DTOs de entrada a las Entidades de Dominio limpias, y simplificar la 
/// información de paginación para el Frontend.
/// </summary>
public class EpisodeService : IEpisodeService
{
    // Inyectamos el cliente de la API externa (DIP: dependencia de abstracción)
    private readonly IRickAndMortyClient _rickAndMortyClient;

    public EpisodeService(IRickAndMortyClient rickAndMortyClient)
    {
        _rickAndMortyClient = rickAndMortyClient;
    }

    public async Task<EpisodeBffResponseDto> GetPagedEpisodesAsync(int page)
    {
        // 1. Llamar al cliente de la API externa
        // Aquí obtenemos la respuesta cruda de Rick and Morty
        var apiResponse = await _rickAndMortyClient.GetEpisodesAsync(page);

        // 2. Mapear y Limpiar (Lógica del BFF)
        // Convertimos los DTOs de la API externa (EpisodeApiResponseDto) 
        // a las Entidades de Dominio limpias (Episode).
        var episodes = apiResponse.Results.Select(dto => new Episode
        {
            Id = dto.Id,
            Name = dto.Name,
            AirDate = dto.AirDate,
            Code = dto.Code,
            CharacterUrls = dto.CharacterUrls,
            Url = dto.Url,
            Created = DateTime.TryParse(dto.Created, out var date) ? date : default   // Convertimos la fecha de string a DateTime
        }).ToList();

        // 3. Construir la Respuesta del BFF (con lógica de paginación)
        var bffResponse = new EpisodeBffResponseDto
        {
            CurrentPage = page,
            TotalPages = apiResponse.Info.Pages,
            TotalCount = apiResponse.Info.Count,

            // Lógica de Paginación: simplificamos la URL 'next'/'prev' a un simple booleano
            HasNextPage = apiResponse.Info.Next is not null,
            HasPrevPage = apiResponse.Info.Prev is not null,

            Episodes = episodes
        };

        return bffResponse;
    }
}