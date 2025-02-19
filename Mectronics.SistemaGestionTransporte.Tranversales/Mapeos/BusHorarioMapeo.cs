
using Mectronics.SistemaGestionTransporte.Tranversales.Entidades;
using System.Data;

namespace Mectronics.SistemaGestionTransporte.Tranversales.Mapeos
{
    /// <summary>
    /// Clase responsable de mapear los datos de la base de datos a objetos de la entidad <see cref="BusHorario"/>.
    /// </summary>
    public static class BusHorarioMapeo
    {
        /// <summary>
        /// Mapea un <see cref="IDataReader"/> a una instancia de <see cref="BusHorario"/>.
        /// </summary>
        /// <param name="lector">El <see cref="IDataReader"/> con los datos.</param>
        /// <returns>Una instancia de <see cref="BusHorario"/> o <c>null</c> si no hay datos.</returns>
        public static BusHorario Mapear(IDataReader lector)
        {
            if (lector == null || !lector.Read())
                return null;

            return new BusHorario
            {
                IdBusHorario = lector.GetInt32(0),  // Obtiene el IdBusHorario (Columna 0)

                Bus = new Bus
                {
                    IdBus = lector.GetInt32(1) // Obtiene el IdBus asociado (Columna 1)
                },

                Fecha = lector.GetDateTime(2),  // Obtiene la Fecha (Columna 2)

                DiaSemana = lector.GetString(3), // Obtiene los Días de la semana (Columna 3)

                HoraEntrada = lector.GetDateTime(4),  // Obtiene HoraEntrada como DateTime (Columna 4)

                HoraSalida = lector.GetDateTime(5)   // Obtiene HoraSalida como DateTime (Columna 5)
            };
        }

        /// <summary>
        /// Convierte un <see cref="IDataReader"/> en una lista de <see cref="BusHorario"/>.
        /// </summary>
        /// <param name="lector">El <see cref="IDataReader"/> con los datos.</param>
        /// <returns>Una lista de <see cref="BusHorario"/>.</returns>
        public static List<BusHorario> MapearLista(IDataReader lector)
        {
            var horarios = new List<BusHorario>();   // Lista vacía para almacenar los horarios de los buses

            if (lector == null)
                return horarios;   // Si no hay datos, devuelve una lista vacía

            while (lector.Read())   // Mientras haya filas por leer...
            {
                horarios.Add(new BusHorario
                {
                    IdBusHorario = lector.GetInt32(0),

                    Bus = new Bus
                    {
                        IdBus = lector.GetInt32(1)
                    },

                    Fecha = lector.GetDateTime(2),

                    DiaSemana = lector.GetString(3),

                    HoraEntrada = lector.GetDateTime(4),

                    HoraSalida = lector.GetDateTime(5)
                });
            }

            return horarios;  // Devuelve la lista de horarios de los buses
        }
    }
}
