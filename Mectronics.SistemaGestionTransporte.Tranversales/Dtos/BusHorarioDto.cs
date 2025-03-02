﻿
namespace Mectronics.SistemaGestionTransporte.Tranversales.Dtos
{
    /// <summary>
    /// Representa el horario de un bus en el sistema de transporte.
    /// </summary>
    public class BusHorarioDto
    {
        /// <summary>
        /// Identificador único del horario del bus.
        /// </summary>
        public int IdBusHorario { get; set; }

        /// <summary>
        /// Fecha del horario asignado.
        /// </summary>
        public DateTime Fecha { get; set; }

        /// <summary>
        /// Día de la semana correspondiente al horario.
        /// </summary>
        public string DiaSemana { get; set; }

        /// <summary>
        /// Hora de entrada del bus.
        /// </summary>
        public DateTime? HoraEntrada { get; set; }

        /// <summary>
        /// Hora de salida del bus.
        /// </summary>
        public DateTime? HoraSalida { get; set; }

        /// <summary>
        /// Hora de entrada del bus.
        /// </summary>
        public string HoraEntradaTexto { get; set; }

        /// <summary>
        /// Hora de salida del bus.
        /// </summary>
        public string HoraSalidaTexto { get; set; }

        /// <summary>
        /// Identificador único del conductor.
        /// </summary>
        public int IdConductor { get; set; }

        /// <summary>
        /// Nombre del conductor.
        /// </summary>
        public string NombreConductor { get; set; }

        /// <summary>
        /// Bus asignado a este horario.
        /// </summary>
        public BusDto Bus { get; set; }        
    }
}
