
namespace Mectronics.SistemaGestionTransporte.Tranversales.Dtos
{
    /// <summary>
    /// Representa un horario asignado a un conductor en el sistema de transporte.
    /// </summary>
    public class ConductorHorarioDto
    {
        /// <summary>
        /// Identificador único del horario del conductor.
        /// </summary>
        public int IdConductorHorario { get; set; }

        /// <summary>
        /// Conductor asignado a este horario.
        /// </summary>
        public ConductorDto Conductor { get; set; }

        /// <summary>
        /// Fecha del horario asignado.
        /// </summary>
        public DateTime Fecha { get; set; }

        /// <summary>
        /// Día de la semana del horario.
        /// </summary>
        public string DiaSemana { get; set; }

        /// <summary>
        /// Hora de entrada del conductor.
        /// </summary>
        public DateTime HoraEntrada { get; set; }

        /// <summary>
        /// Hora de salida del conductor.
        /// </summary>
        public DateTime HoraSalida { get; set; }

        /// <summary>
        /// Bus asignado a este horario.
        /// </summary>
        public BusDto Bus { get; set; }
    }
}
