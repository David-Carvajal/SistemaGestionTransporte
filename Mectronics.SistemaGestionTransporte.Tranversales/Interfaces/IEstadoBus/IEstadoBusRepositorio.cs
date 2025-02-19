
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
        /// Inserta un nuevo estado de bus en la base de datos.
        /// </summary>
        /// <param name="estadoBus">Objeto <see cref="EstadoBus"/> con la información a insertar.</param>
        /// <returns>El número de filas afectadas en la base de datos.</returns>
        int Insertar(EstadoBus estadoBus);

        /// <summary>
        /// Actualiza un estado de bus existente en la base de datos.
        /// </summary>
        /// <param name="estadoBus">Objeto <see cref="EstadoBus"/> con la información actualizada.</param>
        /// <returns>El número de filas afectadas en la base de datos.</returns>
        int Actualizar(EstadoBus estadoBus);

        /// <summary>
        /// Elimina un estado de bus de la base de datos por su identificador único.
        /// </summary>
        /// <param name="idEstadoBus">Identificador único del estado de bus a eliminar.</param>
        /// <returns>El número de filas afectadas en la base de datos.</returns>
        int Eliminar(int idEstadoBus);

        /// <summary>
        /// Consulta un estado de bus en la base de datos basada en los filtros proporcionados.
        /// </summary>
        /// <param name="objFiltro">Objeto <see cref="EstadoBusFiltro"/> con los criterios de búsqueda.</param>
        /// <returns>Una instancia de <see cref="EstadoBus"/> si se encuentra, de lo contrario, <c>null</c>.</returns>
        EstadoBus Consultar(EstadoBusFiltro objFiltro);

        /// <summary>
        /// Consulta una lista de estados de bus en la base de datos según los filtros proporcionados.
        /// </summary>
        /// <param name="objFiltro">Objeto <see cref="EstadoBusFiltro"/> con los criterios de búsqueda.</param>
        /// <returns>Lista de estados de bus encontrados. Si no hay coincidencias, retorna una lista vacía.</returns>
        List<EstadoBus> ConsultarListado(EstadoBusFiltro objFiltro);
    }
}
