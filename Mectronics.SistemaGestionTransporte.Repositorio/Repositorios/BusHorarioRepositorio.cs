using Mectronics.SistemaGestionTransporte.Tranversales.Interfaces.IBusHorario;
using Mectronics.SistemaGestionTransporte.Tranversales.Interfaces;
using Mectronics.SistemaGestionTransporte.Tranversales.Entidades;
using Mectronics.SistemaGestionTransporte.Tranversales.Filtros;
using Mectronics.SistemaGestionTransporte.Tranversales.Mapeos;
using System.Data;

namespace Mectronics.SistemaGestionTransporte.Repositorio.Repositorios
{
    /// <summary>
    /// Repositorio para gestionar las operaciones sobre la entidad <see cref="BusHorario"/>.
    /// </summary>
    public class BusHorarioRepositorio : IBusHorarioRepositorio
    {
        private readonly IConexionBaseDatos _conexion;

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="BusHorarioRepositorio"/> con una conexión a la base de datos inyectada.
        /// </summary>
        /// <param name="conexion">Instancia de <see cref="IConexionBaseDatos"/> proporcionada por inyección de dependencias.</param>
        public BusHorarioRepositorio(IConexionBaseDatos conexion)
        {
            _conexion = conexion;
        }

        /// <summary>
        /// Consulta una lista de horarios de buses en la base de datos.
        /// </summary>
        /// <param name="objFiltro">Objeto <see cref="BusHorarioFiltro"/> con los criterios de búsqueda.</param>
        /// <returns>Lista de horarios encontrados. Si no hay coincidencias, retorna una lista vacía.</returns>
        public List<BusHorario> ConsultarListado(BusHorarioFiltro objFiltro)
        {
            List<BusHorario> horarios = new List<BusHorario>();
            string consultaSql = "SELECT * FROM BusHorario  WHERE IdBusHorario = @IdBusHorario";

            if (objFiltro.Fecha != DateTime.MinValue)
            {
                consultaSql += "AND Fecha = @Fecha";
            }
            if (!string.IsNullOrEmpty(objFiltro.DiaSemana))
            {
                consultaSql += "AND DiaSemana = @DiaSemana";
            }
            try
            {
                _conexion.LimpiarParametros();
                _conexion.AgregarParametroSql("@IdBusHorario", objFiltro.IdBusHorario, SqlDbType.Int);
                _conexion.AgregarParametroSql("@Fecha", objFiltro.Fecha, SqlDbType.DateTime);
                _conexion.AgregarParametroSql("@DiaSemana", objFiltro.DiaSemana, SqlDbType.NVarChar);

                using (IDataReader resultado = _conexion.EjecutarConsultaSql(consultaSql))
                {
                    horarios = BusHorarioMapeo.MapearLista(resultado);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar la lista de horarios de buses en la base de datos.", ex);
            }
            finally
            {
                _conexion.Cerrar();
            }

            return horarios;
        }

        /// <summary>
        /// Elimina un registro de horario de bus de la base de datos por su identificador único.
        /// </summary>
        /// <param name="idBusHorario">Identificador único del horario de bus a eliminar.</param>
        /// <returns>El número de filas afectadas en la base de datos.</returns>
        public int Eliminar(int idBusHorario)
        {
            string consultaSql = "DELETE FROM BusHorario WHERE IdBusHorario = @IdBusHorario";
            int filasAfectadas = 0;

            try
            {
                _conexion.LimpiarParametros();
                _conexion.AgregarParametroSql("@IdBusHorario", idBusHorario, SqlDbType.Int);
                filasAfectadas = _conexion.EjecutarComandoSql(consultaSql);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el horario de bus de la base de datos.", ex);
            }
            finally
            {
                _conexion.Cerrar();
            }

            return filasAfectadas;
        }

        /// <summary>
        /// Inserta un nuevo registro de horario de bus en la base de datos.
        /// </summary>
        /// <param name="busHorario">Objeto <see cref="BusHorario"/> con la información a insertar.</param>
        /// <returns>El número de filas afectadas en la base de datos.</returns>
        public int Insertar(BusHorario busHorario)
        {
            string consultaSql = @"INSERT INTO BusHorario (IdBus, Fecha, DiaSemana, HoraEntrada, HoraSalida) 
                               VALUES (@IdBus, @Fecha, @DiaSemana, @HoraEntrada, @HoraSalida) 
                               SELECT SCOPE_IDENTITY();";
            int idBusHorario = 0;

            try
            {
                _conexion.LimpiarParametros();
                _conexion.AgregarParametroSql("@IdBus", busHorario.Bus.IdBus, SqlDbType.Int);
                _conexion.AgregarParametroSql("@Fecha", busHorario.Fecha, SqlDbType.DateTime);
                _conexion.AgregarParametroSql("@DiaSemana", busHorario.DiaSemana, SqlDbType.VarChar);
                _conexion.AgregarParametroSql("@HoraEntrada", busHorario.HoraEntrada, SqlDbType.DateTime);
                _conexion.AgregarParametroSql("@HoraSalida", busHorario.HoraSalida, SqlDbType.DateTime);

                object resultado = _conexion.EjecutarEscalarSql(consultaSql);
                idBusHorario = Convert.ToInt32(resultado);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar el horario de bus en la base de datos.", ex);
            }
            finally
            {
                _conexion.Cerrar();
            }

            return idBusHorario;
        }

        /// <summary>
        /// Actualiza un registro de horario de bus en la base de datos.
        /// </summary>
        /// <param name="busHorario">Objeto <see cref="BusHorario"/> con la información actualizada.</param>
        /// <returns>El número de filas afectadas en la base de datos.</returns>
        public int Actualizar(BusHorario busHorario)
        {
            string consultaSql = @"UPDATE BusHorario 
                               SET IdBus = @IdBus, Fecha = @Fecha, DiaSemana = @DiaSemana, 
                                   HoraEntrada = @HoraEntrada, HoraSalida = @HoraSalida 
                               WHERE IdBusHorario = @IdBusHorario";
            int filasAfectadas = 0;

            try
            {
                _conexion.LimpiarParametros();
                _conexion.AgregarParametroSql("@IdBusHorario", busHorario.IdBusHorario, SqlDbType.Int);
                _conexion.AgregarParametroSql("@IdBus", busHorario.Bus.IdBus, SqlDbType.Int);
                _conexion.AgregarParametroSql("@Fecha", busHorario.Fecha, SqlDbType.DateTime);
                _conexion.AgregarParametroSql("@DiaSemana", busHorario.DiaSemana, SqlDbType.VarChar);
                _conexion.AgregarParametroSql("@HoraEntrada", busHorario.HoraEntrada, SqlDbType.DateTime);
                _conexion.AgregarParametroSql("@HoraSalida", busHorario.HoraSalida, SqlDbType.DateTime);

                filasAfectadas = _conexion.EjecutarComandoSql(consultaSql);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el horario de bus en la base de datos.", ex);
            }
            finally
            {
                _conexion.Cerrar();
            }

            return filasAfectadas;
        }
    }
}
