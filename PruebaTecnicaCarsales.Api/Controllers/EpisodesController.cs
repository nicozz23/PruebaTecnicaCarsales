using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaCarsales.Core.Interfaces;
using PruebaTecnicaCarsales.DTO;

namespace PruebaTecnicaCarsales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EpisodesController : ControllerBase
    {

        private readonly IEpisodeService _episodeService;
        public EpisodesController(IEpisodeService episodeService)
        {
            _episodeService = episodeService;
        }

        /// <summary>
        /// Obtiene una lista paginada de episodios de Rick and Morty.
        /// </summary>
        /// <param name="page">El número de página solicitado (por defecto es 1).</param>
        /// <returns>Un DTO con la lista de episodios y datos de paginación.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(EpisodeBffResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<EpisodeBffResponseDto>> GetEpisodes([FromQuery] int page = 1)
        {
            // 1. Manejo de Errores
            if (page < 1)
            {
                // Requisito: Manejo de errores
                return BadRequest(new { message = "El número de página debe ser igual o superior a 1." });
            }

            try
            {
                // 2. Llamada a la Lógica del BFF
                var result = await _episodeService.GetPagedEpisodesAsync(page);

                // 3. Devolver la respuesta del BFF
                return Ok(result);
            }
            catch (HttpRequestException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                // Manejo específico si la API externa devuelve 404 (ej. página fuera de rango)
                return NotFound(new { message = $"La página {page} no existe en la fuente de datos externa." });
            }
            catch (Exception)
            {
                // Manejo de Errores: Cualquier otro error interno 
              
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { message = "Ocurrió un error interno al procesar su solicitud de episodios." });
            }

            
        }








    }
}
