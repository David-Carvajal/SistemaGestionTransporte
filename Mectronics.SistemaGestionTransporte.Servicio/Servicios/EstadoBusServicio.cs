
using AutoMapper;
using Mectronics.SistemaGestionTransporte.Tranversales.Dtos;
using Mectronics.SistemaGestionTransporte.Tranversales.Entidades;
using Mectronics.SistemaGestionTransporte.Tranversales.Filtros;
using Mectronics.SistemaGestionTransporte.Tranversales.Interfaces.IEstadoBus;

namespace Mectronics.SistemaGestionTransporte.Servicio.Servicios
{
    /// <summary>
    /// Implementación del servicio para la entidad <see cref="EstadoBus"/>.
    /// </summary>
    public class EstadoBusServicio : IEstadoBusServicio
    {
        /// <summary>
        /// Instancia del repositorio de estado de buses para acceder a la base de datos.
        /// </summary>
        private readonly IEstadoBusRepositorio _repositorioEstadoBus;

        /// <summary>
        /// Instancia de AutoMapper para realizar conversiones entre entidades y DTOs.
        /// </summary>
        private readonly IMapper _mapeo;

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="EstadoBusServicio"/> con un repositorio inyectado.
        /// </summary>
        /// <param name="repositorioEstadoBus">Instancia del repositorio de estados de buses.</param>
        /// <param name="mapeo">Instancia de AutoMapper para mapeo de entidades a DTOs.</param>
        public EstadoBusServicio(IEstadoBusRepositorio repositorioEstadoBus, IMapper mapeo)
        {
            _repositorioEstadoBus = repositorioEstadoBus;
            _mapeo = mapeo;
        }

        public List<EstadoBusDto> Consultar(EstadoBusFiltro objFiltro)
        {
            List<EstadoBus> estados = _repositorioEstadoBus.Consultar(objFiltro);
            return _mapeo.Map<List<EstadoBusDto>>(estados);
        }
    }
}
