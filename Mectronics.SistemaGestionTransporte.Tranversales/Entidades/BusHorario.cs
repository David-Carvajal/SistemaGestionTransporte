
namespace Mectronics.SistemaGestionTransporte.Tranversales.Entidades
{
    public class BusHorario
    {
        /// <summary>
        /// Identificador único del horario del bus.
        /// </summary>
        public int IdBusHorario { get; set; }

        /// <summary>
        /// Bus asignado a este horario.
        /// </summary>
        public Bus Bus { get; set; }

        /// <summary>
        /// Fecha del horario asignado.
        /// </summary>
        public DateTime Fecha { get; set; }

        /// <summary>
        /// Día de la semana del horario.
        /// </summary>
        public string DiaSemana { get; set; }

        /// <summary>
        /// Hora de entrada del bus.
        /// </summary>
        public DateTime HoraEntrada { get; set; }

        /// <summary>
        /// Hora de salida del bus.
        /// </summary>
        public DateTime HoraSalida { get; set; }

        /// <summary>
        /// Nombre del conductor.
        /// </summary>
        public string NombreConductor { get; set; }

        public BusHorario()
        {
            IdBusHorario = 0;
            Bus = new Bus();
            Fecha = DateTime.MinValue;
            DiaSemana = string.Empty;
            HoraEntrada = DateTime.MinValue;
            HoraSalida = DateTime.MinValue;
            NombreConductor = string.Empty;
        }
    }
}
