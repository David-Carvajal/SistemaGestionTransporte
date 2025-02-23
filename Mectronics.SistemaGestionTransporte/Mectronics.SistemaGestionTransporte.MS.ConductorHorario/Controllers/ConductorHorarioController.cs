using Mectronics.SistemaGestionTransporte.Tranversales.Dtos;
using Mectronics.SistemaGestionTransporte.Tranversales.Filtros;
using Mectronics.SistemaGestionTransporte.Tranversales.Interfaces.IConductorHorario;
using Microsoft.AspNetCore.Mvc;

namespace Mectronics.SistemaGestionTransporte.MS.ConductorHorario.Controllers
{
    [Route("api/Conductor Horario")]
    [ApiController]
    public class ConductorHorarioController : ControllerBase
    {
        /// <summary>
        /// Servicio para manejar la lógica de negocio de los horarios de los conductores.
        /// </summary>
        private readonly IConductorHorarioServicio _conductorHorarioServicio;

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="ConductorHorarioController"/> con el servicio inyectado.
        /// </summary>
        /// <param name="conductorHorarioServicio">Instancia del servicio de horarios de conductores.</param>
        public ConductorHorarioController(IConductorHorarioServicio conductorHorarioServicio)
        {
            _conductorHorarioServicio = conductorHorarioServicio;
        }

        /// <summary>
        /// Crea un nuevo horario de conductor en el sistema.
        /// </summary>
        /// <param name="conductorHorarioDto">Objeto <see cref="ConductorHorarioDto"/> con la información del horario a insertar.</param>
        /// <returns>Respuesta con el horario creado.</returns>
        [HttpPost]
        public ActionResult<int> Insertar([FromBody] ConductorHorarioDto conductorHorarioDto)
        {
            try
            {
                conductorHorarioDto = _conductorHorarioServicio.Insertar(conductorHorarioDto);
                return Ok(new RespuestaDto { Exito = true, Mensaje = "Horario de conductor creado exitosamente.", Datos = conductorHorarioDto });
            }
            catch (Exception ex)
            {
                return BadRequest(new RespuestaDto { Exito = false, Mensaje = ex.Message, Datos = null });
            }
        }

        /// <summary>
        /// Actualiza un horario de conductor existente en el sistema.
        /// </summary>
        /// <param name="conductorHorarioDto">Objeto <see cref="ConductorHorarioDto"/> con la información actualizada.</param>
        /// <returns>Respuesta con el horario actualizado.</returns>
        [HttpPatch]
        public ActionResult<int> Actualizar([FromBody] ConductorHorarioDto conductorHorarioDto)
        {
            try
            {
                _conductorHorarioServicio.Actualizar(conductorHorarioDto);
                return Ok(new RespuestaDto { Exito = true, Mensaje = "Horario de conductor modificado exitosamente.", Datos = conductorHorarioDto });
            }
            catch (Exception ex)
            {
                return BadRequest(new RespuestaDto { Exito = false, Mensaje = ex.Message, Datos = null });
            }
        }

        /// <summary>
        /// Elimina un horario de conductor del sistema por su identificador.
        /// </summary>
        /// <param name="id">Identificador único del horario a eliminar.</param>
        /// <returns>Respuesta con el resultado de la eliminación.</returns>
        [HttpDelete]
        public ActionResult<int> Eliminar(int id)
        {
            try
            {
                int resultado = _conductorHorarioServicio.Eliminar(id);
                return Ok(new RespuestaDto { Exito = true, Mensaje = "Horario de conductor eliminado exitosamente.", Datos = resultado });
            }
            catch (Exception ex)
            {
                return BadRequest(new RespuestaDto { Exito = false, Mensaje = ex.Message, Datos = null });
            }
        }
        /// <summary>
        /// Consulta una lista de horarios de conductores basados en los filtros proporcionados.
        /// </summary>
        /// <param name="filtro">Objeto <see cref="ConductorHorarioFiltro"/> con los criterios de búsqueda.</param>
        /// <returns>Lista de horarios de conductores encontrados.</returns>
        [HttpGet]
        public ActionResult<List<ConductorHorarioDto>> ConsultarLista([FromQuery] ConductorHorarioFiltro filtro)
        {
            try
            {
                List<ConductorHorarioDto> horariosDto = _conductorHorarioServicio.ConsultarLista(filtro);

                if (horariosDto == null || horariosDto.Count == 0)
                {
                    return NotFound(new RespuestaDto { Exito = false, Mensaje = "No se encontró información.", Datos = null });
                }

                return Ok(new RespuestaDto { Exito = true, Mensaje = "Registros consultados exitosamente.", Datos = horariosDto });
            }
            catch (Exception ex)
            {
                return BadRequest(new RespuestaDto { Exito = false, Mensaje = ex.Message, Datos = null });
            }
        }
    }
}
