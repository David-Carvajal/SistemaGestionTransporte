
namespace Mectronics.SistemaGestionTransporte.Tranversales.Dtos
{
    /// <summary>
    /// Representa un rol dentro del sistema de transporte.
    /// </summary>
    public class RolDto
    {
        /// <summary>
        /// Identificador único del rol.
        /// </summary>
        public int IdRol { get; set; }

        /// <summary>
        /// Nombre del rol (Administrador, Conductor, etc.).
        /// </summary>
        public string NombreRol { get; set; }
    }
}
