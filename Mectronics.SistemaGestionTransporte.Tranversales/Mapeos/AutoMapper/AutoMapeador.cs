
using AutoMapper;
using Mectronics.SistemaGestionTransporte.Tranversales.Dtos;
using Mectronics.SistemaGestionTransporte.Tranversales.Entidades;

namespace Mectronics.SistemaGestionTransporte.Tranversales.Mapeos.AutoMapper
{
    /// <summary>
    /// Configuración de AutoMapper para el mapeo entre entidades y DTOs en la aplicación.
    /// </summary>
    public class AutoMapeador : Profile
    {
        /// <summary>
        /// Inicializa una nueva instancia de <see cref="AutoMapeador"/> y configura los mapeos.
        /// </summary>
        public AutoMapeador()
        {
            /// <summary>
            /// Configura el mapeo bidireccional entre entidades y DTOs.
            /// </summary>
            CreateMap<Bus, BusDto>().ReverseMap();
            CreateMap<BusHorario, BusHorarioDto>().ReverseMap();
            CreateMap<Conductor, ConductorDto>().ReverseMap();
            CreateMap<ConductorHorario, ConductorHorarioDto>().ReverseMap();
            CreateMap<EstadoBus, EstadoBusDto>().ReverseMap();
            CreateMap<EstadoConductor, EstadoConductorDto>().ReverseMap();
            CreateMap<Rol, RolDto>().ReverseMap();
            CreateMap<Usuario, UsuarioDto>().ReverseMap();
        }

    }

}
