using Mectronics.SistemaGestionTransporte.Tranversales.Entidades;
using Mectronics.SistemaGestionTransporte.Tranversales.Filtros;

namespace Mectronics.SistemaGestionTransporte.Tranversales.Interfaces.IBusHorario
{
    /// <summary>
    /// Define las operaciones de acceso a datos para la entidad <see cref="BusHorario"/>.
    /// </summary>
    public interface IBusHorarioRepositorio
    {
        /// <summary>
        /// Inserta un nuevo registro de horario de bus en la base de datos.
        /// </summary>
        int Insertar(BusHorario busHorario);

        /// <summary>
        /// Actualiza un registro de horario de bus en la base de datos.
        /// </summary>
        int Actualizar(BusHorario busHorario);

        /// <summary>
        /// Elimina un registro de horario de bus en la base de datos.
        /// </summary>
        int Eliminar(int idBusHorario);

        /// <summary>
        /// Consulta un horario de bus en la base de datos basado en los filtros proporcionados.
        /// </summary>
        BusHorario Consultar(BusHorarioFiltro objFiltro);

        /// <summary>
        /// Consulta una lista de horarios de buses en la base de datos.
        /// </summary>
        List<BusHorario> ConsultarListado(BusHorarioFiltro objFiltro);
    }
}
