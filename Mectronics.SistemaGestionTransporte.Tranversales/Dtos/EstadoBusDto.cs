
namespace Mectronics.SistemaGestionTransporte.Tranversales.Dtos
{
    /// <summary>
    /// Representa el estado de un bus en el sistema de transporte.
    /// </summary>
    public class EstadoBusDto
    {
        /// <summary>
        /// Identificador único del estado del bus.
        /// </summary>
        public int IdEstadoBus { get; set; }

        /// <summary>
        /// Descripción del estado del bus.
        /// </summary>
        public string Estado { get; set; }
    }
}
