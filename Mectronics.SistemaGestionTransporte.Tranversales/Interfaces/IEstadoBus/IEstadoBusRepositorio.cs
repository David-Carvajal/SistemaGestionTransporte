
using Mectronics.SistemaGestionTransporte.Tranversales.Entidades;
using Mectronics.SistemaGestionTransporte.Tranversales.Filtros;

namespace Mectronics.SistemaGestionTransporte.Tranversales.Interfaces.IEstadoBus
{
    /// <summary>
    /// Define las operaciones de acceso a datos para la entidad <see cref="EstadoBus"/>.
    /// </summary>
    public interface IEstadoBusRepositorio
    {
        /// <summary>
        /// Consulta un estado de bus en la base de datos basada en los filtros proporcionados.
        /// </summary>
        /// <param name="objFiltro">Objeto <see cref="EstadoBusFiltro"/> con los criterios de búsqueda.</param>
        /// <returns>Una instancia de <see cref="EstadoBus"/> si se encuentra, de lo contrario, <c>null</c>.</returns>
        List<EstadoBus> Consultar(EstadoBusFiltro objFiltro);

    }
}
