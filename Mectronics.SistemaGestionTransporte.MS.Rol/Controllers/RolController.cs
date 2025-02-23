using Mectronics.SistemaGestionTransporte.Tranversales.Dtos;
using Mectronics.SistemaGestionTransporte.Tranversales.Filtros;
using Mectronics.SistemaGestionTransporte.Tranversales.Interfaces.IRol;
using Microsoft.AspNetCore.Mvc;

namespace Mectronics.SistemaGestionTransporte.MS.Rol.Controllers
{
    [Route("api/Rol")]
    [ApiController]
    public class RolController : ControllerBase
    {
        /// <summary>
        /// Servicio de roles para manejar la lógica de negocio.
        /// </summary>
        private readonly IRolServicio _rolServicio;

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="RolController"/> con el servicio inyectado.
        /// </summary>
        /// <param name="rolServicio">Instancia del servicio de roles.</param>
        public RolController(IRolServicio rolServicio)
        {
            _rolServicio = rolServicio;
        }

        /// <summary>
        /// Consulta un rol específico por su identificador.
        /// </summary>
        /// <param name="id">Identificador único del rol a consultar.</param>
        /// <returns>Objeto <see cref="RolDto"/> con la información del rol consultado.</returns>
        [HttpGet]
        public ActionResult<RolDto> Consultar(int id)
        {
            try
            {
                RolFiltro filtro = new RolFiltro { IdRol = id };
                RolDto rolDto = _rolServicio.Consultar(filtro);

                if (rolDto == null)
                {
                    return NotFound(new RespuestaDto { Exito = false, Mensaje = "No se encontró el rol solicitado.", Datos = null });
                }

                return Ok(new RespuestaDto { Exito = true, Mensaje = "Registro consultado exitosamente.", Datos = rolDto });
            }
            catch (Exception ex)
            {
                return BadRequest(new RespuestaDto { Exito = false, Mensaje = ex.Message, Datos = null });
            }
        }
    }
}