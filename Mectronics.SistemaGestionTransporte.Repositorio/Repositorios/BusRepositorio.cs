
using Mectronics.SistemaGestionTransporte.Tranversales.Entidades;
using Mectronics.SistemaGestionTransporte.Tranversales.Filtros;
using Mectronics.SistemaGestionTransporte.Tranversales.Interfaces;
using Mectronics.SistemaGestionTransporte.Tranversales.Interfaces.IBus;
using Mectronics.SistemaGestionTransporte.Tranversales.Mapeos;
using System.Data;

namespace Mectronics.SistemaGestionTransporte.Repositorio.Repositorios
{
    /// <summary>
    /// Repsoritorio para gestionar las operaciones sobre la entidad<see cref="Bus"/>
    /// </summary>
    public class BusRepositorio : IBusRepositorio
    {
        private readonly IConexionBaseDatos _conexion;

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="BusRepositorio"/> con una conexión a la base de datos inyectada.
        /// </summary>
        /// <param name="conexion">Instancia de <see cref="IConexionBaseDatos"/> proporcionada por inyección de dependencias.</param>
        public BusRepositorio(IConexionBaseDatos conexion)
        {
            _conexion = conexion;
        }

        /// <summary>
        /// Consulta un bus en la base de datos basado en los filtros proporcionados.
        /// </summary>
        /// <param name="filtro">Objeto <see cref="BusFiltro"/> con los criterios de búsqueda.</param>
        /// <returns>Una instancia de <see cref="Bus"/> si se encuentra, de lo contrario, <c>null</c>.</returns>        
        public Bus Consultar(BusFiltro filtro)
        {
            Bus bus = null;
            string consultaSql = "SELECT  b.IdBus, b.Modelo, b.Capacidad, b.Placa, b.IdEstadoBus, e.NombreEstadoBus As NombreEstadoBus " +
                "FROM Buses b INNER JOIN EstadoBus e ON b.IdEstadoBus = e.IdEstadoBus " +
                "WHERE b.IdBus = @IdBus";

            try
            {
                _conexion.LimpiarParametros();
                _conexion.AgregarParametroSql("@IdBus", filtro.IdBus, SqlDbType.Int);

                using (IDataReader resultado = _conexion.EjecutarConsultaSql(consultaSql))
                {
                    bus = BusMapeo.Mapear(resultado);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar el bus en la base de datos.", ex);
            }
            finally
            {
                _conexion.Cerrar();
            }

            return bus;
        }

        /// <summary>
        /// Consulta una lista de buses en la base de datos según los filtros proporcionados.
        /// </summary>
        /// <param name="filtro">Objeto <see cref="BusFiltro"/> con los criterios de búsqueda.</param>
        /// <returns>Lista de buses encontrados. Si no hay coincidencias, retorna una lista vacía.</returns>        
        public List<Bus> ConsultarListado(BusFiltro filtro)
        {
            List<Bus> buses = [];
            string consultaSql = "SELECT b.IdBus, b.Modelo, b.Capacidad, b.Placa, b.IdEstadoBus, e.NombreEstadoBus As NombreEstadoBus " +
                                 "FROM Buses b INNER JOIN EstadoBus e ON b.IdEstadoBus = e.IdEstadoBus " +
                                 "WHERE b.Placa like @Placa";

            if (filtro.IdBus > 0)
            {
                consultaSql += " AND b.IdBus = @IdBus";
            }

            if (filtro.Modelo > 0)
            {
                consultaSql += " AND b.Modelo = @Modelo";
            }

            if (filtro.IdEstado > 0)
            {
                consultaSql += " AND b.IdEstadoBus = @IdEstado";
            }

            try
            {
                _conexion.LimpiarParametros();
                _conexion.AgregarParametroSql("@IdBus", filtro.IdBus, SqlDbType.Int);
                _conexion.AgregarParametroSql("@Modelo", filtro.Modelo, SqlDbType.Int);
                _conexion.AgregarParametroSql("@Placa", $"%{filtro.Placa}%", SqlDbType.NVarChar);
                _conexion.AgregarParametroSql("@IdEstado", filtro.IdEstado, SqlDbType.Int);

                using (IDataReader resultado = _conexion.EjecutarConsultaSql(consultaSql))
                {
                    buses = BusMapeo.MapearLista(resultado);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar los buses en la base de datos.", ex);
            }
            finally
            {
                _conexion.Cerrar();
            }

            return buses;
        }

        /// <summary>
        /// Elimina un bus de la base de datos por su identificador único.
        /// </summary>
        /// <param name="idBus">Identificador único del bus a eliminar.</param>
        /// <returns>El número de filas afectadas en la base de datos.</returns>        
        public int Eliminar(int idBus)
        {
            string strComandoSql = "DELETE FROM Buses WHERE IdBus = @IdBus";
            int filasAfectadas = 0;

            try
            {
                _conexion.LimpiarParametros();
                _conexion.AgregarParametroSql("@IdBus", idBus, SqlDbType.Int);

                filasAfectadas = _conexion.EjecutarComandoSql(strComandoSql);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el bus de la base de datos.", ex);
            }
            finally
            {
                _conexion.Cerrar();
            }

            return filasAfectadas;
        }

        /// <summary>
        /// Inserta un nuevo bus en la base de datos.
        /// </summary>
        /// <param name="bus">Objeto <see cref="Bus"/> con la información a insertar.</param>
        /// <returns>El identificador del bus recién insertado.</returns>        
        public int Insertar(Bus bus)
        {
            string strComandoSql = @"INSERT INTO Bus (Modelo, Capacidad, Placa, IdEstadoBus) 
                                     VALUES (@Modelo, @Capacidad, @Placa, @IdEstadoBus)
                                     SELECT SCOPE_IDENTITY();";
            int idBus = 0;

            try
            {
                _conexion.LimpiarParametros();
                _conexion.AgregarParametroSql("@Modelo", bus.Modelo, SqlDbType.Int);
                _conexion.AgregarParametroSql("@Capacidad", bus.Capacidad, SqlDbType.Int);
                _conexion.AgregarParametroSql("@Placa", bus.Placa, SqlDbType.VarChar);
                _conexion.AgregarParametroSql("@IdEstadoBus", bus.EstadoBus.IdEstadoBus, SqlDbType.Int);

                object resultado = _conexion.EjecutarEscalarSql(strComandoSql);
                idBus = Convert.ToInt32(resultado);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar el bus en la base de datos.", ex);
            }
            finally
            {
                _conexion.Cerrar();
            }

            return idBus;
        }

         /// <summary>
        /// Actualiza un bus existente en la base de datos.
        /// </summary>
        /// <param name="bus">Objeto <see cref="Bus"/> con la información actualizada.</param>
        /// <returns>El número de filas afectadas en la base de datos.</returns>        
        public int Actualizar(Bus bus)
        {
            string strComandoSql = @"UPDATE Buses SET Modelo = @Modelo, Capacidad = @Capacidad, Placa = @Placa, IdEstadoBus = @IdEstadoBus
                                     WHERE IdBus = @IdBus";
            int filasAfectadas = 0;

            try
            {
                _conexion.LimpiarParametros();
                _conexion.AgregarParametroSql("@IdBus", bus.IdBus, SqlDbType.Int);
                _conexion.AgregarParametroSql("@Modelo", bus.Modelo, SqlDbType.Int);
                _conexion.AgregarParametroSql("@Capacidad", bus.Capacidad, SqlDbType.Int);
                _conexion.AgregarParametroSql("@Placa", bus.Placa, SqlDbType.VarChar);
                _conexion.AgregarParametroSql("@IdEstadoBus", bus.EstadoBus.IdEstadoBus, SqlDbType.Int);

                filasAfectadas = _conexion.EjecutarComandoSql(strComandoSql);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el bus en la base de datos.", ex);
            }
            finally
            {
                _conexion.Cerrar();
            }

            return filasAfectadas;
        }
        
        
    }
}
