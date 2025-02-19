
using Mectronics.SistemaGestionTransporte.Tranversales.Entidades;
using System.Data;

namespace Mectronics.SistemaGestionTransporte.Tranversales.Mapeos
{
    /// <summary>
    /// Clase responsable de mapear los datos de la base de datos a objetos de la entidad <see cref="Usuario"/>.
    /// </summary>
    public static class UsuarioMapeo
    {
        /// <summary>
        /// Mapea un <see cref="IDataReader"/> a una instancia de <see cref="Usuario"/>.
        /// </summary>
        /// <param name="lector">El <see cref="IDataReader"/> con los datos.</param>
        /// <returns>Una instancia de <see cref="Usuario"/> o <c>null</c> si no hay datos.</returns>
        public static Usuario Mapear(IDataReader lector)
        {
            if (lector == null || !lector.Read())
                return null;

            return new Usuario
            {
                IdUsuario = lector.GetInt32(0), // Identificador único del usuario (Columna 0)
                Nombre = lector.GetString(1),   // Nombre del usuario (Columna 1)
                Correo = lector.GetString(2),   // Correo electrónico (Columna 2)
                Contraseña = lector.GetString(3), // Contraseña del usuario (Columna 3) - Debe manejarse con seguridad
                Rol = new Rol
                {
                    IdRol = lector.GetInt32(4),  // Identificador del rol (Columna 4)
                    NombreRol = lector.GetString(5) // Nombre del rol asociado (Columna 5)
                }
            };
        }

        /// <summary>
        /// Convierte un <see cref="IDataReader"/> en una lista de <see cref="Usuario"/>.
        /// </summary>
        /// <param name="lector">El <see cref="IDataReader"/> con los datos.</param>
        /// <returns>Una lista de <see cref="Usuario"/>.</returns>
        public static List<Usuario> MapearLista(IDataReader lector)
        {
            var usuarios = new List<Usuario>(); // Lista vacía para almacenar los usuarios

            if (lector == null)
                return usuarios; // Si no hay datos, devuelve una lista vacía

            while (lector.Read()) // Mientras haya filas por leer...
            {
                usuarios.Add(new Usuario
                {
                    IdUsuario = lector.GetInt32(0),
                    Nombre = lector.GetString(1),
                    Correo = lector.GetString(2),
                    Contraseña = lector.GetString(3),
                    Rol = new Rol
                    {
                        IdRol = lector.GetInt32(4),
                        NombreRol = lector.GetString(5)
                    }
                });
            }

            return usuarios; // Devuelve la lista de usuarios
        }
    }
}
