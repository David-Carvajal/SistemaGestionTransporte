
using Mectronics.SistemaGestionTransporte.Tranversales.Dtos;
using Mectronics.SistemaGestionTransporte.Tranversales.Filtros;

namespace Mectronics.SistemaGestionTransporte.Tranversales.Interfaces.IUsuario
{
    /// <summary>
    /// Define las operaciones del servicio para la entidad <see cref="Usuario"/>, donde se dejarán las reglas de negocio.
    /// </summary>
    public interface IUsuarioServicio
    {
        /// <summary>
        /// Inserta un nuevo usuario en la base de datos.
        /// </summary>
        /// <param name="usuario">Objeto <see cref="UsuarioDto"/> con la información a insertar.</param>
        /// <returns>Información del registro creado.</returns>
        UsuarioDto Insertar(UsuarioDto usuario);

        /// <summary>
        /// Actualiza un usuario existente en la base de datos.
        /// </summary>
        /// <param name="usuario">Objeto <see cref="UsuarioDto"/> con la información actualizada.</param>
        /// <returns>Información del registro modificado.</returns>
        UsuarioDto Actualizar(UsuarioDto usuario);

        /// <summary>
        /// Elimina un usuario por su identificador.
        /// </summary>
        /// <param name="idUsuario">Identificador único del usuario a eliminar.</param>
        /// <returns>El número de filas afectadas.</returns>
        int Eliminar(int idUsuario);

        /// <summary>
        /// Consulta un usuario basado en los filtros proporcionados.
        /// </summary>
        /// <param name="objFiltro">Objeto <see cref="UsuarioFiltro"/> con los criterios de búsqueda.</param>
        /// <returns>Registro encontrado.</returns>
        UsuarioDto Consultar(UsuarioFiltro objFiltro);

        /// <summary>
        /// Consulta una lista de usuarios según los filtros proporcionados.
        /// </summary>
        /// <param name="objFiltro">Objeto <see cref="UsuarioFiltro"/> con los criterios de búsqueda.</param>
        /// <returns>Lista de registros encontrados.</returns>
        List<UsuarioDto> ConsultarLista(UsuarioFiltro objFiltro);
    }
}
