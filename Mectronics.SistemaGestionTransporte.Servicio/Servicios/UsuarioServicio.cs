
using AutoMapper;
using Mectronics.SistemaGestionTransporte.Tranversales.Dtos;
using Mectronics.SistemaGestionTransporte.Tranversales.Entidades;
using Mectronics.SistemaGestionTransporte.Tranversales.Filtros;
using Mectronics.SistemaGestionTransporte.Tranversales.Interfaces.IUsuario;

namespace Mectronics.SistemaGestionTransporte.Servicio.Servicios
{
    /// <summary>
    /// Implementación de la capa de servicio para la entidad <see cref="Usuario"/>.
    /// </summary>
    public class UsuarioServicio : IUsuarioServicio
    {
        /// <summary>
        /// Instancia del repositorio de usuarios para acceder a la base de datos.
        /// </summary>
        private readonly IUsuarioRepositorio _repositorioUsuario;

        /// <summary>
        /// Instancia de AutoMapper para realizar conversiones entre entidades y DTOs.
        /// </summary>
        private readonly IMapper _mapeo;

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="UsuarioServicio"/> con un repositorio inyectado.
        /// </summary>
        /// <param name="repositorioUsuario">Instancia del repositorio de usuarios.</param>
        /// <param name="mapeo">Instancia de AutoMapper para mapeo de entidades a DTOs.</param>
        public UsuarioServicio(IUsuarioRepositorio repositorioUsuario, IMapper mapeo)
        {
            _repositorioUsuario = repositorioUsuario;
            _mapeo = mapeo;
        }

        /// <summary>
        /// Inserta un nuevo usuario en la base de datos.
        /// </summary>
        /// <param name="usuarioDto">Objeto <see cref="UsuarioDto"/> con la información a insertar.</param>
        /// <returns>Información del registro creado.</returns>
        public UsuarioDto Insertar(UsuarioDto usuarioDto)
        {
            Usuario usuario = _mapeo.Map<Usuario>(usuarioDto);
            ValidarDatos(usuario);
            usuarioDto.IdUsuario = _repositorioUsuario.Insertar(usuario);
            return usuarioDto;
        }

        /// <summary>
        /// Actualiza un usuario existente en la base de datos.
        /// </summary>
        /// <param name="usuarioDto">Objeto <see cref="UsuarioDto"/> con la información actualizada.</param>
        /// <returns>Información del registro modificado.</returns>
        public UsuarioDto Actualizar(UsuarioDto usuarioDto)
        {
            if (usuarioDto == null)
                throw new ArgumentNullException("El DTO no puede ser nulo.");

            if (usuarioDto.IdUsuario <= 0)
                throw new ArgumentException("El ID del usuario es inválido.");

            // Obtener la entidad actual desde la base de datos
            Usuario usuarioActual = _repositorioUsuario.ObtenerPorId(usuarioDto.IdUsuario);

            if (usuarioActual == null)
                throw new ArgumentException("El usuario no existe.");

            // Actualizar solo los campos modificados
            if (!string.IsNullOrWhiteSpace(usuarioDto.Nombre))
                usuarioActual.Nombre = usuarioDto.Nombre;

            if (!string.IsNullOrWhiteSpace(usuarioDto.Correo))
                usuarioActual.Correo = usuarioDto.Correo;

            if (!string.IsNullOrWhiteSpace(usuarioDto.Contrasena))
                usuarioActual.Contrasena = usuarioDto.Contrasena;

            if (usuarioDto.Rol != null && usuarioDto.Rol.IdRol > 0)
            {
                //asignar solo el IdRol
                usuarioActual.Rol = new Rol { IdRol = usuarioDto.Rol.IdRol };
            }
               
            // Validar los datos antes de actualizar
            ValidarDatos(usuarioActual);

            // Actualizar la entidad en la base de datos
            int actualizo = _repositorioUsuario.Actualizar(usuarioActual);

            if (actualizo <= 0)
                throw new ArgumentException("El registro no se actualizó.");

            // Devolver el DTO actualizado
            return _mapeo.Map<UsuarioDto>(usuarioActual);
        }

        /// <summary>
        /// Elimina un usuario por su identificador.
        /// </summary>
        /// <param name="idUsuario">Identificador único del usuario a eliminar.</param>
        /// <returns>El número de filas afectadas.</returns>
        public int Eliminar(int idUsuario)
        {
            if (idUsuario <= 0)
                throw new ArgumentException("El ID del usuario es inválido.");

            return _repositorioUsuario.Eliminar(idUsuario);
        }

        /// <summary>
        /// Consulta un usuario basado en los filtros proporcionados.
        /// </summary>
        /// <param name="objFiltro">Objeto <see cref="UsuarioFiltro"/> con los criterios de búsqueda.</param>
        /// <returns>Registro encontrado.</returns>
        public UsuarioDto Consultar(UsuarioFiltro objFiltro)
        {
            if (objFiltro == null)
                throw new ArgumentNullException("El filtro no puede ser nulo.");

            Usuario usuario = _repositorioUsuario.Consultar(objFiltro);
            UsuarioDto usuarioDto = _mapeo.Map<UsuarioDto>(usuario);

            return usuarioDto;
        }

        /// <summary>
        /// Consulta una lista de usuarios según los filtros proporcionados.
        /// </summary>
        /// <param name="objFiltro">Objeto <see cref="UsuarioFiltro"/> con los criterios de búsqueda.</param>
        /// <returns>Lista de registros encontrados.</returns>
        public List<UsuarioDto> ConsultarLista(UsuarioFiltro objFiltro)
        {
            if (objFiltro == null)
                throw new ArgumentNullException("El filtro no puede ser nulo.");

            List<Usuario> usuarios = _repositorioUsuario.ConsultarListado(objFiltro);
            List<UsuarioDto> usuariosDto = _mapeo.Map<List<UsuarioDto>>(usuarios);

            return usuariosDto;
        }

        /// <summary>
        /// Valida que los datos de un usuario sean correctos antes de insertarlo o actualizarlo.
        /// </summary>
        /// <param name="usuario">Objeto <see cref="Usuario"/> a validar.</param>
        private void ValidarDatos(Usuario usuario)
        {
            if (usuario == null)
                throw new ArgumentNullException("El registro no puede ser nulo.");

            if (string.IsNullOrWhiteSpace(usuario.Nombre))
                throw new ArgumentException("El nombre del usuario no puede estar vacío.");

            if (string.IsNullOrWhiteSpace(usuario.Correo))
                throw new ArgumentException("El correo del usuario no puede estar vacío.");

            if (string.IsNullOrWhiteSpace(usuario.Contrasena))
                throw new ArgumentException("La contraseña del usuario no puede estar vacía.");

            if (usuario.Rol == null || usuario.Rol.IdRol <= 0)
                throw new ArgumentException("El rol del usuario es inválido.");
        }
    }
}
