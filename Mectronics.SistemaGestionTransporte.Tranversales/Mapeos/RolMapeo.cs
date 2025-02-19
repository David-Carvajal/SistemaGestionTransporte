
using Mectronics.SistemaGestionTransporte.Tranversales.Entidades;
using System.Data;

namespace Mectronics.SistemaGestionTransporte.Tranversales.Mapeos
{
    /// <summary>
    /// Clase responsable de mapear los datos de la base de datos a objetos de la entidad <see cref="Rol"/>.
    /// </summary>
    public static class RolMapeo
    {
        /// <summary>
        /// Mapea un <see cref="IDataReader"/> a una instancia de <see cref="Rol"/>.
        /// </summary>
        /// <param name="lector">El <see cref="IDataReader"/> con los datos.</param>
        /// <returns>Una instancia de <see cref="Rol"/> o <c>null</c> si no hay datos.</returns>
        public static Rol Mapear(IDataReader lector)
        {
            if (lector == null || !lector.Read())
                return null;

            return new Rol
            {
                IdRol = lector.GetInt32(0), // Identificador único del rol (Columna 0)
                NombreRol = lector.GetString(1) // Nombre del rol (Administrador, Conductor, etc.) - (Columna 1)
            };
        }

        /// <summary>
        /// Convierte un <see cref="IDataReader"/> en una lista de <see cref="Rol"/>.
        /// </summary>
        /// <param name="lector">El <see cref="IDataReader"/> con los datos.</param>
        /// <returns>Una lista de <see cref="Rol"/>.</returns>
        public static List<Rol> MapearLista(IDataReader lector)
        {
            var roles = new List<Rol>(); // Lista vacía para almacenar los roles

            if (lector == null)
                return roles; // Si no hay datos, devuelve una lista vacía

            while (lector.Read()) // Mientras haya filas por leer...
            {
                roles.Add(new Rol
                {
                    IdRol = lector.GetInt32(0),
                    NombreRol = lector.GetString(1)
                });
            }

            return roles; // Devuelve la lista de roles
        }
    }
}
