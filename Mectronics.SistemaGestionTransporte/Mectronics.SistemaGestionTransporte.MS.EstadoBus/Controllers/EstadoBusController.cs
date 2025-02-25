using Mectronics.SistemaGestionTransporte.Tranversales.Dtos;
using Mectronics.SistemaGestionTransporte.Tranversales.Filtros;
using Mectronics.SistemaGestionTransporte.Tranversales.Interfaces.IEstadoBus;
using Microsoft.AspNetCore.Mvc;

namespace Mectronics.SistemaGestionTransporte.MS.EstadoBus.Controllers
{
    /// <summary>
    /// Controlador para la gestión de estado buses en la API.
    /// Proporciona operaciones de consultar estado de buses.
    /// </summary>
    [Route("api/EstadoBus")]
    [ApiController]
    public class EstadoBusController : ControllerBase
    {
        /// <summary>
        /// Servicio para manejar la lógica de negocio de los estados de buses.
        /// </summary>
        private readonly IEstadoBusServicio _estadoBusServicio;

        /// <summary>
        /// Inicializa una nueva instancia del <see cref="EstadoBusController"/> con el servicio inyectado.
        /// </summary>
        /// <param name="estadoBusServicio">Instancia del servicio de estado de buses.</param>
        public EstadoBusController(IEstadoBusServicio estadoBusServicio)
        {
            _estadoBusServicio = estadoBusServicio;
        }

        /// <summary>
        /// Consulta un estado de bus específico por su identificador.
        /// </summary>
        /// <param name="id">Identificador único del estado de bus a consultar.</param>
        /// <returns>Objeto <see cref="EstadoBusDto"/> con la información del estado de bus consultado.</returns>
        [HttpGet]
        public ActionResult Consultar()
        {
            try
            {
                EstadoBusFiltro filtro = new EstadoBusFiltro ();
                List<EstadoBusDto> estados = _estadoBusServicio.Consultar(filtro);

                if (estados == null)
                {
                    return Ok(new RespuestaDto { Exito = false, Mensaje = "No se encontró información.", Datos = null });
                }

                return Ok(new RespuestaDto { Exito = true, Mensaje = "Registro consultado exitosamente.", Datos = estados });
            }
            catch (Exception ex)
            {
                return BadRequest(new RespuestaDto { Exito = false, Mensaje = ex.Message, Datos = null });
            }
        }
    }
}

