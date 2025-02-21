using Mectronics.SistemaGestionTransporte.Tranversales.Dtos;
using Mectronics.SistemaGestionTransporte.Tranversales.Filtros;

namespace Mectronics.SistemaGestionTransporte.Tranversales.Interfaces.IConductorHorario
{
    /// <summary>
    /// Define las operaciones del servicio para la entidad <see cref="ConductorHorario"/>, donde se dejarán las reglas de negocio.
    /// </summary>
    public interface IConductorHorarioServicio
    {
        /// <summary>
        /// Inserta un nuevo horario de conductor en la base de datos.
        /// </summary>
        /// <param name="conductorHorario">Objeto <see cref="ConductorHorarioDto"/> con la información a insertar.</param>
        /// <returns>Información del registro creado.</returns>
        ConductorHorarioDto Insertar(ConductorHorarioDto conductorHorario);

        /// <summary>
        /// Actualiza un horario de conductor existente en la base de datos.
        /// </summary>
        /// <param name="conductorHorario">Objeto <see cref="ConductorHorarioDto"/> con la información actualizada.</param>
        /// <returns>Información del registro modificado.</returns>
        ConductorHorarioDto Actualizar(ConductorHorarioDto conductorHorario);

        /// <summary>
        /// Elimina un horario de conductor por su identificador.
        /// </summary>
        /// <param name="idConductorHorario">Identificador único del horario del conductor a eliminar.</param>
        /// <returns>El número de filas afectadas.</returns>
        int Eliminar(int idConductorHorario);

        /// <summary>
        /// Consulta una lista de horarios de conductores según los filtros proporcionados.
        /// </summary>
        /// <param name="objFiltro">Objeto <see cref="ConductorHorarioFiltro"/> con los criterios de búsqueda.</param>
        /// <returns>Lista de registros encontrados.</returns>
        List<ConductorHorarioDto> ConsultarLista(ConductorHorarioFiltro objFiltro);
    }
}
