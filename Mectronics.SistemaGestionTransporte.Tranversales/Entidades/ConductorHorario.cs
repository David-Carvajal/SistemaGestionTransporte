using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mectronics.SistemaGestionTransporte.Tranversales.Entidades
{
    public class ConductorHorario
    {
        /// <summary>
        /// Identificador único del horario del conductor.
        /// </summary>
        public int IdConductorHorario { get; set; }

        /// <summary>
        /// Conductor asignado a este horario.
        /// </summary>
        public Conductor Conductor { get; set; }

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
        public Bus Bus { get; set; }

        public ConductorHorario()
        {
            IdConductorHorario = 0;
            Conductor = new Conductor();
            Fecha = DateTime.MinValue;
            DiaSemana = string.Empty;
            HoraEntrada = DateTime.MinValue;
            HoraSalida = DateTime.MinValue;
            Bus = new Bus();
        }
    }
}
