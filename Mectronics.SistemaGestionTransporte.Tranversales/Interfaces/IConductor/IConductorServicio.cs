using Mectronics.SistemaGestionTransporte.Tranversales.Dtos;
using Mectronics.SistemaGestionTransporte.Tranversales.Filtros;

namespace Mectronics.SistemaGestionTransporte.Tranversales.Interfaces.IConductor
{
    /// <summary>
    /// Define las operaciones del servicio para la entidad <see cref="Conductor"/>, donde se dejarán las reglas de negocio.
    /// </summary>
    public interface IConductorServicio
    {
        /// <summary>
        /// Inserta un nuevo conductor en la base de datos.
        /// </summary>
        /// <param name="conductor">Objeto <see cref="ConductorDto"/> con la información a insertar.</param>
        /// <returns>Información del registro creado.</returns>
        ConductorDto Insertar(ConductorDto conductor);

        /// <summary>
        /// Actualiza un conductor existente en la base de datos.
        /// </summary>
        /// <param name="conductor">Objeto <see cref="ConductorDto"/> con la información actualizada.</param>
        /// <returns>Información del registro modificado.</returns>
        ConductorDto Actualizar(ConductorDto conductor);

        /// <summary>
        /// Elimina un conductor por su identificador.
        /// </summary>
        /// <param name="idConductor">Identificador único del conductor a eliminar.</param>
        /// <returns>El número de filas afectadas.</returns>
        int Eliminar(int idConductor);

        /// <summary>
        /// Consulta un conductor basado en los filtros proporcionados.
        /// </summary>
        /// <param name="objFiltro">Objeto <see cref="ConductorFiltro"/> con los criterios de búsqueda.</param>
        /// <returns>Registro encontrado.</returns>
        ConductorDto Consultar(ConductorFiltro objFiltro);

        /// <summary>
        /// Consulta una lista de conductores según los filtros proporcionados.
        /// </summary>
        /// <param name="objFiltro">Objeto <see cref="ConductorFiltro"/> con los criterios de búsqueda.</param>
        /// <returns>Lista de registros encontrados.</returns>
        List<ConductorDto> ConsultarLista(ConductorFiltro objFiltro);
    }
}
