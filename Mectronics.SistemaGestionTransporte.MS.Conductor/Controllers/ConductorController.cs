using Mectronics.SistemaGestionTransporte.Tranversales.Dtos;
using Mectronics.SistemaGestionTransporte.Tranversales.Filtros;
using Mectronics.SistemaGestionTransporte.Tranversales.Interfaces.IConductor;
using Microsoft.AspNetCore.Mvc;

namespace Mectronics.SistemaGestionTransporte.MS.Conductor.Controllers
{
    /// <summary>
    /// Controlador para la gestión de Conductores en la API.
    /// Proporciona operaciones para insertar, actualizar, eliminar, consultar y consultar listado conductores.
    /// </summary>
    [ApiController]
    [Route("api/Conductor")]
    public class ConductorController : ControllerBase
    {
        /// <summary>
        /// Servicio de conductores para manejar la lógica de negocio.
        /// </summary>
        private readonly IConductorServicio _conductorServicio;

        /// <summary>
        /// Inicializa una nueva instancia del <see cref="ConductorController"/> con el servicio inyectado.
        /// </summary>
        /// <param name="conductorServicio">Instancia del servicio de conductores.</param>
        public ConductorController(IConductorServicio conductorServicio)
        {
            _conductorServicio = conductorServicio;
        }

        /// <summary>
        /// Crea un nuevo conductor en el sistema.
        /// </summary>
        /// <param name="conductorDto">Objeto <see cref="ConductorDto"/> con la información del conductor a insertar.</param>
        /// <returns>Respuesta con el conductor creado.</returns>
        [HttpPost]
        public ActionResult<int> Insertar([FromBody] ConductorDto conductorDto)
        {
            try
            {
                conductorDto = _conductorServicio.Insertar(conductorDto);
                return Ok(new RespuestaDto { Exito = true, Mensaje = "Conductor creado exitosamente.", Datos = conductorDto });
            }
            catch (Exception ex)
            {
                return BadRequest(new RespuestaDto { Exito = false, Mensaje = ex.Message, Datos = null });
            }
        }

        /// <summary>
        /// Actualiza un conductor existente en el sistema.
        /// </summary>
        /// <param name="conductorDto">Objeto <see cref="ConductorDto"/> con la información actualizada.</param>
        /// <returns>Respuesta con el conductor actualizado.</returns>
        [HttpPatch]
        public ActionResult<int> Actualizar([FromBody] ConductorDto conductorDto)
        {
            try
            {
                _conductorServicio.Actualizar(conductorDto);
                return Ok(new RespuestaDto { Exito = true, Mensaje = "Conductor modificado exitosamente.", Datos = conductorDto });
            }
            catch (Exception ex)
            {
                return BadRequest(new RespuestaDto { Exito = false, Mensaje = ex.Message, Datos = null });
            }
        }

        /// <summary>
        /// Elimina un conductor del sistema por su identificador.
        /// </summary>
        /// <param name="id">Identificador único del conductor a eliminar.</param>
        /// <returns>Respuesta con el resultado de la eliminación.</returns>
        [HttpDelete]
        public ActionResult<int> Eliminar(int id)
        {
            try
            {
                int resultado = _conductorServicio.Eliminar(id);
                return Ok(new RespuestaDto { Exito = true, Mensaje = "Conductor eliminado exitosamente.", Datos = resultado });
            }
            catch (Exception ex)
            {
                return BadRequest(new RespuestaDto { Exito = false, Mensaje = ex.Message, Datos = null });
            }
        }

        /// <summary>
        /// Consulta un conductor específico por su identificador.
        /// </summary>
        /// <param name="id">Identificador único del conductor a consultar.</param>
        /// <returns>Objeto <see cref="ConductorDto"/> con la información del conductor consultado.</returns>
        [HttpGet("{id}")]
        public ActionResult<ConductorDto> Consultar(int id)
        {
            try
            {
                ConductorFiltro filtro = new ConductorFiltro { IdConductor = id };
                ConductorDto conductorDto = _conductorServicio.Consultar(filtro);

                if (conductorDto == null)
                {
                    return NotFound(new RespuestaDto { Exito = false, Mensaje = "No se encontró el conductor solicitado.", Datos = null });
                }

                return Ok(new RespuestaDto { Exito = true, Mensaje = "Registro consultado exitosamente.", Datos = conductorDto });
            }
            catch (Exception ex)
            {
                return BadRequest(new RespuestaDto { Exito = false, Mensaje = ex.Message, Datos = null });
            }
        }

        /// <summary>
        /// Consulta una lista de conductores basados en los filtros proporcionados.
        /// </summary>
        /// <param name="filtro">Objeto <see cref="ConductorFiltro"/> con los criterios de búsqueda.</param>
        /// <returns>Lista de conductores encontrados.</returns>
        [HttpGet]
        public ActionResult<List<ConductorDto>> ConsultarLista([FromQuery] ConductorFiltro filtro)
        {
            try
            {
                List<ConductorDto> conductoresDto = _conductorServicio.ConsultarLista(filtro);

                if (conductoresDto == null || conductoresDto.Count == 0)
                {
                    return NotFound(new RespuestaDto { Exito = false, Mensaje = "No se encontró información.", Datos = null });
                }

                return Ok(new RespuestaDto { Exito = true, Mensaje = "Registros consultados exitosamente.", Datos = conductoresDto });
            }
            catch (Exception ex)
            {
                return BadRequest(new RespuestaDto { Exito = false, Mensaje = ex.Message, Datos = null });
            }
        }
    }
}
