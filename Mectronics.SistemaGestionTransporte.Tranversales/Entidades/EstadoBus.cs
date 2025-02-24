
namespace Mectronics.SistemaGestionTransporte.Tranversales.Entidades
{
    public class EstadoBus
    {
        /// <summary>
        /// Identificador único del estado del bus.
        /// </summary>
        public int IdEstadoBus { get; set; }

        /// <summary>
        /// Descripción del estado del bus.
        /// </summary>
        public string NombreEstadoBus { get; set; }


        public EstadoBus()
        {
            IdEstadoBus = 0;
            NombreEstadoBus = string.Empty;
        }
    }
}
