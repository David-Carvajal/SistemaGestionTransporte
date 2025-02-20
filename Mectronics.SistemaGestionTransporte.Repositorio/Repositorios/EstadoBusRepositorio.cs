
using Mectronics.SistemaGestionTransporte.Tranversales.Entidades;
using Mectronics.SistemaGestionTransporte.Tranversales.Filtros;
using Mectronics.SistemaGestionTransporte.Tranversales.Interfaces.IEstadoBus;
using Mectronics.SistemaGestionTransporte.Tranversales.Interfaces;
using Mectronics.SistemaGestionTransporte.Tranversales.Mapeos;
using System.Data;

namespace Mectronics.SistemaGestionTransporte.Repositorio.Repositorios
{
    /// <summary>
    /// Repositorio para gestionar las operaciones sobre la entidad <see cref="EstadoBus"/>.
    /// </summary>
    public class EstadoBusRepositorio : IEstadoBusRepositorio
    {
        private readonly IConexionBaseDatos _conexion;

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="EstadoBusRepositorio"/> con una conexión a la base de datos inyectada.
        /// </summary>
        /// <param name="conexion">Instancia de <see cref="IConexionBaseDatos"/> proporcionada por inyección de dependencias.</param>
        public EstadoBusRepositorio(IConexionBaseDatos conexion)
        {
            _conexion = conexion;
        }

        /// <summary>
        /// Consulta un estado de bus en la base de datos basado en los filtros proporcionados.
        /// </summary>
        /// <param name="filtro">Objeto <see cref="EstadoBusFiltro"/> con los criterios de búsqueda.</param>
        /// <returns>Una instancia de <see cref="EstadoBus"/> si se encuentra, de lo contrario, <c>null</c>.</returns>        
        public EstadoBus Consultar(EstadoBusFiltro filtro)
        {
            EstadoBus estadoBus = null;
            string consultaSql = "SELECT IdEstadoBus, NombreEstadoBus FROM EstadoBus WHERE IdEstadoBus = @IdEstadoBus";

            try
            {
                _conexion.LimpiarParametros();
                _conexion.AgregarParametroSql("@IdEstadoBus", filtro.IdEstadoBus, SqlDbType.Int);

                using (IDataReader resultado = _conexion.EjecutarConsultaSql(consultaSql))
                {
                    estadoBus = EstadoBusMapeo.Mapear(resultado);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar el estado del bus en la base de datos.", ex);
            }
            finally
            {
                _conexion.Cerrar();
            }

            return estadoBus;
        }
    }
}
