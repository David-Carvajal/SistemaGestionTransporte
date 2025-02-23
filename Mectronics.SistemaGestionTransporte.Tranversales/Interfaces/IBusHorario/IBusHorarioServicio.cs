using Mectronics.SistemaGestionTransporte.Tranversales.Dtos;
using Mectronics.SistemaGestionTransporte.Tranversales.Entidades;
using Mectronics.SistemaGestionTransporte.Tranversales.Filtros;

namespace Mectronics.SistemaGestionTransporte.Tranversales.Interfaces.IBusHorario
{
    /// <summary>
    /// Define las operaciones del servicio para la entidad <see cref="Bus"/>, donde se dejarán las reglas de negocio.
    /// </summary>
    public interface IBusHorarioServicio
    {
        /// <summary>
        /// Inserta un nuevo bus en la base de datos.
        /// </summary>
        /// <param name="bus">Objeto <see cref="BusDto"/> con la información a insertar.</param>
        /// <returns>Información del registro creado.</returns>
        BusHorarioDto Insertar(BusHorarioDto bus);

        /// <summary>
        /// Actualiza un bus existente en la base de datos.
        /// </summary>
        /// <param name="bus">Objeto <see cref="BusDto"/> con la información actualizada.</param>
        /// <returns>Información del registro modificado.</returns>
        BusHorarioDto Actualizar(BusHorarioDto bus);

        /// <summary>
        /// Elimina un bus por su identificador.
        /// </summary>
        /// <param name="idBus">Identificador único del bus a eliminar.</param>
        /// <returns>El número de filas afectadas.</returns>
        int Eliminar(int idBus);

        /// <summary>
        /// Consulta una lista de buses según los filtros proporcionados.
        /// </summary>
        /// <param name="objFiltro">Objeto <see cref="BusFiltro"/> con los criterios de búsqueda.</param>
        /// <returns>Lista de registros encontrados.</returns>
        List<BusHorarioDto> ConsultarLista(BusHorarioFiltro objFiltro);
    }
}
