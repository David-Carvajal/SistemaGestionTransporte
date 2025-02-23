
namespace Mectronics.SistemaGestionTransporte.Tranversales.Dtos
{
    public class AutenticacionDto
    {
        /// <summary>
        /// Dirección de correo electrónico del usuario.
        /// </summary>
        public string Correo { get; set; }

        /// <summary>
        /// Contraseña del usuario en formato de texto plano (debe ser protegida en entornos reales).
        /// </summary>
        public string Contrasena { get; set; }
    }
}
