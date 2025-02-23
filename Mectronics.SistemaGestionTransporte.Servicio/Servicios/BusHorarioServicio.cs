using AutoMapper;
using Mectronics.SistemaGestionTransporte.Tranversales.Dtos;
using Mectronics.SistemaGestionTransporte.Tranversales.Entidades;
using Mectronics.SistemaGestionTransporte.Tranversales.Filtros;
using Mectronics.SistemaGestionTransporte.Tranversales.Interfaces.IBusHorario;

namespace Mectronics.SistemaGestionTransporte.Servicio.Servicios
{
    /// <summary>
    /// Implementación de la capa de servicio para la entidad <see cref="BusHorario"/>.
    /// </summary>
    public class BusHorarioServicio : IBusHorarioServicio
    {
        /// <summary>
        /// Instancia del repositorio de horarios de buses para acceder a la base de datos.
        /// </summary>
        private readonly IBusHorarioRepositorio _repositorioBusHorario;

        /// <summary>
        /// Instancia de AutoMapper para realizar conversiones entre entidades y DTOs.
        /// </summary>
        private readonly IMapper _mapeo;

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="BusHorarioServicio"/> con un repositorio inyectado.
        /// </summary>
        /// <param name="repositorioBusHorario">Instancia del repositorio de horarios de buses.</param>
        /// <param name="mapeo">Instancia de AutoMapper para mapeo de entidades a DTOs.</param>
        public BusHorarioServicio(IBusHorarioRepositorio repositorioBusHorario, IMapper mapeo)
        {
            _repositorioBusHorario = repositorioBusHorario;
            _mapeo = mapeo;
        }

        /// <summary>
        /// Inserta un nuevo horario de bus en la base de datos.
        /// </summary>
        /// <param name="busHorarioDto">Objeto <see cref="BusHorarioDto"/> con la información a insertar.</param>
        /// <returns>Información del registro creado.</returns>
        public BusHorarioDto Insertar(BusHorarioDto busHorarioDto)
        {
            BusHorario busHorario = _mapeo.Map<BusHorario>(busHorarioDto);

            ValidarDatos(busHorario);

            busHorarioDto.IdBusHorario = _repositorioBusHorario.Insertar(busHorario);

            return busHorarioDto;
        }

        /// <summary>
        /// Actualiza un horario de bus existente en la base de datos.
        /// </summary>
        /// <param name="busHorarioDto">Objeto <see cref="BusHorarioDto"/> con la información actualizada.</param>
        /// <returns>Información del registro modificado.</returns>
        public BusHorarioDto Actualizar(BusHorarioDto busHorarioDto)
        {
            BusHorario busHorario = _mapeo.Map<BusHorario>(busHorarioDto);

            if (busHorario.IdBusHorario <= 0)
                throw new ArgumentException("El ID del horario de bus es inválido.");

            ValidarDatos(busHorario);

            int actualizo = _repositorioBusHorario.Actualizar(busHorario);

            if (actualizo <= 0)
                throw new ArgumentException("El registro no se actualizó.");

            return busHorarioDto;
        }

        /// <summary>
        /// Elimina un horario de bus por su identificador.
        /// </summary>
        /// <param name="idBusHorario">Identificador único del horario de bus a eliminar.</param>
        /// <returns>El número de filas afectadas.</returns>
        public int Eliminar(int idBusHorario)
        {
            if (idBusHorario <= 0)
                throw new ArgumentException("El ID del horario de bus es inválido.");

            return _repositorioBusHorario.Eliminar(idBusHorario);
        }

        /// <summary>
        /// Consulta una lista de horarios de buses según los filtros proporcionados.
        /// </summary>
        /// <param name="objFiltro">Objeto <see cref="BusHorarioFiltro"/> con los criterios de búsqueda.</param>
        /// <returns>Lista de registros encontrados.</returns>
        public List<BusHorarioDto> ConsultarLista(BusHorarioFiltro objFiltro)
        {
            if (objFiltro == null)
                throw new ArgumentNullException("El filtro no puede ser nulo.");

            List<BusHorario> busHorarios = _repositorioBusHorario.ConsultarListado(objFiltro);
            List<BusHorarioDto> busHorariosDto = _mapeo.Map<List<BusHorarioDto>>(busHorarios);

            return busHorariosDto;
        }
        /// <summary>
        /// Valida que los datos de un horario de bus sean correctos antes de insertarlo o actualizarlo.
        /// </summary>
        /// <param name="busHorario">Objeto <see cref="BusHorario"/> a validar.</param>        
        private void ValidarDatos(BusHorario busHorario)
        {
            if (busHorario == null)
                throw new ArgumentNullException("El registro no puede ser nulo.");

            if (busHorario.Bus == null || busHorario.Bus.IdBus <= 0)
                throw new ArgumentException("Debe asignarse un bus válido.");

            if (busHorario.Fecha == default)
                throw new ArgumentException("La fecha del horario es inválida.");

            if (string.IsNullOrWhiteSpace(busHorario.DiaSemana))
                throw new ArgumentException("El día de la semana no puede estar vacío.");

            if (busHorario.HoraEntrada == default)
                throw new ArgumentException("La hora de entrada es inválida.");

            if (busHorario.HoraSalida == default)
                throw new ArgumentException("La hora de salida es inválida.");
        }
    }
}
