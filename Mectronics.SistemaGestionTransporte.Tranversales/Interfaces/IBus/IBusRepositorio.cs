using Mectronics.SistemaGestionTransporte.Tranversales.Entidades;
using Mectronics.SistemaGestionTransporte.Tranversales.Filtros;

namespace Mectronics.SistemaGestionTransporte.Tranversales.Interfaces.IBus
{
    public interface IBusRepositorio
    {
        /// <summary>
        /// Inserta un nuevo bus en la base de datos.
        /// </summary>
        /// <param name="bus">Objeto <see cref="Bus"/> con la información a insertar.</param>
        /// <returns>El número de filas afectadas en la base de datos.</returns>        
        int Insertar(Bus bus);

        /// <summary>
        /// Actualiza un bus existente en la base de datos.
        /// </summary>
        /// <param name="bus">Objeto <see cref="Bus"/> con la información actualizada.</param>
        /// <returns>El número de filas afectadas en la base de datos.</returns>        
        int Actualizar(Bus bus);

        /// <summary>
        /// Elimina un bus de la base de datos por su identificador único.
        /// </summary>
        /// <param name="idBus">Identificador único del bus a eliminar.</param>
        /// <returns>El número de filas afectadas en la base de datos.</returns>        
        int Eliminar(int idBus);

        /// <summary>
        /// Consulta un bus en la base de datos basado en los filtros proporcionados.
        /// </summary>
        /// <param name="objFiltro">Objeto <see cref="BusFiltro"/> con los criterios de búsqueda.</param>
        /// <returns>Una instancia de <see cref="Bus"/> si se encuentra, de lo contrario, <c>null</c>.</returns>        
        Bus Consultar(BusFiltro objFiltro);

        /// <summary>
        /// Consulta una lista de buses en la base de datos según los filtros proporcionados.
        /// </summary>
        /// <param name="objFiltro">Objeto <see cref="BusFiltro"/> con los criterios de búsqueda.</param>
        /// <returns>Lista de buses encontrados. Si no hay coincidencias, retorna una lista vacía.</returns>        
        List<Bus> ConsultarListado(BusFiltro objFiltro);
    }
}
