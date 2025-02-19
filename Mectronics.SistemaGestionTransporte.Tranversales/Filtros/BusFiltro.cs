
namespace Mectronics.SistemaGestionTransporte.Tranversales.Filtros
{
    /// <summary>
    /// Representa los criterios de filtrado para la búsqueda de buses.
    /// </summary>
    public class BusFiltro
    {
        /// <summary>
        /// Identificador único del bus que se desea filtrar.
        /// </summary>
        public int IdBus { get; set; }

        /// <summary>
        /// Modelo del bus que se desea filtrar.
        /// </summary>
        public int Modelo { get; set; }

        /// <summary>
        /// Placa del bus que se desea filtrar.
        /// </summary>
        public string Placa { get; set; }

        /// <summary>
        /// Identificador del estado del bus que se desea filtrar.
        /// </summary>
        public int IdEstado { get; set; }

        /// <summary>
        /// Constructor de la clase <see cref="BusFiltro"/>.
        /// Inicializa una nueva instancia con valores predeterminados.
        /// </summary>
        public BusFiltro()
        {
            IdBus = 0;
            Modelo = 0;
            Placa = string.Empty;
            IdEstado = 0;
        }
    }
}
