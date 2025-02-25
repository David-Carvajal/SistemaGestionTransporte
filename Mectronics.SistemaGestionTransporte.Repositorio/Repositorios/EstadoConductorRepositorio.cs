using Mectronics.SistemaGestionTransporte.Tranversales.Entidades;
using Mectronics.SistemaGestionTransporte.Tranversales.Filtros;
using Mectronics.SistemaGestionTransporte.Tranversales.Interfaces.IEstadoConductor;
using Mectronics.SistemaGestionTransporte.Tranversales.Interfaces;
using Mectronics.SistemaGestionTransporte.Tranversales.Mapeos;
using System.Data;

namespace Mectronics.SistemaGestionTransporte.Repositorio.Repositorios
{
    /// <summary>
    /// Repositorio para gestionar las operaciones sobre la entidad <see cref="EstadoConductor"/>.
    /// </summary>
    public class EstadoConductorRepositorio : IEstadoConductorRepositorio
    {
        private readonly IConexionBaseDatos _conexion;

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="EstadoConductorRepositorio"/> con una conexión a la base de datos inyectada.
        /// </summary>
        /// <param name="conexion">Instancia de <see cref="IConexionBaseDatos"/> proporcionada por inyección de dependencias.</param>
        public EstadoConductorRepositorio(IConexionBaseDatos conexion)
        {
            _conexion = conexion;
        }

        /// <summary>
        /// Consulta un estado de conductor en la base de datos basado en los filtros proporcionados.
        /// </summary>
        /// <param name="filtro">Objeto <see cref="EstadoConductorFiltro"/> con los criterios de búsqueda.</param>
        /// <returns>Una instancia de <see cref="EstadoConductor"/> si se encuentra, de lo contrario, <c>null</c>.</returns>        
        public List<EstadoConductor> ConsultarLista()
        {
            List<EstadoConductor> estado = [];
            string consultaSql = "SELECT IdEstadoConductor, NombreEstadoConductor FROM EstadoConductor ORDER BY IdEstadoConductor";

            try
            { 
                using (IDataReader resultado = _conexion.EjecutarConsultaSql(consultaSql))
                {
                    estado = EstadoConductorMapeo.MapearLista(resultado);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar el estado del conductor en la base de datos.", ex);
            }
            finally
            {
                _conexion.Cerrar();
            }

            return estado;
        }
    }
}
