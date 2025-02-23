
namespace Mectronics.SistemaGestionTransporte.Tranversales.Filtros
{
    /// <summary>
    /// Representa los criterios de filtrado para la búsqueda de conductores.
    /// </summary>
    public class ConductorFiltro
    {
        /// <summary>
        /// Identificador único del conductor que se desea filtrar.
        /// </summary>
        public int IdConductor { get; set; }

        /// <summary>
        /// Número de licencia del conductor que se desea filtrar.
        /// </summary>
        public string NumeroLicencia { get; set; }

        /// <summary>
        /// Identificador del estado del conductor que se desea filtrar.
        /// </summary>
        public int IdEstadoConductor { get; set; }

        /// <summary>
        /// Constructor de la clase <see cref="ConductoresFiltro"/>.
        /// Inicializa una nueva instancia con valores predeterminados.
        /// </summary>
        public ConductorFiltro()
        {
            IdConductor = 0;
            NumeroLicencia = string.Empty;
            IdEstadoConductor = 0;
        }
    }
}
