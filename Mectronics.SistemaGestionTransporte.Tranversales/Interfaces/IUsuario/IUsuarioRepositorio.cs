
using Mectronics.SistemaGestionTransporte.Tranversales.Entidades;
using Mectronics.SistemaGestionTransporte.Tranversales.Filtros;

namespace Mectronics.SistemaGestionTransporte.Tranversales.Interfaces.IUsuario
{
    /// <summary>
    /// Define las operaciones de acceso a datos para la entidad <see cref="Usuario"/>.
    /// </summary>
    public interface IUsuarioRepositorio
    {
        /// <summary>
        /// Inserta un nuevo usuario en la base de datos.
        /// </summary>
        /// <param name="usuario">Objeto <see cref="Usuario"/> con la información a insertar.</param>
        /// <returns>El número de filas afectadas en la base de datos.</returns>
        int Insertar(Usuario usuario);

        /// <summary>
        /// Actualiza un usuario existente en la base de datos.
        /// </summary>
        /// <param name="usuario">Objeto <see cref="Usuario"/> con la información actualizada.</param>
        /// <returns>El número de filas afectadas en la base de datos.</returns>
        int Actualizar(Usuario usuario);

        /// <summary>
        /// Elimina un usuario de la base de datos por su identificador único.
        /// </summary>
        /// <param name="idUsuario">Identificador único del usuario a eliminar.</param>
        /// <returns>El número de filas afectadas en la base de datos.</returns>
        int Eliminar(int idUsuario);

        /// <summary>
        /// Consulta un usuario en la base de datos basado en los filtros proporcionados.
        /// </summary>
        /// <param name="objFiltro">Objeto <see cref="UsuarioFiltro"/> con los criterios de búsqueda.</param>
        /// <returns>Una instancia de <see cref="Usuario"/> si se encuentra, de lo contrario, <c>null</c>.</returns>
        Usuario Consultar(UsuarioFiltro objFiltro);

        /// <summary>
        /// Consulta una lista de usuarios en la base de datos según los filtros proporcionados.
        /// </summary>
        /// <param name="objFiltro">Objeto <see cref="UsuarioFiltro"/> con los criterios de búsqueda.</param>
        /// <returns>Lista de usuarios encontrados. Si no hay coincidencias, retorna una lista vacía.</returns>
        List<Usuario> ConsultarListado(UsuarioFiltro objFiltro);

        /// <summary>
        /// Obtiene un usuario por su ID.
        /// </summary>
        /// <param name="idUsuario">ID del usuario.</param>
        /// <returns>El usuario encontrado.</returns>
        Usuario ObtenerPorId(int idUsuario);
    }

}
