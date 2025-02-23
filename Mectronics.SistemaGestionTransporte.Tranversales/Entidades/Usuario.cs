
namespace Mectronics.SistemaGestionTransporte.Tranversales.Entidades
{
    public class Usuario
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
        /// Contraseña del usuario (debe manejarse de forma segura).
        /// </summary>
        public string Contrasena { get; set; }

        /// <summary>
        /// Rol asignado al usuario.
        /// </summary>
        public Rol Rol { get; set; }

        public Usuario()
        {
            IdUsuario = 0;
            Nombre = string.Empty;
            Correo = string.Empty;
            Contrasena = string.Empty;
            Rol = new Rol();
        }
    }
}
