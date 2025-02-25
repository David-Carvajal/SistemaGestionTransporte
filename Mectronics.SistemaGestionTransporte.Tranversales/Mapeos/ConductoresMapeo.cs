
using Mectronics.SistemaGestionTransporte.Tranversales.Entidades;
using System.Data;

namespace Mectronics.SistemaGestionTransporte.Tranversales.Mapeos
{
    /// <summary>
    /// Clase responsable de mapear los datos de la base de datos a objetos de la entidad <see cref="Conductor"/>.
    /// </summary>
    public static class ConductorMapeo
    {
        /// <summary>
        /// Mapea un <see cref="IDataReader"/> a una instancia de <see cref="Conductor"/>.
        /// </summary>
        /// <param name="lector">El <see cref="IDataReader"/> con los datos.</param>
        /// <returns>Una instancia de <see cref="Conductor"/> o <c>null</c> si no hay datos.</returns>
        public static Conductor Mapear(IDataReader lector)
        {
            if (lector == null || !lector.Read()) 
                return null;

            return new Conductor
            {
                IdConductor = lector.GetInt32(0),
                NumeroLicencia = lector.GetString(1),
                EstadoConductor = new EstadoConductor
                {
                    IdEstadoConductor = lector.GetInt32(2),
                    NombreEstadoConductor =lector.GetString(3)
                },
                Usuario = new Usuario
                {
                    IdUsuario = lector.GetInt32(4),
                    Nombre = lector.GetString(5),
                    Correo = lector.GetString(6),
                    Rol = new Rol
                    {
                        IdRol = lector.GetInt32(7),
                        NombreRol = lector.GetString(8)
                    }
                }                
            };
        }

        /// <summary>
        /// Convierte un <see cref="IDataReader"/> en una lista de <see cref="Conductor"/>.
        /// </summary>
        /// <param name="lector">El <see cref="IDataReader"/> con los datos.</param>
        /// <returns>Una lista de <see cref="Conductor"/>.</returns>
        public static List<Conductor> MapearLista(IDataReader lector)
        {
            var conductores = new List<Conductor>(); // Lista vacía para almacenar conductores

            if (lector == null)
                return conductores;

            while (lector.Read()) 
            {
                conductores.Add(new Conductor
                {
                    IdConductor = lector.GetInt32(0),
                    NumeroLicencia = lector.GetString(1),
                    EstadoConductor = new EstadoConductor
                    {
                        IdEstadoConductor = lector.GetInt32(2),
                        NombreEstadoConductor = lector.GetString(3)
                    },
                    Usuario = new Usuario
                    {
                        IdUsuario = lector.GetInt32(4),
                        Nombre = lector.GetString(5),
                        Correo = lector.GetString(6),
                        Rol = new Rol
                        {
                            IdRol = lector.GetInt32(7),
                            NombreRol = lector.GetString(8)
                        }
                    }
                });
            }

            return conductores;
        }
    }
}