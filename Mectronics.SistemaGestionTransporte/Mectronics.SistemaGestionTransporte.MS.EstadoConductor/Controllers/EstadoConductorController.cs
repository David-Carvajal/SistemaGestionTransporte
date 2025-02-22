using Mectronics.SistemaGestionTransporte.Tranversales.Dtos;
using Mectronics.SistemaGestionTransporte.Tranversales.Filtros;
using Mectronics.SistemaGestionTransporte.Tranversales.Interfaces.IEstadoConductor;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mectronics.SistemaGestionTransporte.MS.EstadoConductor.Controllers
{/// <summary>
 /// Controlador para gestionar las operaciones relacionadas con el estado de los conductores.
 /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoConductorController : ControllerBase
    {
        /// <summary>
        /// Servicio de estado de conductor para manejar la lógica de negocio.
        /// </summary>
        private readonly IEstadoConductorServicio _estadoConductorServicio;

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="EstadoConductorController"/> con el servicio inyectado.
        /// </summary>
        /// <param name="estadoConductorServicio">Instancia del servicio de estado de conductor.</param>
        public EstadoConductorController(IEstadoConductorServicio estadoConductorServicio)
        {
            _estadoConductorServicio = estadoConductorServicio;
        }

        /// <summary>
        /// Consulta un estado de conductor específico por su identificador.
        /// </summary>
        /// <param name="id">Identificador único del estado del conductor a consultar.</param>
        /// <returns>Objeto <see cref="EstadoConductorDto"/> con la información del estado del conductor.</returns>
        [HttpGet("{id}")]
        public ActionResult<EstadoConductorDto> Consultar(int id)
        {
            try
            {

                var filtro = new EstadoConductorFiltro { IdEstadoConductor = id };
                EstadoConductorDto estadoConductorDto = _estadoConductorServicio.Consultar(filtro);

                if (estadoConductorDto == null)
                {
                    return NotFound(new RespuestaDto { Exito = false, Mensaje = "No se encontró el estado de conductor solicitado.", Datos = null });
                }

                return Ok(new RespuestaDto { Exito = true, Mensaje = "Estado de conductor consultado exitosamente.", Datos = estadoConductorDto });
            }
            catch (Exception ex)
            {
                return BadRequest(new RespuestaDto { Exito = false, Mensaje = ex.Message, Datos = null });
            }
        }
    }
}
