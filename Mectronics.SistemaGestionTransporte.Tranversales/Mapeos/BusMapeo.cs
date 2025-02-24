
using Mectronics.SistemaGestionTransporte.Tranversales.Entidades;
using System.Data;
using System.Reflection;

namespace Mectronics.SistemaGestionTransporte.Tranversales.Mapeos
{
    /// <summary>
    /// Clase responsable de mapear los datos de la base de datos a objetos de la entidad <see cref="Bus"/>.
    /// </summary>
    public static class BusMapeo
    {
        /// <summary>
        /// Mapea un <see cref="IDataReader"/> a una instancia de <see cref="Bus"/>.
        /// </summary>
        /// <param name="lector">El <see cref="IDataReader"/> con los datos.</param>
        /// <returns>Una instancia de <see cref="Bus"/> o <c>null</c> si no hay datos.</returns>
        public static Bus Mapear(IDataReader lector)
        {
            if (lector == null || !lector.Read())
                return null;

            return new Bus
            {
                IdBus = lector.GetInt32(0),
                Modelo = lector.GetString(1),
                Capacidad = lector.GetInt32(2),
                Placa = lector.GetString(3),
                EstadoBus = new EstadoBus
                {
                    IdEstadoBus = Convert.ToInt32(lector.GetInt32(4)),
                    NombreEstadoBus = lector.GetString(5)
                }
            };
        }

        /// <summary>
        /// Convierte un <see cref="IDataReader"/> en una lista de <see cref="Bus"/>.
        /// </summary>
        /// <param name="lector">El <see cref="IDataReader"/> con los datos.</param>
        /// <returns>Una lista de <see cref="Bus"/>.</returns>
        public static List<Bus> MapearLista(IDataReader lector)
        {
            var buses = new List<Bus>();

            if (lector == null)
                return buses;

            while (lector.Read())
            {
                buses.Add(new Bus
                {
                    IdBus = lector.GetInt32(0),
                    Modelo = lector.GetString(1),
                    Capacidad = lector.GetInt32(2),
                    Placa = lector.GetString(3),
                    EstadoBus = new EstadoBus
                    {
                        IdEstadoBus = Convert.ToInt32(lector.GetInt32(4)),
                        NombreEstadoBus = lector.GetString(5)
                    }
                });
            }

            return buses;
        }
    }
}
