
using Mectronics.SistemaGestionTransporte.Tranversales.Entidades;
using Mectronics.SistemaGestionTransporte.Tranversales.Filtros;
using Mectronics.SistemaGestionTransporte.Tranversales.Interfaces.IRol;
using Mectronics.SistemaGestionTransporte.Tranversales.Interfaces;
using Mectronics.SistemaGestionTransporte.Tranversales.Mapeos;
using System.Data;

namespace Mectronics.SistemaGestionTransporte.Repositorio.Repositorios
{
    /// <summary>
    /// Repositorio para gestionar las operaciones sobre la entidad <see cref="Rol"/>.
    /// </summary>
    public class RolRepositorio : IRolRepositorio
    {
        private readonly IConexionBaseDatos _conexion;

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="RolRepositorio"/> con una conexión a la base de datos inyectada.
        /// </summary>
        /// <param name="conexion">Instancia de <see cref="IConexionBaseDatos"/> proporcionada por inyección de dependencias.</param>
        public RolRepositorio(IConexionBaseDatos conexion)
        {
            _conexion = conexion;
        }

        /// <summary>
        /// Consulta un rol en la base de datos basado en los filtros proporcionados.
        /// </summary>
        /// <param name="filtro">Objeto <see cref="RolFiltro"/> con los criterios de búsqueda.</param>
        /// <returns>Una instancia de <see cref="Rol"/> si se encuentra, de lo contrario, <c>null</c>.</returns>        
        public Rol Consultar(RolFiltro filtro)
        {
            Rol rol = null;
            string consultaSql = "SELECT IdRol, NombreRol FROM Roles WHERE IdRol = @IdRol";

            try
            {
                _conexion.LimpiarParametros();
                _conexion.AgregarParametroSql("@IdRol", filtro.IdRol, SqlDbType.Int);

                using (IDataReader resultado = _conexion.EjecutarConsultaSql(consultaSql))
                {
                    rol = RolMapeo.Mapear(resultado);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar el rol en la base de datos.", ex);
            }
            finally
            {
                _conexion.Cerrar();
            }

            return rol;
        }
    }
}
