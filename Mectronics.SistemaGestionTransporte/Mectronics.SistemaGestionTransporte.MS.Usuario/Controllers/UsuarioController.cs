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
    [Route("api")]
    public class UsuarioControlador : ControllerBase
    {
        /// <summary>
        /// Instancia del servicio de usuario para manejar la lógica de negocio.
        /// </summary>
        private readonly IUsuarioServicio _usuarioServicio;

        /// <summary>
        /// Constructor que inicializa el controlador con una instancia del servicio de usuario.
        /// </summary>
        /// <param name="usuarioServicio">Instancia del servicio de usuario.</param>
        public UsuarioControlador(IUsuarioServicio usuarioServicio)
        {
            _usuarioServicio = usuarioServicio;
        }

        /// <summary>
        /// Endpoint para obtener un usuario específico basado en su identificador.
        /// </summary>
        /// <param name="id">Identificador único del usuario.</param>
        /// <returns>El usuario encontrado o un mensaje de error si no existe.</returns>
        [HttpGet("{id}")]
        public IActionResult Consultar(int id)
        {
            try
            {
                var usuario = _usuarioServicio.Consultar(new UsuarioFiltro { IdUsuario = id });
                if (usuario == null)
                {
                    return NotFound("Usuario no encontrado.");
                }
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        /// <summary>
        /// Endpoint para obtener una lista de usuarios según un filtro.
        /// </summary>
        /// <param name="filtro">Objeto con los criterios de búsqueda.</param>
        /// <returns>Lista de usuarios encontrados.</returns>
        [HttpGet]
        public IActionResult ConsultarLista([FromBody] UsuarioFiltro filtro)
        {
            try
            {
                var usuarios = _usuarioServicio.ConsultarLista(filtro);
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        /// <summary>
        /// Endpoint para insertar un nuevo usuario en la base de datos.
        /// </summary>
        /// <param name="usuarioDto">Objeto con la información del usuario a insertar.</param>
        /// <returns>Usuario creado.</returns>
        [HttpPost]
        public IActionResult Insertar([FromBody] UsuarioDto usuarioDto)
        {
            try
            {
                var usuarioCreado = _usuarioServicio.Insertar(usuarioDto);
                return CreatedAtAction(nameof(Consultar), new { id = usuarioCreado.IdUsuario }, usuarioCreado);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        /// <summary>
        /// Endpoint para actualizar un usuario existente en la base de datos.
        /// </summary>
        /// <param name="usuarioDto">Objeto con la información actualizada del usuario.</param>
        /// <returns>Usuario actualizado.</returns>
        [HttpPatch]
        public IActionResult Actualizar([FromBody] UsuarioDto usuarioDto)
        {
            try
            {
                var usuarioActualizado = _usuarioServicio.Actualizar(usuarioDto);
                return Ok(usuarioActualizado);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        /// <summary>
        /// Endpoint para eliminar un usuario basado en su identificador.
        /// </summary>
        /// <param name="id">Identificador único del usuario a eliminar.</param>
        /// <returns>Número de filas afectadas o mensaje de error.</returns>
        [HttpDelete("{id}")]
        public IActionResult Eliminar(int id)
        {
            try
            {
                var filasAfectadas = _usuarioServicio.Eliminar(id);
                if (filasAfectadas <= 0)
                {
                    return NotFound("Usuario no encontrado o no pudo ser eliminado.");
                }
                return Ok("Usuario eliminado correctamente.");
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }
    }

}
