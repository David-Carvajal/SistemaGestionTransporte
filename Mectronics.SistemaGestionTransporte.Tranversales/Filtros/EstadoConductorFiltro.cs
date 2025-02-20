
namespace Mectronics.SistemaGestionTransporte.Tranversales.Filtros
{
    /// <summary>
    /// Representa los criterios de filtrado para la búsqueda de estados de conductores.
    /// </summary>
    public class EstadoConductorFiltro
    {
        /// <summary>
        /// Identificador único del estado del conductor que se desea filtrar.
        /// </summary>
        public int IdEstadoConductor { get; set; }

        /// <summary>
        /// Constructor de la clase <see cref="EstadoConductorFiltro"/>.
        /// Inicializa una nueva instancia con valores predeterminados.
        /// </summary>

        public EstadoConductorFiltro()
        {
            IdEstadoConductor = 0;
        }
    }
}
