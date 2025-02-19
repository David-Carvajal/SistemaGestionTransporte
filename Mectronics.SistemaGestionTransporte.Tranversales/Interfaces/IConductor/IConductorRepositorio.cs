
using Mectronics.SistemaGestionTransporte.Tranversales.Entidades;
using Mectronics.SistemaGestionTransporte.Tranversales.Filtros;

namespace Mectronics.SistemaGestionTransporte.Tranversales.Interfaces.IConductor
{
    /// <summary>
    /// Define las operaciones de acceso a datos para la entidad <see cref="Conductor"/>.
    /// </summary>
    public interface IConductorRepositorio
    {
        /// <summary>
        /// Inserta un nuevo conductor en la base de datos.
        /// </summary>
        /// <param name="conductor">Objeto <see cref="Conductor"/> con la información a insertar.</param>
        /// <returns>El número de filas afectadas en la base de datos.</returns>
        int Insertar(Conductor conductor);

        /// <summary>
        /// Actualiza un conductor existente en la base de datos.
        /// </summary>
        /// <param name="conductor">Objeto <see cref="Conductor"/> con la información actualizada.</param>
        /// <returns>El número de filas afectadas en la base de datos.</returns>
        int Actualizar(Conductor conductor);

        /// <summary>
        /// Elimina un conductor de la base de datos por su identificador único.
        /// </summary>
        /// <param name="idConductor">Identificador único del conductor a eliminar.</param>
        /// <returns>El número de filas afectadas en la base de datos.</returns>
        int Eliminar(int idConductor);

        /// <summary>
        /// Consulta un conductor en la base de datos basada en los filtros proporcionados.
        /// </summary>
        /// <param name="objFiltro">Objeto <see cref="ConductorFiltro"/> con los criterios de búsqueda.</param>
        /// <returns>Una instancia de <see cref="Conductor"/> si se encuentra, de lo contrario, <c>null</c>.</returns>
        Conductor Consultar(ConductorFiltro objFiltro);

        /// <summary>
        /// Consulta una lista de conductores en la base de datos según los filtros proporcionados.
        /// </summary>
        /// <param name="objFiltro">Objeto <see cref="ConductorFiltro"/> con los criterios de búsqueda.</param>
        /// <returns>Lista de conductores encontrados. Si no hay coincidencias, retorna una lista vacía.</returns>
        List<Conductor> ConsultarListado(ConductorFiltro objFiltro);
    }
}
