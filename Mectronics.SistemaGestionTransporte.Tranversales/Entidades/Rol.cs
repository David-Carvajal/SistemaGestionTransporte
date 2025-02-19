
namespace Mectronics.SistemaGestionTransporte.Tranversales.Entidades
{
    public class Rol
    {
        /// <summary>
        /// Identificador único del rol.
        /// </summary>
        public int IdRol { get; set; }

        /// <summary>
        /// Nombre del rol (Administrador, Conductor, etc.).
        /// </summary>
        public string NombreRol { get; set; }
        public Rol()
        {
            IdRol = 0;
            NombreRol = string.Empty;
        }
    }
}
