using AutoMapper;
using Mectronics.SistemaGestionTransporte.Tranversales.Dtos;
using Mectronics.SistemaGestionTransporte.Tranversales.Filtros;
using Mectronics.SistemaGestionTransporte.Tranversales.Interfaces.IRol;

namespace Mectronics.SistemaGestionTransporte.Servicio.Servicios
{
    /// <summary>
    /// Implementación de la capa de servicio para la entidad <see cref="Rol"/>.
    /// </summary>
    public class RolServicio : IRolServicio
    {
        /// <summary>
        /// Instancia del repositorio de roles para acceder a la base de datos.
        /// </summary>
        private readonly IRolRepositorio _repositorioRol;

        /// <summary>
        /// Instancia de AutoMapper para realizar conversiones entre entidades y DTOs.
        /// </summary>
        private readonly IMapper _mapeo;

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="RolServicio"/> con un repositorio inyectado.
        /// </summary>
        /// <param name="repositorioRol">Instancia del repositorio de roles.</param>
        /// <param name="mapeo">Instancia de AutoMapper para mapeo de entidades a DTOs.</param>
        public RolServicio(IRolRepositorio repositorioRol, IMapper mapeo)
        {
            _repositorioRol = repositorioRol;
            _mapeo = mapeo;
        }

        /// <summary>
        /// Consulta un rol específico por su identificador.
        /// </summary>
        /// <param name="objFiltro">Objeto <see cref="RolFiltro"/> con los criterios de búsqueda.</param>
        /// <returns>Objeto <see cref="RolDto"/> con la información del rol consultado.</returns>
        public RolDto Consultar(RolFiltro objFiltro)
        {
            if (objFiltro.IdRol <= 0)
                throw new ArgumentException("El ID del rol es inválido.");

            var rol = _repositorioRol.Consultar(objFiltro);
            return _mapeo.Map<RolDto>(rol);
        }
    }
}
