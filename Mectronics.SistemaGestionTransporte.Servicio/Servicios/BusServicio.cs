using AutoMapper;
using Mectronics.SistemaGestionTransporte.Tranversales.Dtos;
using Mectronics.SistemaGestionTransporte.Tranversales.Entidades;
using Mectronics.SistemaGestionTransporte.Tranversales.Filtros;
using Mectronics.SistemaGestionTransporte.Tranversales.Interfaces.IBus;

namespace Mectronics.SistemaGestionTransporte.Servicio.Servicios
{
    /// <summary>
    /// Implementación de la capa de servicio para la entidad <see cref="Bus"/>.
    /// </summary>
    public class BusServicio : IBusServicio
    {
        /// <summary>
        /// Instancia del repositorio de buses para acceder a la base de datos.
        /// </summary>
        private readonly IBusRepositorio _repositorioBus;

        /// <summary>
        /// Instancia de AutoMapper para realizar conversiones entre entidades y DTOs.
        /// </summary>
        private readonly IMapper _mapeo;

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="BusServicio"/> con un repositorio inyectado.
        /// </summary>
        /// <param name="repositorioBus">Instancia del repositorio de buses.</param>
        /// <param name="mapeo">Instancia de AutoMapper para mapeo de entidades a DTOs.</param>
        public BusServicio(IBusRepositorio repositorioBus, IMapper mapeo)
        {
            _repositorioBus = repositorioBus;
            _mapeo = mapeo;
        }

        /// <summary>
        /// Inserta un nuevo bus en la base de datos.
        /// </summary>
        /// <param name="bus">Objeto <see cref="BusDto"/> con la información a insertar.</param>
        /// <returns>Información del registro creado.</returns>
        public BusDto Insertar(BusDto busDto)
        {
            Bus bus = _mapeo.Map<Bus>(busDto);

            ValidarDatos(bus);

            busDto.IdBus = _repositorioBus.Insertar(bus);

            return busDto;
        }

        /// <summary>
        /// Actualiza un bus existente en la base de datos.
        /// </summary>
        /// <param name="bus">Objeto <see cref="BusDto"/> con la información actualizada.</param>
        /// <returns>Información del registro modificado.</returns>
        public BusDto Actualizar(BusDto busDto)
        {
            Bus bus = _mapeo.Map<Bus>(busDto);

            if (bus.IdBus <= 0)
                throw new ArgumentException("El ID del bus es inválido.");

            ValidarDatos(bus);

            int actualizo = _repositorioBus.Actualizar(bus);

            if (actualizo <= 0)
                throw new ArgumentException("El registro no se actualizó.");

            return busDto;
        }

        /// <summary>
        /// Elimina un bus por su identificador.
        /// </summary>
        /// <param name="idBus">Identificador único del bus a eliminar.</param>
        /// <returns>El número de filas afectadas.</returns>
        public int Eliminar(int idBus)
        {
            if (idBus <= 0)
                throw new ArgumentException("El ID del bus es inválido.");

            return _repositorioBus.Eliminar(idBus);
        }

        /// <summary>
        /// Consulta un bus basado en los filtros proporcionados.
        /// </summary>
        /// <param name="objFiltro">Objeto <see cref="BusFiltro"/> con los criterios de búsqueda.</param>
        /// <returns>Registro encontrado.</returns>
        public BusDto Consultar(BusFiltro objFiltro)
        {
            if (objFiltro == null)
                throw new ArgumentNullException("El filtro no puede ser nulo.");

            Bus bus = _repositorioBus.Consultar(objFiltro);
            BusDto busDto = _mapeo.Map<BusDto>(bus);

            return busDto;
        }

        /// <summary>
        /// Consulta una lista de buses según los filtros proporcionados.
        /// </summary>
        /// <param name="objFiltro">Objeto <see cref="BusFiltro"/> con los criterios de búsqueda.</param>
        /// <returns>Lista de registros encontrados.</returns>
        public List<BusDto> ConsultarLista(BusFiltro objFiltro)
        {
            if (objFiltro == null)
                throw new ArgumentNullException("El filtro no puede ser nulo.");

            List<Bus> buses = _repositorioBus.ConsultarListado(objFiltro);
            List<BusDto> busesDto = _mapeo.Map<List<BusDto>>(buses);

            return busesDto;
        }

        /// <summary>
        /// Valida que los datos de un bus sean correctos antes de insertarlo o actualizarlo.
        /// </summary>
        /// <param name="bus">Objeto <see cref="Bus"/> a validar.</param>
        private void ValidarDatos(Bus bus)
        {
            if (bus == null)
                throw new ArgumentNullException("El registro no puede ser nulo.");

            if (string.IsNullOrWhiteSpace(bus.Modelo))
                throw new ArgumentException("El modelo del bus debe ser mayor a 0.");

            if (bus.Capacidad <= 0)
                throw new ArgumentException("La capacidad del bus debe ser mayor a 0.");

            if (string.IsNullOrWhiteSpace(bus.Placa))
                throw new ArgumentException("La placa del bus no puede estar vacía.");

            if (bus.EstadoBus == null)
                throw new ArgumentException("El estado del bus no puede ser nulo.");
        }
    }
}