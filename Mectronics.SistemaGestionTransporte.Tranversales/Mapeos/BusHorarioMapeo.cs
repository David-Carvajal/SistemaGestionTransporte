
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
                IdBusHorario = lector.GetInt32(0),  

                Bus = new Bus
                {
                    IdBus = lector.GetInt32(1),
                    Placa = lector.GetString(2),
                    Capacidad = lector.GetInt32(3),
                    Modelo = lector.GetString(4),
                },

                EstadoBus = new EstadoBus 
                {
                    IdEstadoBus = lector.GetInt32(5),
                    NombreEstadoBus = lector.GetString(6)
                },

                Fecha = lector.GetDateTime(7),  

                DiaSemana = lector.GetString(8), 

                HoraEntrada = lector.GetDateTime(9),  

                HoraSalida = lector.GetDateTime(10)   
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
                    Fecha = lector.GetDateTime(1),

                    DiaSemana = lector.GetString(2),

                    HoraEntrada = lector.GetDateTime(3),

                    HoraSalida = lector.GetDateTime(4),

                    Bus = new Bus
                    {
                        IdBus = lector.GetInt32(5),
                        Placa = lector.GetString(6),
                        Capacidad = lector.GetInt32(7),
                        Modelo = lector.GetString(8),
                    },

                    EstadoBus = new EstadoBus
                    {
                        IdEstadoBus = lector.GetInt32(9),
                        NombreEstadoBus = lector.GetString(10)
                    },

                    
                });
            }

            return horarios;  // Devuelve la lista de horarios de los buses
        }
    }
}
