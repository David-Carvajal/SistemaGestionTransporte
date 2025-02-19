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
        /// Inserta un nuevo rol en la base de datos.
        /// </summary>
        /// <param name="rol">Objeto <see cref="Rol"/> con la información a insertar.</param>
        /// <returns>El número de filas afectadas en la base de datos.</returns>
        int Insertar(Rol rol);

        /// <summary>
        /// Actualiza un rol existente en la base de datos.
        /// </summary>
        /// <param name="rol">Objeto <see cref="Rol"/> con la información actualizada.</param>
        /// <returns>El número de filas afectadas en la base de datos.</returns>
        int Actualizar(Rol rol);

        /// <summary>
        /// Elimina un rol de la base de datos por su identificador único.
        /// </summary>
        /// <param name="idRol">Identificador único del rol a eliminar.</param>
        /// <returns>El número de filas afectadas en la base de datos.</returns>
        int Eliminar(int idRol);

        /// <summary>
        /// Consulta un rol en la base de datos basado en los filtros proporcionados.
        /// </summary>
        /// <param name="objFiltro">Objeto <see cref="RolFiltro"/> con los criterios de búsqueda.</param>
        /// <returns>Una instancia de <see cref="Rol"/> si se encuentra, de lo contrario, <c>null</c>.</returns>
        Rol Consultar(RolFiltro objFiltro);

        /// <summary>
        /// Consulta una lista de roles en la base de datos según los filtros proporcionados.
        /// </summary>
        /// <param name="objFiltro">Objeto <see cref="RolFiltro"/> con los criterios de búsqueda.</param>
        /// <returns>Lista de roles encontrados. Si no hay coincidencias, retorna una lista vacía.</returns>
        List<Rol> ConsultarListado(RolFiltro objFiltro);
    }
}
