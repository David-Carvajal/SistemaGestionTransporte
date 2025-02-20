using Mectronics.SistemaGestionTransporte.Tranversales.Entidades;
using Mectronics.SistemaGestionTransporte.Tranversales.Filtros;


namespace Mectronics.SistemaGestionTransporte.Tranversales.Interfaces.IRol
{
    /// <summary>
    /// Define las operaciones de acceso a datos para la entidad <see cref="Rol"/>.
    /// </summary>
    public interface IRolRepositorio
    {
        /// <summary>
        /// Consulta un rol en la base de datos basado en los filtros proporcionados.
        /// </summary>
        /// <param name="objFiltro">Objeto <see cref="RolFiltro"/> con los criterios de búsqueda.</param>
        /// <returns>Una instancia de <see cref="Rol"/> si se encuentra, de lo contrario, <c>null</c>.</returns>
        Rol Consultar(RolFiltro objFiltro);
    }
}
