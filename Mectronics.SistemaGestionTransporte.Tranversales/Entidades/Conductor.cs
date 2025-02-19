
namespace Mectronics.SistemaGestionTransporte.Tranversales.Entidades
{
    public class Conductor
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
        public EstadoConductor NombreEstadoConductor { get; set; }

        /// <summary>
        /// Usuario asociado al conductor.
        /// </summary>
        public Usuario Usuario { get; set; }
        public Conductor()
        {
            IdConductor = 0;
            NumeroLicencia = string.Empty;
            NombreEstadoConductor= new EstadoConductor();
            Usuario = new Usuario();
        }
    }
}
