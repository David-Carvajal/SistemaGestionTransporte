
using Mectronics.SistemaGestionTransporte.Tranversales.Entidades;
using System.Data;

namespace Mectronics.SistemaGestionTransporte.Tranversales.Mapeos
{
    /// <summary>
    /// Clase responsable de mapear los datos de la base de datos a objetos de la entidad <see cref="ConductorHorario"/>.
    /// </summary>
    public static class ConductorHorarioMapeo
    {
        /// <summary>
        /// Mapea un <see cref="IDataReader"/> a una instancia de <see cref="ConductorHorario"/>.
        /// </summary>
        /// <param name="lector">El <see cref="IDataReader"/> con los datos.</param>
        /// <returns>Una instancia de <see cref="ConductorHorario"/> o <c>null</c> si no hay datos.</returns>
        public static ConductorHorario Mapear(IDataReader lector)
        {
            if (lector == null || !lector.Read())
                return null;

            return new ConductorHorario
            {
                IdConductorHorario = lector.GetInt32(0), // Identificador único del horario (Columna 0)

                Conductor = new Conductor
                {
                    IdConductor = lector.GetInt32(1) // Conductor asignado (Columna 1)
                },

                Fecha = lector.GetDateTime(2), // Fecha del horario (Columna 2)

                DiaSemana = lector.GetString(3), // Día de la semana (Columna 3)

                HoraEntrada = lector.GetDateTime(4), // Hora de entrada (Columna 4)

                HoraSalida = lector.GetDateTime(5), // Hora de salida (Columna 5)

                Bus = new Bus
                {
                    IdBus = lector.GetInt32(6) // Bus asignado (Columna 6)
                }
            };
        }

        /// <summary>
        /// Convierte un <see cref="IDataReader"/> en una lista de <see cref="ConductorHorario"/>.
        /// </summary>
        /// <param name="lector">El <see cref="IDataReader"/> con los datos.</param>
        /// <returns>Una lista de <see cref="ConductorHorario"/>.</returns>
        public static List<ConductorHorario> MapearLista(IDataReader lector)
        {
            var horarios = new List<ConductorHorario>(); // Lista vacía para almacenar los horarios

            if (lector == null)
                return horarios; // Si no hay datos, devuelve una lista vacía

            while (lector.Read()) // Mientras haya filas por leer...
            {
                horarios.Add(new ConductorHorario
                {
                    IdConductorHorario = lector.GetInt32(0),

                    Conductor = new Conductor
                    {
                        IdConductor = lector.GetInt32(1)
                    },

                    Fecha = lector.GetDateTime(2),

                    DiaSemana = lector.GetString(3),

                    HoraEntrada = lector.GetDateTime(4),

                    HoraSalida = lector.GetDateTime(5),

                    Bus = new Bus
                    {
                        IdBus = lector.GetInt32(6)
                    }
                });
            }

            return horarios; // Devuelve la lista de horarios
        }
    }
}
