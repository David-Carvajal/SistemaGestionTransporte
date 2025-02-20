
using System.Data;
using System.Transactions;
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
        /// Ejecuta una consulta SQL que devuelve un conjunto de resultados.
        /// </summary>
        /// <param name="consultaSql">Consulta SQL a ejecutar.</param>
        /// <returns>Un <see cref="IDataReader"/> con los resultados de la consulta.</returns>
        IDataReader EjecutarConsultaSql(string consultaSql);

        /// <summary>
        /// Ejecuta un comando SQL de tipo <c>UPDATE</c> o <c>DELETE</c>.
        /// </summary>
        /// <param name="comandoSql">Comando SQL a ejecutar.</param>
        /// <returns>El número de filas afectadas por la ejecución del comando.</returns>
        int EjecutarComandoSql(string comandoSql);

        /// <summary>
        /// Ejecuta un comando SQL de tipo <c>INSERT</c> y obtiene el ID del registro generado.
        /// </summary>
        /// <param name="comandoSql">Comando SQL a ejecutar.</param>
        /// <returns>Identificador del nuevo registro.</returns>
        object EjecutarEscalarSql(string comandoSql);

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
