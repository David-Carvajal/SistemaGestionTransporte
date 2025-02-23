
namespace Mectronics.SistemaGestionTransporte.Tranversales.Filtros
{
    /// <summary>
    /// Representa los criterios de filtrado para la búsqueda de usuarios.
    /// </summary>
    public class UsuarioFiltro
    {
        /// <summary>
        /// Identificador único del usuario que se desea filtrar.
        /// </summary>
        public int IdUsuario { get; set; }

        /// <summary>
        /// Nombre del usuario que se desea filtrar.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Correo del usuario que se desea filtrar.
        /// </summary>
        public string Correo { get; set; }

        /// <summary>
        /// Identificador único del rol asociado al usuario.
        /// </summary>
        public int IdRol { get; set; }

        /// <summary>
        /// Constructor de la clase <see cref="UsuarioFiltro"/>.
        /// Inicializa una nueva instancia con valores predeterminados.
        /// </summary>
        public UsuarioFiltro()
        {
            IdUsuario = 0;
            Nombre = string.Empty;
            IdRol = 0;
        }
    }
}
