using AutoMapper;
using Mectronics.SistemaGestionTransporte.Tranversales.Dtos;
using Mectronics.SistemaGestionTransporte.Tranversales.Entidades;
using Mectronics.SistemaGestionTransporte.Tranversales.Filtros;
using Mectronics.SistemaGestionTransporte.Tranversales.Interfaces.IConductor;
using Mectronics.SistemaGestionTransporte.Tranversales.Interfaces.IUsuario;

namespace Mectronics.SistemaGestionTransporte.Servicio.Servicios
{
    /// <summary>
    /// Implementación de la capa de servicio para la entidad <see cref="Conductor"/>.
    /// </summary>
    public class ConductorServicio : IConductorServicio
    {
        /// <summary>
        /// Instancia del repositorio de conductores para acceder a la base de datos.
        /// </summary>
        private readonly IConductorRepositorio _repositorioConductor;

        private readonly IUsuarioRepositorio _repositorioUsuario;

        /// <summary>
        /// Instancia de AutoMapper para realizar conversiones entre entidades y DTOs.
        /// </summary>
        private readonly IMapper _mapeo;

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="ConductorServicio"/> con un repositorio inyectado.
        /// </summary>
        /// <param name="repositorioConductor">Instancia del repositorio de conductores.</param>
        /// <param name="mapeo">Instancia de AutoMapper para mapeo de entidades a DTOs.</param>
        public ConductorServicio(IConductorRepositorio repositorioConductor, IUsuarioRepositorio repositorioUsuario, IMapper mapeo)
        {
            _repositorioConductor = repositorioConductor;
            _repositorioUsuario = repositorioUsuario;
            _mapeo = mapeo;
        }

        /// <summary>
        /// Inserta un nuevo conductor en la base de datos.
        /// </summary>
        /// <param name="conductorDto">Objeto <see cref="ConductorDto"/> con la información a insertar.</param>
        /// <returns>Información del registro creado.</returns>
        public ConductorDto Insertar(ConductorDto conductorDto)
        {
            Conductor conductor = _mapeo.Map<Conductor>(conductorDto);

            // Insertar el Usuario
            conductor.Usuario.IdUsuario = _repositorioUsuario.Insertar(conductor.Usuario);

            ValidarDatos(conductor);

            conductorDto.IdConductor = _repositorioConductor.Insertar(conductor);

            return conductorDto;
        }

        /// <summary>
        /// Actualiza un conductor existente en la base de datos.
        /// </summary>
        /// <param name="conductorDto">Objeto <see cref="ConductorDto"/> con la información actualizada.</param>
        /// <returns>Información del registro modificado.</returns>
        public ConductorDto Actualizar(ConductorDto conductorDto)
        {
            Conductor conductor = _mapeo.Map<Conductor>(conductorDto);

            if (conductor.IdConductor <= 0)
                throw new ArgumentException("El ID del conductor es inválido.");

            ValidarDatos(conductor);

            int actualizoUsuario = _repositorioUsuario.Actualizar(conductor.Usuario);

            int actualizo = _repositorioConductor.Actualizar(conductor);

            if (actualizo <= 0 || actualizoUsuario <= 0)
                throw new ArgumentException("El registro no se actualizó.");

            return conductorDto;
        }

        /// <summary>
        /// Elimina un conductor por su identificador.
        /// </summary>
        /// <param name="idConductor">Identificador único del conductor a eliminar.</param>
        /// <returns>El número de filas afectadas.</returns>
        public int Eliminar(int idConductor)
        {
            if (idConductor <= 0)
                throw new ArgumentException("El ID del conductor es inválido.");

            return _repositorioConductor.Eliminar(idConductor);
        }

        /// <summary>
        /// Consulta un conductor basado en los filtros proporcionados.
        /// </summary>
        /// <param name="objFiltro">Objeto <see cref="ConductorFiltro"/> con los criterios de búsqueda.</param>
        /// <returns>Registro encontrado.</returns>
        public ConductorDto Consultar(ConductorFiltro objFiltro)
        {
            if (objFiltro == null)
                throw new ArgumentNullException("El filtro no puede ser nulo.");

            Conductor conductor = _repositorioConductor.Consultar(objFiltro);
            ConductorDto conductorDto = _mapeo.Map<ConductorDto>(conductor);

            return conductorDto;
        }

        /// <summary>
        /// Consulta una lista de conductores según los filtros proporcionados.
        /// </summary>
        /// <param name="objFiltro">Objeto <see cref="ConductorFiltro"/> con los criterios de búsqueda.</param>
        /// <returns>Lista de registros encontrados.</returns>
        public List<ConductorDto> ConsultarLista(ConductorFiltro objFiltro)
        {
            if (objFiltro == null)
                throw new ArgumentNullException("El filtro no puede ser nulo.");

            List<Conductor> conductores = _repositorioConductor.ConsultarListado(objFiltro);
            List<ConductorDto> conductoresDto = _mapeo.Map<List<ConductorDto>>(conductores);

            return conductoresDto;
        }

        /// <summary>
        /// Valida que los datos de un conductor sean correctos antes de insertarlo o actualizarlo.
        /// </summary>
        /// <param name="conductor">Objeto <see cref="Conductor"/> a validar.</param>
        private void ValidarDatos(Conductor conductor)
        {
            if (conductor == null)
                throw new ArgumentNullException("El registro no puede ser nulo.");

            if (string.IsNullOrWhiteSpace(conductor.NumeroLicencia))
                throw new ArgumentException("El número de licencia no puede estar vacío.");

            if (conductor.Usuario == null)
                throw new ArgumentException("El usuario asociado es inválido.");
        }
    }
}
