using Mectronics.SistemaGestionTransporte.Tranversales.Dtos;
using Mectronics.SistemaGestionTransporte.Tranversales.Filtros;
using Mectronics.SistemaGestionTransporte.Tranversales.Interfaces.IEstadoConductor;
using Microsoft.AspNetCore.Mvc;

namespace Mectronics.SistemaGestionTransporte.MS.EstadoConductor.Controllers
{
    /// <summary>
    /// Controlador para la gestión de estado conductores en la API.
    /// Proporciona operaciones de consultar estado de conductores.
    /// </summary>
    [Route("api/EstadoConductor")]
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
        [HttpGet]
        public ActionResult<EstadoConductorDto> ConsultarLista()
        {
            try
            {
                List<EstadoConductorDto> estadoConductorDto = _estadoConductorServicio.ConsultarLista();

                if (estadoConductorDto == null)
                {
                    return Ok(new RespuestaDto { Exito = false, Mensaje = "No se encontró el estado de conductor solicitado.", Datos = null });
                }

                return Ok(new RespuestaDto { Exito = true, Mensaje = "Estado de conductor consultado exitosamente.", Datos =  estadoConductorDto});
            }
            catch (Exception ex)
            {
                return BadRequest(new RespuestaDto { Exito = false, Mensaje = ex.Message, Datos = null });
            }
        }
    }
}
