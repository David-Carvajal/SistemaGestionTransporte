using Mectronics.SistemaGestionTransporte.Tranversales.Dtos;
using Mectronics.SistemaGestionTransporte.Tranversales.Interfaces.ISeguridad;
using Microsoft.AspNetCore.Mvc;

namespace Mectronics.SistemaGestionTransporte.MS.Seguridad.Controllers
{/// <summary>
 /// Controlador para gestionar la autenticación de usuarios en la API.
 /// </summary>
    [Route("api/Autenticacion")] // Define la ruta base del controlador en la API
    [ApiController] // Indica que este controlador maneja respuestas automáticas de validación de modelos y serialización
    public class AutenticacionController : ControllerBase
    {
        /// <summary>
        /// Servicio de seguridad que maneja la lógica de autenticación.
        /// </summary>
        private readonly ISeguridadServicio _seguridadServicio;

        /// <summary>
        /// Constructor del controlador que recibe el servicio de seguridad por inyección de dependencias.
        /// </summary>
        /// <param name="seguridadServicio">Instancia del servicio de seguridad.</param>
        public AutenticacionController(ISeguridadServicio seguridadServicio)
        {
            _seguridadServicio = seguridadServicio;
        }

        /// <summary>
        /// Valida las credenciales del usuario y devuelve sus datos si la autenticación es exitosa.
        /// </summary>
        /// <param name="autenticacion">Objeto que contiene el correo y la contraseña del usuario.</param>
        /// <returns>Un objeto <see cref="UsuarioDto"/> con la información del usuario autenticado.</returns>
        [HttpPost] // Define que este método responderá a solicitudes HTTP POST
        public ActionResult<UsuarioDto> Validar([FromBody] AutenticacionDto autenticacion)
        {
            try
            {
                // Llama al servicio para validar las credenciales del usuario
                UsuarioDto usuarioDto = _seguridadServicio.ValidarUsuario(autenticacion);

                // Devuelve una respuesta exitosa con los datos del usuario autenticado
                return Ok(new RespuestaDto
                {
                    Exito = true,
                    Mensaje = "Autenticación exitosa.",
                    Datos = usuarioDto
                });

            }
            catch (Exception ex)
            {
                // Devuelve una respuesta de error si ocurre una excepción en la autenticación
                return BadRequest(new RespuestaDto
                {
                    Exito = false,
                    Mensaje = ex.Message,
                    Datos = null
                });
            }
        }
    }
}
