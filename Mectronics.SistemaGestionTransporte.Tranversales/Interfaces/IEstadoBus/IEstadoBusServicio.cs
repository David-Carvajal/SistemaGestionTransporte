using Mectronics.SistemaGestionTransporte.Tranversales.Dtos;
using Mectronics.SistemaGestionTransporte.Tranversales.Filtros;

namespace Mectronics.SistemaGestionTransporte.Tranversales.Interfaces.IEstadoBus
{
    /// <summary>
    /// Define las operaciones del servicio para la entidad <see cref="EstadoBus"/>, donde se dejarán las reglas de negocio.
    /// </summary>
    public interface IEstadoBusServicio
    {
        /// <summary>
        /// Consulta un estado de bus basado en los filtros proporcionados.
        /// </summary>
        /// <param name="objFiltro">Objeto <see cref="EstadoBusFiltro"/> con los criterios de búsqueda.</param>
        /// <returns>Registro encontrado.</returns>
        EstadoBusDto Consultar(EstadoBusFiltro objFiltro); 
    }
}
