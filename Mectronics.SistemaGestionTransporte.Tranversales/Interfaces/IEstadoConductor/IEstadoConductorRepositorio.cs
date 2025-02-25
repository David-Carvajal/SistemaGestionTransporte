
using Mectronics.SistemaGestionTransporte.Tranversales.Entidades;
using Mectronics.SistemaGestionTransporte.Tranversales.Filtros;

namespace Mectronics.SistemaGestionTransporte.Tranversales.Interfaces.IEstadoConductor
{
    /// <summary>
    /// Define las operaciones de acceso a datos para la entidad <see cref="EstadoConductor"/>.
    /// </summary>
    public interface IEstadoConductorRepositorio
    {
        /// <summary>
        /// Consulta un estado de conductor en la base de datos basado en los filtros proporcionados.
        /// </summary>
        /// <param name="objFiltro">Objeto <see cref="EstadoConductorFiltro"/> con los criterios de búsqueda.</param>
        /// <returns>Una instancia de <see cref="EstadoConductor"/> si se encuentra, de lo contrario, <c>null</c>.</returns>
        List<EstadoConductor> ConsultarLista();

    }
}
