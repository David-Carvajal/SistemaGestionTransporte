
using Mectronics.SistemaGestionTransporte.Tranversales.Interfaces.IConductor;
using Mectronics.SistemaGestionTransporte.Tranversales.Interfaces;
using Mectronics.SistemaGestionTransporte.Tranversales.Entidades;
using Mectronics.SistemaGestionTransporte.Tranversales.Filtros;
using Mectronics.SistemaGestionTransporte.Tranversales.Mapeos;
using System.Data;

namespace Mectronics.SistemaGestionTransporte.Repositorio.Repositorios
{
    /// <summary>
    /// Repositorio para gestionar las operaciones sobre la entidad <see cref="Conductor"/>.
    /// </summary>
    public class ConductorRepositorio : IConductorRepositorio
    {
        private readonly IConexionBaseDatos _conexion;

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="ConductorRepositorio"/> con una conexión a la base de datos inyectada.
        /// </summary>
        /// <param name="conexion">Instancia de <see cref="IConexionBaseDatos"/> proporcionada por inyección de dependencias.</param>
        public ConductorRepositorio(IConexionBaseDatos conexion)
        {
            _conexion = conexion;
        }

        /// <summary>
        /// Consulta un conductor en la base de datos basado en los filtros proporcionados.
        /// </summary>
        /// <param name="objFiltro">Objeto <see cref="ConductorFiltro"/> con los criterios de búsqueda.</param>
        /// <returns>Una instancia de <see cref="Conductor"/> si se encuentra, de lo contrario, <c>null</c>.</returns>
        public Conductor Consultar(ConductorFiltro objFiltro)
        {
            Conductor conductor = null;
            string consultaSql = "SELECT c.IdConductor, c.NumeroLicencia, c.IdEstadoConductor, c.IdUsuario,  u.Nombre As Nombre, u.Correo As Correo, u.IdRol As Rol " +
                "FROM Conductores c INNER JOIN Usuarios u ON c.IdUsuario = u.IdUsuario " +
                "WHERE c.IdConductor = @IdConductor";

            try
            {
                _conexion.LimpiarParametros();
                _conexion.AgregarParametroSql("@IdConductor", objFiltro.IdConductor, SqlDbType.Int);

                using (IDataReader resultado = _conexion.EjecutarConsultaSql(consultaSql))
                {
                    conductor = ConductorMapeo.Mapear(resultado);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar el conductor en la base de datos.", ex);
            }
            finally
            {
                    _conexion.Cerrar();
            }

            return conductor;
        }

        /// <summary>
        /// Consulta una lista de conductores en la base de datos según los filtros proporcionados.
        /// </summary>
        /// <param name="objFiltro">Objeto <see cref="ConductorFiltro"/> con los criterios de búsqueda.</param>
        /// <returns>Lista de conductores encontrados. Si no hay coincidencias, retorna una lista vacía.</returns>
        public List<Conductor> ConsultarListado(ConductorFiltro objFiltro)
        {
            List<Conductor> conductores = [];
            string consultaSql = "SELECT c.IdConductor, c.NumeroLicencia, c.IdEstadoConductor, c.IdUsuario,  u.Nombre As Nombre, u.Correo As Correo, u.IdRol As Rol " +
                                 "FROM Conductores c INNER JOIN Usuarios u ON c.IdUsuario = u.IdUsuario " +
                                 "WHERE c.NumeroLicencia like @NumeroLicencia";

            if (objFiltro.IdEstadoConductor > 0)
            {
                consultaSql += " AND IdEstadoConductor = @IdEstadoConductor";
            }

            if (objFiltro.IdConductor > 0)
            {
                consultaSql += " AND IdConductor = @IdConductor";
            }

            try
            {
                _conexion.LimpiarParametros();
                _conexion.AgregarParametroSql("@NumeroLicencia", $"%{objFiltro.NumeroLicencia}%", SqlDbType.NVarChar);
                _conexion.AgregarParametroSql("@IdEstadoConductor", objFiltro.IdEstadoConductor, SqlDbType.Int);
                _conexion.AgregarParametroSql("@IdConductor", objFiltro.IdConductor, SqlDbType.Int);

                using (IDataReader resultado = _conexion.EjecutarConsultaSql(consultaSql))
                {
                    conductores = ConductorMapeo.MapearLista(resultado);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar la lista de conductores en la base de datos.", ex);
            }
            finally
            {
                _conexion.Cerrar();
            }

            return conductores;
        }
        /// <summary>
        /// Elimina un conductor de la base de datos por su identificador único.
        /// </summary>
        /// <param name="idConductor">Identificador único del conductor a eliminar.</param>
        /// <returns>El número de filas afectadas en la base de datos.</returns>
        public int Eliminar(int idConductor)
        {
            string strComandoSql = "DELETE FROM Conductores WHERE IdConductor = @IdConductor";
            int filasAfectadas = 0;

            try
            {
                _conexion.LimpiarParametros();
                _conexion.AgregarParametroSql("@IdConductor", idConductor, SqlDbType.Int);

                filasAfectadas = _conexion.EjecutarComandoSql(strComandoSql);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el conductor de la base de datos.", ex);
            }
            finally
            {
                _conexion.Cerrar();
            }

            return filasAfectadas;
        }

        /// <summary>
        /// Inserta un nuevo conductor en la base de datos.
        /// </summary>
        /// <param name="conductor">Objeto <see cref="Conductor"/> con la información a insertar.</param>
        /// <returns>El identificador único del conductor insertado.</returns>
        public int Insertar(Conductor conductor)
        {
            string strComandoSql = "INSERT INTO Conductores (NumeroLicencia, IdEstadoConductor, IdUsuario) VALUES (@NumeroLicencia, @IdEstadoConductor, @IdUsuario); SELECT SCOPE_IDENTITY();";
            int idConductor = 0;

            try
            {
                _conexion.LimpiarParametros();
                _conexion.AgregarParametroSql("@NumeroLicencia", conductor.NumeroLicencia, SqlDbType.VarChar);
                _conexion.AgregarParametroSql("@IdEstadoConductor", conductor.EstadoConductor.IdEstadoConductor, SqlDbType.Int);
                _conexion.AgregarParametroSql("@IdUsuario", conductor.Usuario.IdUsuario, SqlDbType.Int);

                object resultado = _conexion.EjecutarEscalarSql(strComandoSql);
                idConductor = Convert.ToInt32(resultado);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar el conductor en la base de datos.", ex);
            }
            finally
            {
                _conexion.Cerrar();
            }

            return idConductor;
        }

        /// <summary>
        /// Actualiza un conductor existente en la base de datos.
        /// </summary>
        /// <param name="conductor">Objeto <see cref="Conductor"/> con la información actualizada.</param>
        /// <returns>El número de filas afectadas en la base de datos.</returns>
        public int Actualizar(Conductor conductor)
        {
            string strComandoSql = "UPDATE Conductores SET NumeroLicencia = @NumeroLicencia, IdEstadoConductor = @IdEstadoConductor, IdUsuario = @IdUsuario WHERE IdConductor = @IdConductor";
            int filasAfectadas = 0;

            try
            {
                _conexion.LimpiarParametros();
                _conexion.AgregarParametroSql("@IdConductor", conductor.IdConductor, SqlDbType.Int);
                _conexion.AgregarParametroSql("@NumeroLicencia", conductor.NumeroLicencia, SqlDbType.VarChar);
                _conexion.AgregarParametroSql("@IdEstadoConductor", conductor.EstadoConductor.IdEstadoConductor, SqlDbType.Int);
                _conexion.AgregarParametroSql("@IdUsuario", conductor.Usuario.IdUsuario, SqlDbType.Int);

                filasAfectadas = _conexion.EjecutarComandoSql(strComandoSql);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el conductor en la base de datos.", ex);
            }
            finally
            {
                _conexion.Cerrar();
            }

            return filasAfectadas;
        }
    }

}
