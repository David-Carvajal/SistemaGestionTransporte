
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
                    EstadoBus = new EstadoBus
                    {
                        IdEstadoBus = lector.GetInt32(9),
                        NombreEstadoBus = lector.GetString(10)
                    }
                }
            };
        }

        /// <summary>
        /// Convierte un <see cref="IDataReader"/> en una lista de <see cref="BusHorario"/>.
        /// </summary>
        /// <param name="lector">El <see cref="IDataReader"/> con los datos.</param>
        /// <returns>Una lista de <see cref="BusHorario"/>.</returns>
        public static List<BusHorario> MapearLista(IDataReader lector)
        {
            var horarios = new List<BusHorario>();

            if (lector == null)
                return horarios;

            while (lector.Read())
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
                        EstadoBus = new EstadoBus
                        {
                            IdEstadoBus = lector.GetInt32(9),
                            NombreEstadoBus = lector.GetString(10)
                        }
                    },
                    NombreConductor = lector.GetString(11),
                });
            }

            return horarios;
        }
    }
}
