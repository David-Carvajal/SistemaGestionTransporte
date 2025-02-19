using Mectronics.SistemaGestionTransporte.Tranversales.Entidades;
using Mectronics.SistemaGestionTransporte.Tranversales.Filtros;

namespace Mectronics.SistemaGestionTransporte.Tranversales.Interfaces.IConductorHorario
{
    /// <summary>
    /// Define las operaciones de acceso a datos para la entidad <see cref="ConductorHorario"/>.
    /// </summary>
    public interface IConductorHorarioRepositorio
    {
        /// <summary>
        /// Inserta un nuevo horario de conductor en la base de datos.
        /// </summary>
        /// <param name="conductorHorario">Objeto <see cref="ConductorHorario"/> con la información a insertar.</param>
        /// <returns>El número de filas afectadas en la base de datos.</returns>
        int Insertar(ConductorHorario conductorHorario);

        /// <summary>
        /// Actualiza un horario de conductor existente en la base de datos.
        /// </summary>
        /// <param name="conductorHorario">Objeto <see cref="ConductorHorario"/> con la información actualizada.</param>
        /// <returns>El número de filas afectadas en la base de datos.</returns>
        int Actualizar(ConductorHorario conductorHorario);

        /// <summary>
        /// Elimina un horario de conductor de la base de datos por su identificador único.
        /// </summary>
        /// <param name="idConductorHorario">Identificador único del horario de conductor a eliminar.</param>
        /// <returns>El número de filas afectadas en la base de datos.</returns>
        int Eliminar(int idConductorHorario);

        /// <summary>
        /// Consulta un horario de conductor en la base de datos basada en los filtros proporcionados.
        /// </summary>
        /// <param name="objFiltro">Objeto <see cref="ConductorHorarioFiltro"/> con los criterios de búsqueda.</param>
        /// <returns>Una instancia de <see cref="ConductorHorario"/> si se encuentra, de lo contrario, <c>null</c>.</returns>
        ConductorHorario Consultar(ConductorHorarioFiltro objFiltro);

        /// <summary>
        /// Consulta una lista de horarios de conductor en la base de datos según los filtros proporcionados.
        /// </summary>
        /// <param name="objFiltro">Objeto <see cref="ConductorHorarioFiltro"/> con los criterios de búsqueda.</param>
        /// <returns>Lista de horarios de conductor encontrados. Si no hay coincidencias, retorna una lista vacía.</returns>
        List<ConductorHorario> ConsultarListado(ConductorHorarioFiltro objFiltro);
    }
}