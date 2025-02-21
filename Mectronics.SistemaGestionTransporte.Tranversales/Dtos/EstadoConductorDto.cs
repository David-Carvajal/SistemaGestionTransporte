
namespace Mectronics.SistemaGestionTransporte.Tranversales.Dtos
{
    /// <summary>
    /// Representa el estado de un conductor en el sistema de transporte.
    /// </summary>
    public class EstadoConductorDto
    {
        /// <summary>
        /// Identificador único del estado del conductor.
        /// </summary>
        public int IdEstadoConductor { get; set; }

        /// <summary>
        /// Descripción del estado del conductor.
        /// </summary>
        public string Estado { get; set; }
    }
}
