
namespace Mectronics.SistemaGestionTransporte.Tranversales.Dtos
{
    /// <summary>
    /// Representa un usuario dentro del sistema de transporte.
    /// </summary>
    public class UsuarioDto
    {
        /// <summary>
        /// Identificador único del usuario.
        /// </summary>
        public int IdUsuario { get; set; }

        /// <summary>
        /// Nombre del usuario.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Correo electrónico del usuario.
        /// </summary>
        public string Correo { get; set; }

        /// <summary>
        /// Contraseña del Usuario
        /// </summary>
        public string Contrasena { get; set; }

        /// <summary>
        /// Rol asignado al usuario.
        /// </summary>
        public RolDto Rol { get; set; }
    }
}
