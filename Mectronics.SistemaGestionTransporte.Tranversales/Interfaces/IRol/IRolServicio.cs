
using Mectronics.SistemaGestionTransporte.Tranversales.Dtos;
using Mectronics.SistemaGestionTransporte.Tranversales.Filtros;

namespace Mectronics.SistemaGestionTransporte.Tranversales.Interfaces.IRol
{
    /// <summary>
    /// Define las operaciones del servicio para la entidad <see cref="Rol"/>, donde se dejarán las reglas de negocio.
    /// </summary>
    public interface IRolServicio
    {
        /// <summary>
        /// Consulta un rol basado en los filtros proporcionados.
        /// </summary>
        /// <param name="objFiltro">Objeto <see cref="RolFiltro"/> con los criterios de búsqueda.</param>
        /// <returns>Registro encontrado.</returns>
        RolDto Consultar(RolFiltro objFiltro);
    }
}
