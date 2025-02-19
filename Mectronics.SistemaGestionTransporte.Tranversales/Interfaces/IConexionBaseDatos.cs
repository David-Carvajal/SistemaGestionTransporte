
using System.Data;
using Microsoft.Data.SqlClient;

namespace Mectronics.SistemaGestionTransporte.Tranversales.Interfaces
{
    public interface IConexionBaseDatos : IDisposable
    {
        /// <summary>
        /// Obtiene o establece el comando SQL asociado a la conexión.
        /// </summary>
        SqlCommand Comando { get; set; }

        /// <summary>
        /// Obtiene o establece la conexión SQL activa.
        /// </summary>
        SqlConnection Conexion { get; set; }

        /// <summary>
        /// Abre la conexión con la base de datos si no está abierta.
        /// </summary>
        void AbrirConexion();

        /// <summary>
        /// Cierra la conexión con la base de datos y libera los recursos utilizados.
        /// </summary>
        void Cerrar();

        /// <summary>
        /// Agrega un parámetro al comando SQL actual.
        /// </summary>
        /// <param name="nombre">Nombre del parámetro en la consulta SQL.</param>
        /// <param name="valor">Valor del parámetro.</param>
        /// <param name="sqlTipo">Tipo de dato del parámetro definido en <see cref="SqlDbType"/>.</param>
        void AgregarParametroSql(string nombre, object valor, SqlDbType sqlTipo);

        /// <summary>
        /// Limpia todos los parámetros asociados al comando SQL actual.
        /// </summary>
        void LimpiarParametros();
    }
}
