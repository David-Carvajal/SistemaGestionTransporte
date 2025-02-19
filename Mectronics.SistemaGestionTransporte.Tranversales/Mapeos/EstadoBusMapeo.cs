
using Mectronics.SistemaGestionTransporte.Tranversales.Entidades;
using System.Data;

namespace Mectronics.SistemaGestionTransporte.Tranversales.Mapeos
{
    /// <summary>
    /// Clase responsable de mapear los datos de la base de datos a objetos de la entidad <see cref="EstadoBus"/>.
    /// </summary>
    public static class EstadoBusMapeo
    {
        /// <summary>
        /// Mapea un <see cref="IDataReader"/> a una instancia de <see cref="EstadoBus"/>.
        /// </summary>
        /// <param name="lector">El <see cref="IDataReader"/> con los datos.</param>
        /// <returns>Una instancia de <see cref="EstadoBus"/> o <c>null</c> si no hay datos.</returns>
        public static EstadoBus Mapear(IDataReader lector)
        {
            if (lector == null || !lector.Read())
                return null;

            return new EstadoBus
            {
                IdEstadoBus = lector.GetInt32(0), // Identificador único del estado del bus (Columna 0)
                Estado = lector.GetString(1) // Descripción del estado del bus (Columna 1)
            };
        }

        /// <summary>
        /// Convierte un <see cref="IDataReader"/> en una lista de <see cref="EstadoBus"/>.
        /// </summary>
        /// <param name="lector">El <see cref="IDataReader"/> con los datos.</param>
        /// <returns>Una lista de <see cref="EstadoBus"/>.</returns>
        public static List<EstadoBus> MapearLista(IDataReader lector)
        {
            var estadobus = new List<EstadoBus>(); // Lista vacía para almacenar los estados del bus

            if (lector == null)
                return estadobus; // Si no hay datos, devuelve una lista vacía

            while (lector.Read()) // Mientras haya filas por leer...
            {
                estadobus.Add(new EstadoBus
                {
                    IdEstadoBus = lector.GetInt32(0),
                    Estado = lector.GetString(1)
                });
            }

            return estadobus; // Devuelve la lista de estados del bus
        }
    }
}
