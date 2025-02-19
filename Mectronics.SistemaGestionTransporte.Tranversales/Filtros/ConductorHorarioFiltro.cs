
namespace Mectronics.SistemaGestionTransporte.Tranversales.Filtros
{
    /// <summary>
    /// Representa los criterios de filtrado para la búsqueda de horarios de conductores.
    /// </summary>
    public class ConductorHorarioFiltro
    {
        /// <summary>
        /// Identificador único del horario del conductor que se desea filtrar.
        /// </summary>
        public int IdConductorHorario { get; set; }

        /// <summary>
        /// Identificador único del conductor asociado al horario.
        /// </summary>
        public int IdConductor { get; set; }

        /// <summary>
        /// Fecha específica del horario que se desea filtrar.
        /// </summary>
        public DateTime Fecha { get; set; }

        /// <summary>
        /// Día de la semana del horario que se desea filtrar.
        /// </summary>
        public string DiaSemana { get; set; }

        /// <summary>
        /// Constructor de la clase <see cref="ConductorHorarioFiltro"/>.
        /// Inicializa una nueva instancia con valores predeterminados.
        /// </summary>
        public ConductorHorarioFiltro()
        {
            IdConductorHorario = 0;
            IdConductor = 0;
            Fecha = DateTime.MinValue;
            DiaSemana = string.Empty;
        }
    }
}
