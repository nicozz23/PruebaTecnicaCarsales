using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PruebaTecnicaCarsales.Core.Interfaces;
using PruebaTecnicaCarsales.Domain;
using PruebaTecnicaCarsales.DTO;

namespace PruebaTecnicaCarsales.Logic.Services
{
    /// <summary>
    /// Implementación del ILocationsService. Contiene la lógica del Backend for Frontend (BFF).
    /// Se encarga de llamar al cliente HTTP (IRickAndMortyClient), realizar el mapeo 
    /// de los DTOs de entrada a las Entidades de Dominio limpias, y simplificar la 
    /// información de paginación para el Frontend.
    /// </summary>
    public class LocationService : ILocationsService
    {

        private readonly IRickAndMortyClient _rickAndMortyClient;
        public LocationService(IRickAndMortyClient rickAndMortyClient)
        {
            _rickAndMortyClient = rickAndMortyClient;
        }

        public async Task<LocationsBffResponseDto> GetPagedLocationsAsync(int page)
        {
            var apiResponse = await _rickAndMortyClient.GetLocationsAsync(page);
            var locations = apiResponse.Results.Select(dto => new Location
            {
                Id = dto.Id,
                Name = dto.Name,
                Type = dto.Type,
                Dimension = dto.Dimension,
                ResidentUrls = dto.ResidentUrls,
                Url = dto.Url,
                Created = DateTime.TryParse(dto.Created, out var date) ? date : default
            }).ToList();

            var bffResponse = new LocationsBffResponseDto
            {
                CurrentPage = page,
                TotalPages = apiResponse.Info.Pages,
                TotalCount = apiResponse.Info.Count,
                HasNextPage = apiResponse.Info.Next is not null,
                HasPrevPage = apiResponse.Info.Prev is not null,
                Locations = locations
            };

            return bffResponse;
        }
    }
}