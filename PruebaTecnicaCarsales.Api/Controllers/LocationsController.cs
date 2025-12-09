using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaCarsales.Core.Interfaces;
using PruebaTecnicaCarsales.DTO;

namespace PruebaTecnicaCarsales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {

        private readonly ILocationsService _locationsService ;
        public LocationsController(ILocationsService locationsService)
        {
            _locationsService = locationsService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(LocationsBffResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<LocationsBffResponseDto>> GetLocations([FromQuery] int page = 1)
        {
            // 1. Manejo de Errores: Validación básica
            if (page < 1)
            {
                // Requisito: Manejo de errores
                return BadRequest(new { message = "El número de página debe ser igual o superior a 1." });
            }
            try
            {
                // 2. Llamada a la Lógica del BFF
                var result = await _locationsService.GetPagedLocationsAsync(page);
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
                    new { message = "Ocurrió un error interno al procesar su solicitud de ubicaciones." });
            }

        }
    }
}
