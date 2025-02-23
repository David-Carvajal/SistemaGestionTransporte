using Mectronics.SistemaGestionTransporte.Tranversales.Filtros;
using Mectronics.SistemaGestionTransporte.Tranversales.Interfaces.IBus;
using Mectronics.SistemaGestionTransporte.Tranversales.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Mectronics.SistemaGestionTransporte.MS.Bus.Controllers
{
    /// <summary>
    /// Controlador para la gestión de buses en la API.
    /// Proporciona operaciones para insertar, actualizar, eliminar, consultar y consultar listado buses.
    /// </summary>
    [Route("api/Bus")]
    [ApiController]
    public class BusController : ControllerBase
    {
        /// <summary>
        /// Servicio de buses para manejar la lógica de negocio.
        /// </summary>
        private readonly IBusServicio _busServicio;

        /// <summary>
        /// Inicializa una nueva instancia del <see cref="BusController"/> con el servicio inyectado.
        /// </summary>
        /// <param name="busServicio">Instancia del servicio de buses.</param>
        public BusController(IBusServicio busServicio)
        {
            _busServicio = busServicio;
        }

        /// <summary>
        /// Crea un nuevo bus en el sistema.
        /// </summary>
        /// <param name="busDto">Objeto <see cref="BusDto"/> con la información del bus a insertar.</param>
        /// <returns>Respuesta con el bus creado.</returns>
        [HttpPost]
        public ActionResult<int> Insertar([FromBody] BusDto busDto)
        {
            try
            {
                busDto = _busServicio.Insertar(busDto);
                return Ok(new RespuestaDto { Exito = true, Mensaje = "Bus creado exitosamente.", Datos = busDto });
            }
            catch (Exception ex)
            {
                return BadRequest(new RespuestaDto { Exito = false, Mensaje = ex.Message, Datos = null });
            }
        }

        /// <summary>
        /// Actualiza un bus existente en el sistema.
        /// </summary>
        /// <param name="busDto">Objeto <see cref="BusDto"/> con la información actualizada.</param>
        /// <returns>Respuesta con el bus actualizado.</returns>
        [HttpPatch]
        public ActionResult<int> Actualizar([FromBody] BusDto busDto)
        {
            try
            {
                _busServicio.Actualizar(busDto);
                return Ok(new RespuestaDto { Exito = true, Mensaje = "Bus modificado exitosamente.", Datos = busDto });
            }
            catch (Exception ex)
            {
                return BadRequest(new RespuestaDto { Exito = false, Mensaje = ex.Message, Datos = null });
            }
        }

        /// <summary>
        /// Elimina un bus del sistema por su identificador.
        /// </summary>
        /// <param name="id">Identificador único del bus a eliminar.</param>
        /// <returns>Respuesta con el resultado de la eliminación.</returns>
        [HttpDelete]
        public ActionResult<int> Eliminar(int id)
        {
            try
            {
                int resultado = _busServicio.Eliminar(id);
                return Ok(new RespuestaDto { Exito = true, Mensaje = "Bus eliminado exitosamente.", Datos = resultado });
            }
            catch (Exception ex)
            {
                return BadRequest(new RespuestaDto { Exito = false, Mensaje = ex.Message, Datos = null });
            }
        }

        /// <summary>
        /// Consulta un bus específico por su identificador.
        /// </summary>
        /// <param name="id">Identificador único del bus a consultar.</param>
        /// <returns>Objeto <see cref="BusDto"/> con la información del bus consultado.</returns>
        [HttpGet("{id}")]
        public ActionResult<BusDto> Consultar(int id)
        {
            try
            {
                BusFiltro filtro = new BusFiltro { IdBus = id };
                BusDto busDto = _busServicio.Consultar(filtro);

                if (busDto == null)
                {
                    return NotFound(new RespuestaDto { Exito = false, Mensaje = "No se encontró el bus solicitado.", Datos = null });
                }

                return Ok(new RespuestaDto { Exito = true, Mensaje = "Registro consultado exitosamente.", Datos = busDto });
            }
            catch (Exception ex)
            {
                return BadRequest(new RespuestaDto { Exito = false, Mensaje = ex.Message, Datos = null });
            }
        }

        /// <summary>
        /// Consulta una lista de buses basados en los filtros proporcionados.
        /// </summary>
        /// <param name="filtro">Objeto <see cref="BusFiltro"/> con los criterios de búsqueda.</param>
        /// <returns>Lista de buses encontrados.</returns>
        [HttpGet]
        public ActionResult<List<BusDto>> ConsultarLista([FromQuery] BusFiltro filtro)
        {
            try
            {
                List<BusDto> busesDto = _busServicio.ConsultarLista(filtro);

                if (busesDto == null || busesDto.Count == 0)
                {
                    return NotFound(new RespuestaDto { Exito = false, Mensaje = "No se encontró información.", Datos = null });
                }

                return Ok(new RespuestaDto { Exito = true, Mensaje = "Registros consultados exitosamente.", Datos = busesDto });
            }
            catch (Exception ex)
            {
                return BadRequest(new RespuestaDto { Exito = false, Mensaje = ex.Message, Datos = null });
            }
        }
    }
}

