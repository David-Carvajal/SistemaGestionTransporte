
namespace Mectronics.SistemaGestionTransporte.Tranversales.Filtros
{
    /// <summary>
    /// Representa los criterios de filtrado para la búsqueda de horarios de buses.
    /// </summary>
    public class BusHorarioFiltro
    {
        /// <summary>
        /// Identificador único del horario de bus que se desea filtrar.
        /// </summary>
        public int IdBusHorario { get; set; }

        /// <summary>
        /// Fecha específica del horario que se desea filtrar.
        /// </summary>
        public DateTime Fecha { get; set; }

        /// <summary>
        /// Día de la semana del horario que se desea filtrar.
        /// </summary>
        public string DiaSemana { get; set; }

        /// <summary>
        /// Constructor de la clase <see cref="BusHorarioFiltro"/>.
        /// Inicializa una nueva instancia con valores predeterminados.
        /// </summary>
        public BusHorarioFiltro()
        {
            IdBusHorario = 0;
            Fecha = DateTime.MinValue;
            DiaSemana = string.Empty;
        }
    }
}
