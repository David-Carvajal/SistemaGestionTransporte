
namespace Mectronics.SistemaGestionTransporte.Tranversales.Filtros
{
    /// <summary>
    /// Representa los criterios de filtrado para la búsqueda de estados de buses.
    /// </summary>
    public class EstadoBusFiltro
    {
        /// <summary>
        /// Identificador único del estado del bus que se desea filtrar.
        /// </summary>
        public int IdEstadoBus { get; set; }

        /// <summary>
        /// Constructor de la clase <see cref="EstadoBusFiltro"/>.
        /// Inicializa una nueva instancia con valores predeterminados.
        /// </summary>

        public EstadoBusFiltro()
        {
            IdEstadoBus = 0;
            
        }
    }
}
