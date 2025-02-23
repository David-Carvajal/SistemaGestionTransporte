using AutoMapper;
using Mectronics.SistemaGestionTransporte.Tranversales.Dtos;
using Mectronics.SistemaGestionTransporte.Tranversales.Entidades;
using Mectronics.SistemaGestionTransporte.Tranversales.Filtros;
using Mectronics.SistemaGestionTransporte.Tranversales.Interfaces.IConductorHorario;

namespace Mectronics.SistemaGestionTransporte.Servicio.Servicios
{
    /// <summary>
    /// Implementación de la capa de servicio para la entidad <see cref="ConductorHorario"/>.
    /// </summary>
    public class ConductorHorarioServicio : IConductorHorarioServicio
    {
        /// <summary>
        /// Instancia del repositorio de horarios de conductores para acceder a la base de datos.
        /// </summary>
        private readonly IConductorHorarioRepositorio _repositorioConductorHorario;

        /// <summary>
        /// Instancia de AutoMapper para realizar conversiones entre entidades y DTOs.
        /// </summary>
        private readonly IMapper _mapeo;

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="ConductorHorarioServicio"/> con un repositorio inyectado.
        /// </summary>
        /// <param name="repositorioConductorHorario">Instancia del repositorio de horarios de conductores.</param>
        /// <param name="mapeo">Instancia de AutoMapper para mapeo de entidades a DTOs.</param>
        public ConductorHorarioServicio(IConductorHorarioRepositorio repositorioConductorHorario, IMapper mapeo)
        {
            _repositorioConductorHorario = repositorioConductorHorario;
            _mapeo = mapeo;
        }

        /// <summary>
        /// Inserta un nuevo horario de conductor en la base de datos.
        /// </summary>
        /// <param name="conductorHorarioDto">Objeto <see cref="ConductorHorarioDto"/> con la información a insertar.</param>
        /// <returns>Información del registro creado.</returns>
        public ConductorHorarioDto Insertar(ConductorHorarioDto conductorHorarioDto)
        {
            ConductorHorario conductorHorario = _mapeo.Map<ConductorHorario>(conductorHorarioDto);
            ValidarDatos(conductorHorario);
            conductorHorarioDto.IdConductorHorario = _repositorioConductorHorario.Insertar(conductorHorario);
            return conductorHorarioDto;
        }

        /// <summary>
        /// Actualiza un horario de conductor existente en la base de datos.
        /// </summary>
        /// <param name="conductorHorarioDto">Objeto <see cref="ConductorHorarioDto"/> con la información actualizada.</param>
        /// <returns>Información del registro modificado.</returns>
        public ConductorHorarioDto Actualizar(ConductorHorarioDto conductorHorarioDto)
        {
            ConductorHorario conductorHorario = _mapeo.Map<ConductorHorario>(conductorHorarioDto);
            if (conductorHorario.IdConductorHorario <= 0)
                throw new ArgumentException("El ID del horario de conductor es inválido.");

            ValidarDatos(conductorHorario);
            int actualizo = _repositorioConductorHorario.Actualizar(conductorHorario);

            if (actualizo <= 0)
                throw new ArgumentException("El registro no se actualizó.");

            return conductorHorarioDto;
        }

        /// <summary>
        /// Elimina un horario de conductor por su identificador.
        /// </summary>
        /// <param name="idConductorHorario">Identificador único del horario de conductor a eliminar.</param>
        /// <returns>El número de filas afectadas.</returns>
        public int Eliminar(int idConductorHorario)
        {
            if (idConductorHorario <= 0)
                throw new ArgumentException("El ID del horario de conductor es inválido.");
            return _repositorioConductorHorario.Eliminar(idConductorHorario);
        }

        /// <summary>
        /// Consulta una lista de horarios de conductores según los filtros proporcionados.
        /// </summary>
        /// <param name="objFiltro">Objeto <see cref="ConductorHorarioFiltro"/> con los criterios de búsqueda.</param>
        /// <returns>Lista de registros encontrados.</returns>
        public List<ConductorHorarioDto> ConsultarLista(ConductorHorarioFiltro objFiltro)
        {
            if (objFiltro == null)
                throw new ArgumentNullException("El filtro no puede ser nulo.");

            List<ConductorHorario> conductorHorarios = _repositorioConductorHorario.ConsultarListado(objFiltro);
            List<ConductorHorarioDto> conductorHorariosDto = _mapeo.Map<List<ConductorHorarioDto>>(conductorHorarios);
            return conductorHorariosDto;
        }

        /// <summary>
        /// Valida que los datos de un horario de conductor sean correctos antes de insertarlo o actualizarlo.
        /// </summary>
        /// <param name="conductorHorario">Objeto <see cref="ConductorHorario"/> a validar.</param>        
        private void ValidarDatos(ConductorHorario conductorHorario)
        {
            if (conductorHorario == null)
                throw new ArgumentNullException("El registro no puede ser nulo.");

            if (conductorHorario.Conductor == null || conductorHorario.Conductor.IdConductor <= 0)
                throw new ArgumentException("Debe asignarse un conductor válido.");

            if (conductorHorario.Fecha == default)
                throw new ArgumentException("La fecha del horario es inválida.");

            if (conductorHorario.HoraEntrada == default)
                throw new ArgumentException("La hora de entrada es inválida.");

            if (conductorHorario.HoraSalida == default)
                throw new ArgumentException("La hora de salida es inválida.");
        }
    }
}
