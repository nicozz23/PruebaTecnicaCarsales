using PruebaTecnicaCarsales.Core.Interfaces;
using PruebaTecnicaCarsales.Domain;
using PruebaTecnicaCarsales.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaCarsales.Logic.Services
{


    /// <summary>
    /// Implementación del ICharacterService. Contiene la lógica del Backend for Frontend (BFF).
    /// Se encarga de llamar al cliente HTTP (IRickAndMortyClient), realizar el mapeo 
    /// de los DTOs de entrada a las Entidades de Dominio limpias, y simplificar la 
    /// información de paginación para el Frontend.
    /// </summary>
    public class CharacterService : ICharacterService
    {


        private readonly IRickAndMortyClient _rickAndMortyClient;

        public CharacterService(IRickAndMortyClient rickAndMortyClient)
        {
            _rickAndMortyClient = rickAndMortyClient;
        }



        public async Task<CharacterBffResponseDto> GetPagedCharactersAsync(int page)
        {
            var apiResponse = await _rickAndMortyClient.GetCharactersAsync(page);
            var characters = apiResponse.Results.Select(dto => new Character
            {
                Id = dto.Id,
                Name = dto.Name,
                Status = dto.Status,
                Species = dto.Species,
                Gender = dto.Gender,
                ImageUrl = dto.ImageUrl ,
                OriginName = dto.Origin.Name,
                LocationName = dto.Location.Name,
                EpisodeUrls = dto.EpisodeUrls,
                Created = dto.Created,
             }).ToList();


            // 3. Construir la Respuesta del BFF (con lógica de paginación)
            var bffResponse = new CharacterBffResponseDto
            {
                CurrentPage = page,
                TotalPages = apiResponse.Info.Pages,
                TotalCount = apiResponse.Info.Count,
                // Lógica de Paginación: simplificamos la URL 'next'/'prev' a un simple booleano
                HasNextPage = apiResponse.Info.Next is not null,
                HasPrevPage = apiResponse.Info.Prev is not null,
                Characters = characters
            };
         

            return bffResponse;

        }
    }
    
}