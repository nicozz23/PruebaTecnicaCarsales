using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PruebaTecnicaCarsales.DTO;
using System.Threading.Tasks;

namespace PruebaTecnicaCarsales.Core.Interfaces
{
    public interface IEpisodeService
    {
        /// <summary>
        /// Obtiene una lista paginada de episodios desde la API externa, limpia los datos y 
        /// construye el DTO de respuesta optimizado para el Frontend.
        /// </summary>
        /// <param name="page">El número de página de episodios que se desea obtener (mínimo 1).</param>
        /// <returns>Un Task que contiene el EpisodeBffResponseDto con los datos limpios y la metadata de paginación.</returns>
        Task<EpisodeBffResponseDto> GetPagedEpisodesAsync(int page);
    }
}
