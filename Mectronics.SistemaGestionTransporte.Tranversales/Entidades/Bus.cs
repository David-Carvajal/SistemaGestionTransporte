
namespace Mectronics.SistemaGestionTransporte.Tranversales.Entidades
{
    public class Bus
    {
        /// <summary>
        /// Identificador único del bus.
        /// </summary>
        public int IdBus { get; set; }

        /// <summary>
        /// Año del modelo del bus.
        /// </summary>
        public int Modelo { get; set; }

        /// <summary>
        /// Capacidad máxima de pasajeros del bus.
        /// </summary>
        public int Capacidad { get; set; }

        /// <summary>
        /// Placa del bus.
        /// </summary>
        public string Placa { get; set; }

        /// <summary>
        /// Estado actual del bus (disponible, en mantenimiento, etc.).
        /// </summary>
        public EstadoBus EstadoBus { get; set; }

        public Bus()
        {
            IdBus = 0;
            Modelo = 0;
            Capacidad = 0;
            Placa = string.Empty;
            EstadoBus = new EstadoBus();
        }
    }
}
