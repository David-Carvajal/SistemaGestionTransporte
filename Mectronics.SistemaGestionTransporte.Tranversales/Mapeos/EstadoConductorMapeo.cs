
using Mectronics.SistemaGestionTransporte.Tranversales.Entidades;
using System.Data;

namespace Mectronics.SistemaGestionTransporte.Tranversales.Mapeos
{
    /// <summary>
    /// Clase responsable de mapear los datos de la base de datos a objetos de la entidad <see cref="EstadoConductor"/>.
    /// </summary>
    public static class EstadoConductorMapeo
    {
        /// <summary>
        /// Mapea un <see cref="IDataReader"/> a una instancia de <see cref="EstadoConductor"/>.
        /// </summary>
        /// <param name="lector">El <see cref="IDataReader"/> con los datos.</param>
        /// <returns>Una instancia de <see cref="EstadoConductor"/> o <c>null</c> si no hay datos.</returns>
        public static EstadoConductor Mapear(IDataReader lector)
        {
            if (lector == null || !lector.Read())
                return null;

            return new EstadoConductor
            {
                IdEstadoConductor = lector.GetInt32(0), // Identificador único del estado del conductor (Columna 0)
                NombreEstadoConductor = lector.GetString(1) // Descripción del estado del conductor (Columna 1)
            };
        }

        /// <summary>
        /// Convierte un <see cref="IDataReader"/> en una lista de <see cref="EstadoConductor"/>.
        /// </summary>
        /// <param name="lector">El <see cref="IDataReader"/> con los datos.</param>
        /// <returns>Una lista de <see cref="EstadoConductor"/>.</returns>
        public static List<EstadoConductor> MapearLista(IDataReader lector)
        {
            var estados = new List<EstadoConductor>(); // Lista vacía para almacenar los estados del conductor

            if (lector == null)
                return estados; // Si no hay datos, devuelve una lista vacía

            while (lector.Read()) // Mientras haya filas por leer...
            {
                estados.Add(new EstadoConductor
                {
                    IdEstadoConductor = lector.GetInt32(0),
                    NombreEstadoConductor = lector.GetString(1)
                });
            }

            return estados; // Devuelve la lista de estados del conductor
        }
    }
}
