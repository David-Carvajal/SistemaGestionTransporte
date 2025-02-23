
namespace Mectronics.SistemaGestionTransporte.Tranversales.Dtos
{
    /// <summary>
    /// Representa un bus dentro del sistema de gestión de transporte.
    /// </summary>
    public class BusDto
    {
        /// <summary>
        /// Identificador único del bus.
        /// </summary>
        public int IdBus { get; set; }

        /// <summary>
        /// Placa del bus.
        /// </summary>
        public string Placa { get; set; }

        /// <summary>
        /// Capacidad máxima de pasajeros del bus.
        /// </summary>
        public int Capacidad { get; set; }

        /// <summary>
        /// Modelo del bus.
        /// </summary>
        public string Modelo { get; set; }

        /// <summary>
        /// Estado actual del bus.
        /// </summary>
        public EstadoBusDto EstadoBus { get; set; }
    }
}
