
namespace Mectronics.SistemaGestionTransporte.Tranversales.Filtros
{
    /// <summary>
    /// Representa los criterios de filtrado para la búsqueda de roles.
    /// </summary>
    public class RolFiltro
    {
        /// <summary>
        /// Identificador único del rol que se desea filtrar.
        /// </summary>
        public int IdRol { get; set; }

        /// <summary>
        /// Nombre del rol que se desea filtrar.
        /// </summary>
        public string NombreRol { get; set; }

        /// <summary>
        /// Constructor de la clase <see cref="RolFiltro"/>.
        /// Inicializa una nueva instancia con valores predeterminados.
        /// </summary>
        public RolFiltro()
        {
            IdRol = 0;
            NombreRol = string.Empty;
        }
    }
}
