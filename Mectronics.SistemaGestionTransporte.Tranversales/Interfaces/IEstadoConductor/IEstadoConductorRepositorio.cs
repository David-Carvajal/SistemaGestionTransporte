
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
        /// Inserta un nuevo estado de conductor en la base de datos.
        /// </summary>
        /// <param name="estadoConductor">Objeto <see cref="EstadoConductor"/> con la información a insertar.</param>
        /// <returns>El número de filas afectadas en la base de datos.</returns>
        int Insertar(EstadoConductor estadoConductor);

        /// <summary>
        /// Actualiza un estado de conductor existente en la base de datos.
        /// </summary>
        /// <param name="estadoConductor">Objeto <see cref="EstadoConductor"/> con la información actualizada.</param>
        /// <returns>El número de filas afectadas en la base de datos.</returns>
        int Actualizar(EstadoConductor estadoConductor);

        /// <summary>
        /// Elimina un estado de conductor de la base de datos por su identificador único.
        /// </summary>
        /// <param name="idEstadoConductor">Identificador único del estado de conductor a eliminar.</param>
        /// <returns>El número de filas afectadas en la base de datos.</returns>
        int Eliminar(int idEstadoConductor);

        /// <summary>
        /// Consulta un estado de conductor en la base de datos basado en los filtros proporcionados.
        /// </summary>
        /// <param name="objFiltro">Objeto <see cref="EstadoConductorFiltro"/> con los criterios de búsqueda.</param>
        /// <returns>Una instancia de <see cref="EstadoConductor"/> si se encuentra, de lo contrario, <c>null</c>.</returns>
        EstadoConductor Consultar(EstadoConductorFiltro objFiltro);

        /// <summary>
        /// Consulta una lista de estados de conductor en la base de datos según los filtros proporcionados.
        /// </summary>
        /// <param name="objFiltro">Objeto <see cref="EstadoConductorFiltro"/> con los criterios de búsqueda.</param>
        /// <returns>Lista de estados de conductor encontrados. Si no hay coincidencias, retorna una lista vacía.</returns>
        List<EstadoConductor> ConsultarListado(EstadoConductorFiltro objFiltro);
    }
}
