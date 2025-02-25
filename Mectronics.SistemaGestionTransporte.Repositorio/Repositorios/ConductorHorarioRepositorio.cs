
using Mectronics.SistemaGestionTransporte.Tranversales.Entidades;
using Mectronics.SistemaGestionTransporte.Tranversales.Filtros;
using Mectronics.SistemaGestionTransporte.Tranversales.Interfaces.IConductorHorario;
using Mectronics.SistemaGestionTransporte.Tranversales.Interfaces;
using Mectronics.SistemaGestionTransporte.Tranversales.Mapeos;
using System.Data;

namespace Mectronics.SistemaGestionTransporte.Repositorio.Repositorios
{
    /// <summary>
    /// Inicializa una nueva instancia de <see cref="ConductorHorarioRepositorio"/> con una conexión a la base de datos inyectada.
    /// </summary>
    /// <param name="conexion">Instancia de <see cref="IConexionBaseDatos"/> proporcionada por inyección de dependencias.</param>
    public class ConductorHorarioRepositorio : IConductorHorarioRepositorio
    {
        private readonly IConexionBaseDatos _conexion;

        public ConductorHorarioRepositorio(IConexionBaseDatos conexion)
        {
            _conexion = conexion;
        }

        /// <summary>
        /// Consulta una lista de horarios de conductores en la base de datos.
        /// </summary>
        /// <param name="objFiltro">Objeto <see cref="ConductorHorarioFiltro"/> con los criterios de búsqueda.</param>
        /// <returns>Lista de horarios encontrados. Si no hay coincidencias, retorna una lista vacía.</returns>
        public List<ConductorHorario> ConsultarListado(ConductorHorarioFiltro objFiltro)
        {
            List<ConductorHorario> horarios = new List<ConductorHorario>();
            string consultaSql = "SELECT IdConductorHorario, IdConductor, Fecha, DiaSemana, HoraEntrada, HoraSalida, IdBus FROM ConductorHorario WHERE 1 = 1 ";

            if (objFiltro.IdConductorHorario != 0)
            {
                consultaSql += " AND IdConductor = @IdConductor ";
            }
            if (objFiltro.Fecha != DateTime.MinValue)
            {
                consultaSql += "AND Fecha = @Fecha ";
            }
            
            try
            {
                _conexion.LimpiarParametros();
                _conexion.AgregarParametroSql("@IdConductor", objFiltro.IdConductorHorario, SqlDbType.Int);
                _conexion.AgregarParametroSql("@Fecha", objFiltro.Fecha, SqlDbType.Date);
                
                using (IDataReader resultado = _conexion.EjecutarConsultaSql(consultaSql))
                {
                    horarios = ConductorHorarioMapeo.MapearLista(resultado);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar la lista de horarios de conductores en la base de datos.", ex);
            }
            finally
            {
                _conexion.Cerrar();
            }

            return horarios;
        }
        /// <summary>
        /// Elimina un registro de horario de conductor de la base de datos por su identificador único.
        /// </summary>
        /// <param name="idConductorHorario">Identificador único del horario de conductor a eliminar.</param>
        /// <returns>El número de filas afectadas en la base de datos.</returns>
        public int Eliminar(int idConductorHorario)
        {
            string consultaSql = "DELETE FROM ConductorHorario WHERE IdConductorHorario = @IdConductorHorario";
            int filasAfectadas = 0;

            try
            {
                _conexion.LimpiarParametros();
                _conexion.AgregarParametroSql("@IdConductorHorario", idConductorHorario, SqlDbType.Int);
                filasAfectadas = _conexion.EjecutarComandoSql(consultaSql);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el horario de conductor de la base de datos.", ex);
            }
            finally
            {
                _conexion.Cerrar();
            }

            return filasAfectadas;
        }

        /// <summary>
        /// Inserta un nuevo registro de horario de conductor en la base de datos.
        /// </summary>
        /// <param name="conductorHorario">Objeto <see cref="ConductorHorario"/> con la información a insertar.</param>
        /// <returns>El número de filas afectadas en la base de datos.</returns>
        public int Insertar(ConductorHorario conductorHorario)
        {
            string consultaSql = @"INSERT INTO ConductorHorario (IdConductor, Fecha, DiaSemana, HoraEntrada, HoraSalida, IdBus) 
                               VALUES (@IdConductor, @Fecha, @DiaSemana, @HoraEntrada, @HoraSalida, @IdBus) 
                               SELECT SCOPE_IDENTITY();";
            int idConductorHorario = 0;

            try
            {
                _conexion.LimpiarParametros();
                _conexion.AgregarParametroSql("@IdConductor", conductorHorario.Conductor.IdConductor, SqlDbType.Int);
                _conexion.AgregarParametroSql("@Fecha", conductorHorario.Fecha, SqlDbType.DateTime);
                _conexion.AgregarParametroSql("@DiaSemana", string.Empty, SqlDbType.VarChar);
                _conexion.AgregarParametroSql("@HoraEntrada", conductorHorario.HoraEntrada, SqlDbType.DateTime);
                _conexion.AgregarParametroSql("@HoraSalida", conductorHorario.HoraSalida, SqlDbType.DateTime);
                _conexion.AgregarParametroSql("@IdBus", conductorHorario.Bus.IdBus, SqlDbType.Int);

                object resultado = _conexion.EjecutarEscalarSql(consultaSql);
                idConductorHorario = Convert.ToInt32(resultado);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar el horario de conductor en la base de datos.", ex);
            }
            finally
            {
                _conexion.Cerrar();
            }

            return idConductorHorario;
        }
        /// <summary>
        /// Actualiza un registro de horario de conductor en la base de datos.
        /// </summary>
        /// <param name="conductorHorario">Objeto <see cref="ConductorHorario"/> con la información actualizada.</param>
        /// <returns>El número de filas afectadas en la base de datos.</returns>
        public int Actualizar(ConductorHorario conductorHorario)
        {
            string consultaSql = @"UPDATE ConductorHorario 
                               SET IdConductor = @IdConductor, Fecha = @Fecha, DiaSemana = @DiaSemana, 
                                   HoraEntrada = @HoraEntrada, HoraSalida = @HoraSalida, IdBus = @IdBus 
                               WHERE IdConductorHorario = @IdConductorHorario";
            int filasAfectadas = 0;

            try
            {
                _conexion.LimpiarParametros();
                _conexion.AgregarParametroSql("@IdConductorHorario", conductorHorario.IdConductorHorario, SqlDbType.Int);
                _conexion.AgregarParametroSql("@IdConductor", conductorHorario.Conductor.IdConductor, SqlDbType.Int);
                _conexion.AgregarParametroSql("@Fecha", conductorHorario.Fecha, SqlDbType.DateTime);
                _conexion.AgregarParametroSql("@DiaSemana", conductorHorario.DiaSemana, SqlDbType.VarChar);
                _conexion.AgregarParametroSql("@HoraEntrada", conductorHorario.HoraEntrada, SqlDbType.DateTime);
                _conexion.AgregarParametroSql("@HoraSalida", conductorHorario.HoraSalida, SqlDbType.DateTime);
                _conexion.AgregarParametroSql("@IdBus", conductorHorario.Bus.IdBus, SqlDbType.Int);

                filasAfectadas = _conexion.EjecutarComandoSql(consultaSql);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el horario de conductor en la base de datos.", ex);
            }
            finally
            {
                _conexion.Cerrar();
            }

            return filasAfectadas;
        }
    }

}
