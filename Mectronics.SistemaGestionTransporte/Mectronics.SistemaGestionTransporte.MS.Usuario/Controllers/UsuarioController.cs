using Mectronics.SistemaGestionTransporte.Tranversales.Dtos;
using Mectronics.SistemaGestionTransporte.Tranversales.Filtros;
using Mectronics.SistemaGestionTransporte.Tranversales.Interfaces.IUsuario;
using Microsoft.AspNetCore.Mvc;

namespace Mectronics.SistemaGestionTransporte.MS.Usuario.Controllers
{
    /// <summary>
    /// Controlador para gestionar las operaciones sobre la entidad <see cref="Usuario"/>.
    /// </summary>
    [ApiController]
    [Route("api/Usuario")]
    public class UsuarioController : ControllerBase
    {
        /// <summary>
        /// Servicio de usuario para manejar la lógica de negocio.
        /// </summary>
        private readonly IUsuarioServicio _usuarioServicio;

        /// <summary>
        /// Inicializa una nueva instancia del <see cref="UsuarioController"/> con el servicio inyectado.
        /// </summary>
        /// <param name="usuarioServicio">Instancia del servicio de horarios de buses.</param>
        public UsuarioController(IUsuarioServicio usuarioServicio)
        {
            _usuarioServicio = usuarioServicio;
        }

        /// <summary>
        /// Consulta un usuario específico por su identificador.
        /// </summary>
        /// <param name="id">Identificador único del usuario.</param>
        /// <returns>Objeto <see cref="UsuarioDto"/> con la información del bus consultado.</returns>
        /// <returns>El usuario encontrado o un mensaje de error si no existe.</returns>
        [HttpGet]
        public IActionResult Consultar(int id)
        {
            try
            {
                UsuarioFiltro filtro = new UsuarioFiltro { IdUsuario = id };
                UsuarioDto usuarioDto = _usuarioServicio.Consultar(filtro);
                if (usuarioDto == null)
                {
                    return NotFound(new RespuestaDto { Exito = false, Mensaje = "No se encontro el usuario Solicitado.", Datos = null });
                }
                return Ok(new RespuestaDto { Exito = true, Mensaje = "Registro consultado correctamente.", Datos = usuarioDto });
            }
            catch (Exception ex)
            {
                return BadRequest(new RespuestaDto { Exito = false, Mensaje = ex.Message, Datos = null });
            }
        }

        /// <summary>
        /// Consulta una lista de usuarios basados en los filtros proporcionados.
        /// </summary>
        /// <param name="filtro">Objeto <see cref="UsuarioFiltro"/> con los criterios de búsqueda.</param>
        /// <returns>Lista de usuarios encontrados.</returns>
        [HttpGet]
        public ActionResult<List<BusDto>> ConsultarLista([FromQuery] UsuarioFiltro filtro)
        {
            try
            {
                List<UsuarioDto> usuarioDto = _usuarioServicio.ConsultarLista(filtro);
                if (usuarioDto == null || usuarioDto.Count == 0)
                {
                    return NotFound(new RespuestaDto { Exito = false, Mensaje = "No se encontro informacion.", Datos = null });
                }

                return Ok(new RespuestaDto { Exito = true, Mensaje = "Registros Consultados exitosamente.", Datos = usuarioDto });

            }
            catch (Exception ex)
            {
                return BadRequest(new RespuestaDto { Exito = false, Mensaje = ex.Message, Datos = null });
            }
        }

        /// <summary>
        /// Crea un nuevo usuario en el sistema.
        /// </summary>
        /// <param name="usuarioDto">Objeto <see cref="UsuarioDto"/> con la información del usuario a insertar.</param>
        /// <returns>Respuesta con el usuario creado.</returns>
        [HttpPost]
        public ActionResult<int> Insertar([FromBody] UsuarioDto usuarioDto)
        {
            try
            {
                usuarioDto = _usuarioServicio.Insertar(usuarioDto);
                return Ok(new RespuestaDto { Exito = true, Mensaje = "Usuario creado exotosamente.", Datos = usuarioDto });
            }
            catch (Exception ex)
            {
                return BadRequest(new RespuestaDto{ Exito = false, Mensaje= ex.Message, Datos = null});
            }
        }

        /// <summary>
        /// Actualiza un usuario existente en la base de datos.
        /// </summary>
        /// <param name="usuarioDto">Objeto <see cref="UsuarioDto"/>con la información actualizada del usuario.</param>
        /// <returns>Respuesta Usuario actualizado.</returns>
        [HttpPatch]
        public ActionResult<int> Actualizar([FromBody] UsuarioDto usuarioDto)
        {
            try
            {
                _usuarioServicio.Actualizar(usuarioDto);
                return Ok(new RespuestaDto { Exito = true, Mensaje = "Usuario actualizado exitosamente.", Datos = usuarioDto });
            }
            catch (Exception ex)
            {
                return BadRequest(new RespuestaDto { Exito= false, Mensaje = ex.Message, Datos = null});
            }
        }

        /// <summary>
        /// Endpoint para eliminar un usuario basado en su identificador.
        /// </summary>
        /// <param name="id">Identificador único del usuario a eliminar.</param>
        /// <returns>Número de filas afectadas o mensaje de error.</returns>
        [HttpDelete]
        public ActionResult<int> Eliminar(int id)
        {
            try
            {
                int resultado = _usuarioServicio.Eliminar(id);
                return Ok(new RespuestaDto { Exito = true, Mensaje = "Usuario Eliminado Exitosamente.", Datos = resultado });

            }
            catch (Exception ex)
            {
                return BadRequest(new RespuestaDto { Exito = false, Mensaje = ex.Message, Datos = null });
            }
        }
    }

}
