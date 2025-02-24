
using Mectronics.SistemaGestionTransporte.Tranversales.Entidades;

namespace Mectronics.SistemaGestionTransporte.Tranversales.Dtos
{
    /// <summary>
    /// Representa un conductor en el sistema de transporte.
    /// </summary>
    public class ConductorDto
    {
        /// <summary>
        /// Identificador único del conductor.
        /// </summary>
        public int IdConductor { get; set; }

        /// <summary>
        /// Número de licencia del conductor.
        /// </summary>
        public string NumeroLicencia { get; set; }

        /// <summary>
        /// Estado actual del conductor (disponible, en descanso, etc.).
        /// </summary>
        public EstadoConductorDto NombreEstadoConductor { get; set; }

        /// <summary>
        /// Usuario asociado al conductor.
        /// </summary>
        public UsuarioDto Usuario { get; set; }

        /// <summary>
        ///  Rol asociado al conductor.
        /// </summary>
        public RolDto Rol { get; set; }
    }
}
