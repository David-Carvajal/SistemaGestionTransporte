using Mectronics.SistemaGestionTransporte.Tranversales.Dtos;
using Mectronics.SistemaGestionTransporte.Tranversales.Filtros;
using Mectronics.SistemaGestionTransporte.Tranversales.Interfaces.IConductor;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mectronics.SistemaGestionTransporte.MS.Conductor.Controllers
{

    /// <summary>
    /// Controlador para gestionar las operaciones relacionadas con la entidad <see cref="Conductor"/>.
    /// </summary>
    [ApiController]
    [Route("api/")]
    public class ConductorControlador : ControllerBase
    {
        private readonly IConductorServicio _conductorServicio;

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="ConductorControlador"/> con un servicio inyectado.
        /// </summary>
        /// <param name="conductorServicio">Instancia del servicio de conductores.</param>
        public ConductorControlador(IConductorServicio conductorServicio)
        {
            _conductorServicio = conductorServicio;
        }

        /// <summary>
        /// Inserta un nuevo conductor en la base de datos.
        /// </summary>
        /// <param name="conductorDto">Objeto <see cref="ConductorDto"/> con la información a insertar.</param>
        /// <returns>Información del conductor insertado.</returns>
        [HttpPost]
        public IActionResult Insertar([FromBody] ConductorDto conductorDto)
        {
            try
            {
                var resultado = _conductorServicio.Insertar(conductorDto);
                return CreatedAtAction(nameof(Consultar), new { id = resultado.IdConductor }, resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        /// <summary>
        /// Actualiza un conductor existente en la base de datos.
        /// </summary>
        /// <param name="conductorDto">Objeto <see cref="ConductorDto"/> con la información actualizada.</param>
        /// <returns>Información del conductor actualizado.</returns>
        [HttpPatch]
        public IActionResult Actualizar([FromBody] ConductorDto conductorDto)
        {
            try
            {
                var resultado = _conductorServicio.Actualizar(conductorDto);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        /// <summary>
        /// Elimina un conductor por su identificador.
        /// </summary>
        /// <param name="id">Identificador único del conductor a eliminar.</param>
        /// <returns>Resultado de la operación.</returns>
        [HttpDelete("{id}")]
        public IActionResult Eliminar(int id)
        {
            try
            {
                var resultado = _conductorServicio.Eliminar(id);
                if (resultado > 0)
                    return Ok(new { mensaje = "Conductor eliminado correctamente." });
                else
                    return NotFound(new { mensaje = "No se encontró el conductor." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        /// <summary>
        /// Consulta un conductor basado en los filtros proporcionados.
        /// </summary>
        /// <param name="id">Identificador único del conductor.</param>
        /// <returns>Registro del conductor encontrado.</returns>
        [HttpGet("{id}")]
        public IActionResult Consultar(int id)
        {
            try
            {
                var filtro = new ConductorFiltro { IdConductores = id };
                var resultado = _conductorServicio.Consultar(filtro);
                if (resultado != null)
                    return Ok(resultado);
                else
                    return NotFound(new { mensaje = "Conductor no encontrado." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        /// <summary>
        /// Consulta una lista de conductores según los filtros proporcionados.
        /// </summary>
        /// <param name="filtro">Objeto <see cref="ConductorFiltro"/> con los criterios de búsqueda.</param>
        /// <returns>Lista de conductores encontrados.</returns>
        [HttpGet]
        public IActionResult ConsultarLista([FromQuery] ConductorFiltro filtro)
        {
            try
            {
                var resultado = _conductorServicio.ConsultarLista(filtro);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }
    }
}
