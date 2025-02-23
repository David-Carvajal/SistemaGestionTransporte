using AutoMapper;
using Mectronics.SistemaGestionTransporte.Tranversales.Dtos;
using Mectronics.SistemaGestionTransporte.Tranversales.Entidades;
using Mectronics.SistemaGestionTransporte.Tranversales.Filtros;
using Mectronics.SistemaGestionTransporte.Tranversales.Interfaces.ISeguridad;
using Mectronics.SistemaGestionTransporte.Tranversales.Interfaces.IUsuario;

namespace Mectronics.SistemaGestionTransporte.Servicio.Servicios
{
    public class SeguridadServicio : ISeguridadServicio
    {
        /// <summary>
        /// Instancia del repositorio de usuarios para acceder a la base de datos.
        /// </summary>
        private readonly IUsuarioRepositorio _repositorioUsuario;

        /// <summary>
        /// Instancia de AutoMapper para realizar conversiones entre entidades y DTOs.
        /// </summary>
        private readonly IMapper _mapeo;

        public SeguridadServicio(IUsuarioRepositorio repositorioUsuario, IMapper mapeo)
        {
            _repositorioUsuario = repositorioUsuario;
            _mapeo = mapeo;
        }

        /// <summary>
        /// Valida las credenciales de un usuario en el sistema.
        /// </summary>
        /// <param name="autenticacion">Objeto con las credenciales de autenticación.</param>
        /// <returns>Objeto <see cref="UsuarioDto"/> con la información del usuario autenticado.</returns>
        /// <exception cref="ArgumentException">Se lanza si el correo o la contraseña no son válidos.</exception>
        public UsuarioDto ValidarUsuario(AutenticacionDto autenticacion)
        {
            // Validar que el correo no esté vacío o solo contenga espacios en blanco.
            if (string.IsNullOrWhiteSpace(autenticacion.Correo))
                throw new ArgumentException("El correo es requerido para la autenticación.");

            // Validar que la contraseña no esté vacía o solo contenga espacios en blanco.
            if (string.IsNullOrWhiteSpace(autenticacion.Contrasena))
                throw new ArgumentException("La contraseña es requerida para la autenticación.");

            // Crear un filtro para buscar el usuario por correo en la base de datos.
            UsuarioFiltro filtro = new UsuarioFiltro() { Correo = autenticacion.Correo };

            // Consultar el primer usuario que coincida con el filtro.
            Usuario usuario = _repositorioUsuario.ConsultarListado(filtro).FirstOrDefault();

            // Si no se encuentra un usuario con el correo proporcionado, lanzar excepción.
            if (usuario == null)
            {
                throw new ArgumentException("El usuario no existe.");
            }

            // Verificar si la contraseña proporcionada es incorrecta.
            if (autenticacion.Contrasena != usuario.Contrasena)
                throw new ArgumentException("La contraseña es incorrecta.");

            // Limpiar la contraseña del usuario antes de devolverlo por seguridad.
            usuario.Contrasena = string.Empty;

            // Mapear el usuario a un DTO y devolverlo.
            return _mapeo.Map<UsuarioDto>(usuario);
        }
    }
}

