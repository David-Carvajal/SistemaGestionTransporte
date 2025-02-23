using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mectronics.SistemaGestionTransporte.Tranversales.Dtos
{/// <summary>
 /// Modelo estándar para respuestas de la API.
 /// </summary>
    public class RespuestaDto
    {
        /// <summary>
        /// Indica si la operación fue exitosa.
        /// </summary>
        public bool Exito { get; set; }

        /// <summary>
        /// Mensaje descriptivo de la operación.
        /// </summary>
        public string Mensaje { get; set; }

        /// <summary>
        /// Datos devueltos en la respuesta (puede ser cualquier tipo).
        /// </summary>
        public object Datos { get; set; }
    }
}
