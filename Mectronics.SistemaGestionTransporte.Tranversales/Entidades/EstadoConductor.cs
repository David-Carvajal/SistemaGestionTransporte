
namespace Mectronics.SistemaGestionTransporte.Tranversales.Entidades
{
    public class EstadoConductor
    {
        /// <summary>
        /// Identificador único del estado del conductor.
        /// </summary>
        public int IdEstadoConductor { get; set; }

        /// <summary>
        /// Descripción del estado del conductor.
        /// </summary>
        public string NombreEstadoConductor { get; set; }

        public EstadoConductor()
        {
            IdEstadoConductor = 0;
            NombreEstadoConductor = string.Empty;
        }
    }
}
