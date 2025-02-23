using Mectronics.SistemaGestionTransporte.Tranversales.Dtos;
using Mectronics.SistemaGestionTransporte.Tranversales.Filtros;
using Mectronics.SistemaGestionTransporte.Tranversales.Interfaces.IBusHorario;
using Microsoft.AspNetCore.Mvc;

namespace Mectronics.SistemaGestionTransporte.MS.BusHorario.Controllers
{
    /// <summary>
    /// Controlador para la gestión de horarios de buses en la API.
    /// Proporciona operaciones para insertar, actualizar, eliminar y consultar horarios de buses.
    /// </summary>
    [ApiController]
    [Route("api/Bus horario")]
    public class BusHorarioController : ControllerBase
    {
        /// <summary>
        /// Servicio de bus horario para manejar la lógica de negocio.
        /// </summary>
        private readonly IBusHorarioServicio _busHorarioServicio;

        /// <summary>
        /// Inicializa una nueva instancia del <see cref="BusHorarioController"/> con el servicio inyectado.
        /// </summary>
        /// <param name="busHorarioServicio">Instancia del servicio de horarios de buses.</param>
        public BusHorarioController(IBusHorarioServicio busHorarioServicio)
        {
            _busHorarioServicio = busHorarioServicio;
        }

        /// <summary>
        /// Crea un nuevo horario de bus en el sistema.
        /// </summary>
        /// <param name="busHorarioDto">Objeto <see cref="BusHorarioDto"/> con la información del horario a insertar.</param>
        /// <returns>Respuesta con el horario creado.</returns>
        [HttpPost]
        public ActionResult<int> Insertar([FromBody] BusHorarioDto busHorarioDto)
        {
            try
            {
                busHorarioDto = _busHorarioServicio.Insertar(busHorarioDto);

                return Ok(new RespuestaDto{ Exito = true,Mensaje = "Horario de bus creado exitosamente.",Datos = busHorarioDto});
            }
            catch (Exception ex)
            {
                return BadRequest(new RespuestaDto{Exito = false,Mensaje = ex.Message,Datos = null });
            }
        }

        /// <summary>
        /// Actualiza un horario de bus existente en el sistema.
        /// </summary>
        /// <param name="busHorarioDto">Objeto <see cref="BusHorarioDto"/> con la información actualizada.</param>
        /// <returns>Respuesta con el horario actualizado.</returns>
        [HttpPatch]
        public ActionResult<int> Actualizar([FromBody] BusHorarioDto busHorarioDto)
        {
            try
            {
                _busHorarioServicio.Actualizar(busHorarioDto);

                return Ok(new RespuestaDto{Exito = true,Mensaje = "Horario de bus modificado exitosamente.",Datos = busHorarioDto});
            }
            catch (Exception ex)
            {
                return BadRequest(new RespuestaDto{Exito = false, Mensaje = ex.Message,Datos = null});
            }
        }

        /// <summary>
        /// Elimina un horario de bus del sistema por su identificador.
        /// </summary>
        /// <param name="id">Identificador único del horario de bus a eliminar.</param>
        /// <returns>Respuesta con el resultado de la eliminación.</returns>
        [HttpDelete]
        public ActionResult<int> Eliminar(int id)
        {
            try
            {
                int resultado = _busHorarioServicio.Eliminar(id);

                return Ok(new RespuestaDto { Exito = true, Mensaje = "Horario Eliminado correctamente.", Datos = resultado });
                
            }
            catch (Exception ex)
            {
                return BadRequest(new RespuestaDto{Exito = false,Mensaje = ex.Message,Datos = null});
            }
        }
        /// <summary>
        /// Consulta una lista de horarios de buses basados en los filtros proporcionados.
        /// </summary>
        /// <param name="filtro">Objeto <see cref="BusHorarioFiltro"/> con los criterios de búsqueda.</param>
        /// <returns>Lista de horarios de buses encontrados.</returns>
        [HttpGet]
        public ActionResult<List<BusHorarioDto>> ConsultarLista([FromQuery] BusHorarioFiltro filtro)
        {
            try
            {
                List<BusHorarioDto> busHorariosDto = _busHorarioServicio.ConsultarLista(filtro);

                if (busHorariosDto == null || busHorariosDto.Count == 0)
                {
                    return NotFound(new RespuestaDto{Exito = false,Mensaje = "No se encontró información.",Datos = null});
                }

                return Ok(new RespuestaDto{Exito = true, Mensaje = "Registros consultados exitosamente.", Datos = busHorariosDto});
            }
            catch (Exception ex)
            {
                return BadRequest(new RespuestaDto{Exito = false, Mensaje = ex.Message,Datos = null});
            }
        }
    }
}
