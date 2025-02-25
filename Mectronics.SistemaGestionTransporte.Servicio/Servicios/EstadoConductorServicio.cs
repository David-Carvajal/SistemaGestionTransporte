using AutoMapper;
using Mectronics.SistemaGestionTransporte.Tranversales.Dtos;
using Mectronics.SistemaGestionTransporte.Tranversales.Entidades;
using Mectronics.SistemaGestionTransporte.Tranversales.Filtros;
using Mectronics.SistemaGestionTransporte.Tranversales.Interfaces.IEstadoConductor;

namespace Mectronics.SistemaGestionTransporte.Servicio.Servicios
{
    /// <summary>
    /// Implementación de la capa de servicio para la entidad <see cref="EstadoConductor"/>.
    /// </summary>
    public class EstadoConductorServicio : IEstadoConductorServicio
    {
        /// <summary>
        /// Instancia del repositorio de estados de conductores para acceder a la base de datos.
        /// </summary>
        private readonly IEstadoConductorRepositorio _repositorioEstadoConductor;

        /// <summary>
        /// Instancia de AutoMapper para realizar conversiones entre entidades y DTOs.
        /// </summary>
        private readonly IMapper _mapeo;

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="EstadoConductorServicio"/> con un repositorio inyectado.
        /// </summary>
        /// <param name="repositorioEstadoConductor">Instancia del repositorio de estados de conductores.</param>
        /// <param name="mapeo">Instancia de AutoMapper para mapeo de entidades a DTOs.</param>
        public EstadoConductorServicio(IEstadoConductorRepositorio repositorioEstadoConductor, IMapper mapeo)
        {
            _repositorioEstadoConductor = repositorioEstadoConductor;
            _mapeo = mapeo;
        }

        /// <summary>
        /// Consulta un estado de conductor específico por su identificador.
        /// </summary>
        /// <param name="idEstadoConductor">Identificador único del estado de conductor a consultar.</param>
        /// <returns>Objeto <see cref="EstadoConductorDto"/> con la información del estado de conductor consultado.</returns>
        public List<EstadoConductorDto> ConsultarLista()
        {
            List <EstadoConductor> estado = _repositorioEstadoConductor.ConsultarLista();
            return _mapeo.Map<List<EstadoConductorDto>>(estado);
        }
    }
}
