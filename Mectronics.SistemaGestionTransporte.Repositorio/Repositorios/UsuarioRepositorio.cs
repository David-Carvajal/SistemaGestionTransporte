
using Mectronics.SistemaGestionTransporte.Tranversales.Interfaces.IUsuario;
using Mectronics.SistemaGestionTransporte.Tranversales.Interfaces;
using Mectronics.SistemaGestionTransporte.Tranversales.Entidades;
using Mectronics.SistemaGestionTransporte.Tranversales.Filtros;
using Mectronics.SistemaGestionTransporte.Tranversales.Mapeos;
using System.Data;

namespace Mectronics.SistemaGestionTransporte.Repositorio.Repositorios
{
    /// <summary>
    /// Repositorio para gestionar las operaciones sobre la entidad <see cref="Usuario"/>.
    /// </summary>
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly IConexionBaseDatos _conexion;

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="UsuarioRepositorio"/> con una conexión a la base de datos inyectada.
        /// </summary>
        /// <param name="conexion">Instancia de <see cref="IConexionBaseDatos"/> proporcionada por inyección de dependencias.</param>
        public UsuarioRepositorio(IConexionBaseDatos conexion)
        {
            _conexion = conexion;
        }

        /// <summary>
        /// Consulta un usuario en la base de datos basado en los filtros proporcionados.
        /// </summary>
        /// <param name="filtro">Objeto <see cref="UsuarioFiltro"/> con los criterios de búsqueda.</param>
        /// <returns>Una instancia de <see cref="Usuario"/> si se encuentra, de lo contrario, <c>null</c>.</returns>
        public Usuario Consultar(UsuarioFiltro filtro)
        {
            Usuario usuario = null;
            string consultaSql = "SELECT u.IdUsuario, u.Nombre, u.Correo, u.Contrasena, u.IdRol, r.NombreRol " +
                "FROM Usuarios u INNER JOIN Roles r ON u.IdRol = r.IdRol " +
                "WHERE u.IdUsuario = @IdUsuario";

            try
            {
                _conexion.LimpiarParametros();
                _conexion.AgregarParametroSql("@IdUsuario", filtro.IdUsuario, SqlDbType.Int);

                using (IDataReader resultado = _conexion.EjecutarConsultaSql(consultaSql))
                {
                    usuario = UsuarioMapeo.Mapear(resultado);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar el usuario en la base de datos.", ex);
            }
            finally
            {
                _conexion.Cerrar();
            }

            return usuario;
        }
        /// <summary>
        /// Consulta una lista de usuarios en la base de datos según los filtros proporcionados.
        /// </summary>
        /// <param name="filtro">Objeto <see cref="UsuarioFiltro"/> con los criterios de búsqueda.</param>
        /// <returns>Lista de usuarios encontrados. Si no hay coincidencias, retorna una lista vacía.</returns>
        public List<Usuario> ConsultarListado(UsuarioFiltro filtro)
        {
            List<Usuario> usuarios = new List<Usuario>();
            string consultaSql = "SELECT u.IdUsuario, u.Nombre, u.Correo, u.Contraseña, u.IdRol, r.NombreRol " +
                "FROM Usuario u INNER JOIN Rol r ON u.IdRol = r.IdRol " +
                "WHERE u.Nombre LIKE @Nombre";
            if (filtro.IdRol > 0)
            {
                consultaSql += "AND u.IdRol = @IdRol";
            }

            try
            {
                _conexion.LimpiarParametros();
                _conexion.AgregarParametroSql("@Nombre", $"%{filtro.Nombre}%", SqlDbType.VarChar);
                _conexion.AgregarParametroSql("@IdRol", filtro.IdRol, SqlDbType.Int);

                using (IDataReader resultado = _conexion.EjecutarConsultaSql(consultaSql))
                {
                    usuarios = UsuarioMapeo.MapearLista(resultado);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar la lista de usuarios en la base de datos.", ex);
            }
            finally
            {
                _conexion.Cerrar();
            }

            return usuarios;
        }
        /// <summary>
        /// Elimina un usuario de la base de datos por su identificador único.
        /// </summary>
        /// <param name="idUsuario">Identificador único de la tienda a eliminar.</param>
        /// <returns>El número de filas afectadas en la base de datos.</returns>   
        public int Eliminar(int idUsuario)
        {
            string strComandoSql = "DELETE FROM Usuarios WHERE IdUsuario = @IdUsuario";
            int filasAfectadas = 0;

            try
            {
                _conexion.LimpiarParametros();
                _conexion.AgregarParametroSql("@IdUsuario", idUsuario, SqlDbType.Int);
                filasAfectadas = _conexion.EjecutarComandoSql(strComandoSql);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el usuario de la base de datos.", ex);
            }
            finally
            {
                _conexion.Cerrar();
            }

            return filasAfectadas;
        }
        /// <summary>
        /// Inserta un nuevo usuario en la base de datos.
        /// </summary>
        ///<param name="usuario">Objeto<see cref="Usuario"/>con la informacion a insertar</param>
        /// <returns>El número de filas afectadas en la base de datos.</returns>
        public int Insertar(Usuario usuario)
        {
            string strComandoSql = "INSERT INTO Usuarios (Nombre, Correo, Contrasena, IdRol) VALUES (@Nombre, @Correo, @Contrasena, @IdRol); SELECT SCOPE_IDENTITY();";
            int idUsuario = 0;

            try
            {
                _conexion.LimpiarParametros();
                _conexion.AgregarParametroSql("@Nombre", usuario.Nombre, SqlDbType.VarChar);
                _conexion.AgregarParametroSql("@Correo", usuario.Correo, SqlDbType.VarChar);
                _conexion.AgregarParametroSql("@Contrasena", usuario.Contrasena, SqlDbType.VarChar);
                _conexion.AgregarParametroSql("@IdRol", usuario.Rol.IdRol, SqlDbType.Int);

                object resultado = _conexion.EjecutarEscalarSql(strComandoSql);
                idUsuario = Convert.ToInt32(resultado);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar el usuario en la base de datos.", ex);
            }
            finally
            {
                _conexion.Cerrar();
            }

            return idUsuario;
        }

        /// <summary>
        /// Actualiza un usuario existente en la base de datos.
        /// </summary>
        ///<param name="usuario">Objeto<see cref="Usuario"/> con la informacion actualizada.</param>
        public int Actualizar(Usuario usuario)
        {
            string strComandoSql = "UPDATE Usuarios SET Nombre = @Nombre, Correo = @Correo, Contrasena = @Contrasena, IdRol = @IdRol WHERE IdUsuario = @IdUsuario";
            int filasAfectadas = 0;

            try
            {
                _conexion.LimpiarParametros();
                _conexion.AgregarParametroSql("@IdUsuario", usuario.IdUsuario, SqlDbType.Int);
                _conexion.AgregarParametroSql("@Nombre", usuario.Nombre, SqlDbType.VarChar);
                _conexion.AgregarParametroSql("@Correo", usuario.Correo, SqlDbType.VarChar);
                _conexion.AgregarParametroSql("@Contrasena", usuario.Contrasena, SqlDbType.VarChar);
                _conexion.AgregarParametroSql("@IdRol", usuario.Rol.IdRol, SqlDbType.Int);

                filasAfectadas = _conexion.EjecutarComandoSql(strComandoSql);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el usuario en la base de datos.", ex);
            }
            finally
            {
                _conexion.Cerrar();
            }

            return filasAfectadas;
        }

        /// <summary>
        /// Obtiene un usuario por su ID.
        /// </summary>
        /// <param name="idUsuario">ID del usuario.</param>
        /// <returns>El usuario encontrado.</returns>
        public Usuario ObtenerPorId(int idUsuario)
        {
            Usuario usuario = null;
            string consultaSql = "SELECT u.IdUsuario, u.Nombre, u.Correo, u.Contrasena, u.IdRol, r.NombreRol " +
                                 "FROM Usuarios u INNER JOIN Roles r ON u.IdRol = r.IdRol " +
                                 "WHERE u.IdUsuario = @IdUsuario";

            try
            {
                _conexion.LimpiarParametros();
                _conexion.AgregarParametroSql("@IdUsuario", idUsuario, SqlDbType.Int);

                using (IDataReader resultado = _conexion.EjecutarConsultaSql(consultaSql))
                {
                    if (resultado.Read()) // Si hay resultados, mapea el usuario
                    {
                        usuario = UsuarioMapeo.Mapear(resultado);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el usuario por ID en la base de datos.", ex);
            }
            finally
            {
                _conexion.Cerrar();
            }

            return usuario;
        }
    }
}