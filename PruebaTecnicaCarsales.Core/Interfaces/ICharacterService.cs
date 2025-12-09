using PruebaTecnicaCarsales.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaCarsales.Core.Interfaces
{
    public interface ICharacterService
    {
        /// <summary>
        /// Obtiene una lista paginada de personajes desde la API externa, limpia los datos y 
        /// construye el DTO de respuesta optimizado para el Frontend.
        /// </summary>
        /// <param name="page">El número de página de Personajes que se desea obtener (mínimo 1).</param>
        /// <returns>Un Task que contiene el CharacterBffResponseDto con los datos limpios y la metadata de paginación.</returns>
        Task<CharacterBffResponseDto> GetPagedCharactersAsync(int page);
    }
}
