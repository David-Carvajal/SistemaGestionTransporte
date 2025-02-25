using Mectronics.SistemaGestionTransporte.Tranversales.Dtos;
using Mectronics.SistemaGestionTransporte.Tranversales.Filtros;

namespace Mectronics.SistemaGestionTransporte.Tranversales.Interfaces.IEstadoConductor
{
    /// <summary>
    /// Define las operaciones del servicio para la entidad <see cref="EstadoConductor"/>, donde se dejarán las reglas de negocio.
    /// </summary>
    public interface IEstadoConductorServicio
    {
        /// <summary>
        /// Consulta un estado de conductor basado en los filtros proporcionados.
        /// </summary>
        /// <param name="objFiltro">Objeto <see cref="EstadoConductorFiltro"/> con los criterios de búsqueda.</param>
        /// <returns>Registro encontrado.</returns>
        List<EstadoConductorDto> ConsultarLista();
    }
}
