using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public string Estado { get; set; }


        public EstadoBus()
        {
            IdEstadoBus = 0;
            Estado = string.Empty;
        }
    }
}
