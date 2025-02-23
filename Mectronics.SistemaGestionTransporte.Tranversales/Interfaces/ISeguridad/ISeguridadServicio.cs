using Mectronics.SistemaGestionTransporte.Tranversales.Dtos;

namespace Mectronics.SistemaGestionTransporte.Tranversales.Interfaces.ISeguridad
{/// <summary>
 /// Interfaz que define los servicios relacionados con la seguridad y autenticación de usuarios.
 /// </summary>
    public interface ISeguridadServicio
    {
        /// <summary>
        /// Valida las credenciales de un usuario en el sistema.
        /// </summary>
        /// <param name="autenticacion">Objeto que contiene el correo y la contraseña del usuario.</param>
        /// <returns>Un objeto <see cref="UsuarioDto"/> con la información del usuario autenticado.</returns>
        /// <returns>Un objeto <see cref="UsuarioDto"/> con la información del usuario autenticado.</returns>
        UsuarioDto ValidarUsuario(AutenticacionDto autenticacion);
    }
}
