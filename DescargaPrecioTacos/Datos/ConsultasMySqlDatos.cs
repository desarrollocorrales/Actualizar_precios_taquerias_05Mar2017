using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DescargaPrecioTacos.Modelos;
using MySql.Data.MySqlClient;
using System.Net.Sockets;
using System.Net;

namespace DescargaPrecioTacos.Datos
{
    public class ConsultasMySqlDatos : IConsultasMySqlDatos
    {
        // Variable que almacena el estado de la conexión a la base de datos
        IConexionMySQL _conexionMySQL;

        public ConsultasMySqlDatos()
        {
            this._conexionMySQL = new ConexionMySQL(Modelos.ConectionString.connMySQL);
        }

        // realiza una prueba de conexion
        public bool pruebaConn()
        {
            using (var conn = this._conexionMySQL.getConexionMySQL())
            {
                try
                {
                    conn.Open();
                    return true;
                }
                catch (MySqlException)
                {
                    return false;
                }
            }
        }

        // busca si el usuario no existe
        public bool buscaUsuario(string usuario)
        {
            bool result = false;

            string sql = "select count(*) from usuarios where trim(usuario) = @usuario and status = 'A'";

            // define conexion con la cadena de conexion
            using (var conn = this._conexionMySQL.getConexionMySQL())
            {
                // abre la conexion
                conn.Open();

                using (var cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;

                    // define parametros
                    cmd.Parameters.AddWithValue("@usuario", usuario);

                    ManejoSql_My res = Utilerias.EjecutaSQL(sql, cmd);

                    if (res.ok)
                    {
                        while (res.reader.Read())
                        {
                            int count = Convert.ToInt16(res.reader[0]);

                            if (count > 0) result = true;
                        }
                    }
                    else
                        throw new Exception(res.numErr + ": " + res.descErr);

                    // cerrar el reader
                    res.reader.Close();

                }
            }

            return result;
        }

        // valida las credenciales del usuario
        public Usuarios validaAcceso(string usuario, string pass)
        {
            Usuarios result = null;

            string sql =
                        "select u.id_usuario, u.nombre_completo, u.correo, u.fecha_creacion, u.usuario, u.status " +
                        "from usuarios u " +
                        "where usuario = @usuario and clave = @clave and u.status = 'A'";

            // define conexion con la cadena de conexion
            using (var conn = this._conexionMySQL.getConexionMySQL())
            {
                // abre la conexion
                conn.Open();

                using (var cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;

                    // define parametros
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.Parameters.AddWithValue("@clave", Utilerias.Base64Encode(pass));

                    ManejoSql_My res = Utilerias.EjecutaSQL(sql, cmd);

                    if (res.ok)
                    {
                        if (res.reader.HasRows)
                            while (res.reader.Read())
                            {
                                result = new Usuarios();

                                result.idUsuario = Convert.ToInt16(res.reader["id_usuario"]);
                                result.nombreCompleto = Convert.ToString(res.reader["nombre_completo"]);
                                result.correo = Convert.ToString(res.reader["correo"]);

                                result.fechaCreacion = Convert.ToString(res.reader["fecha_creacion"]);
                                result.usuario = Convert.ToString(res.reader["usuario"]);
                                result.status = Convert.ToString(res.reader["status"]);

                            }
                        else result = null;
                    }
                    else
                        throw new Exception(res.numErr + ": " + res.descErr);

                    // cerrar el reader
                    res.reader.Close();

                }
            }

            return result;
        }

        // genera bitacora
        public long generaBitacora(string detalle, string fecha)
        {
            int rows = 0;
            long result = 0;

            using (var conn = this._conexionMySQL.getConexionMySQL())
            {
                conn.Open();

                using (var cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;

                    string bitacora =
                        "insert into bitacora (id_usuario, fecha, detalle, host) " +
                        // "values (@idusu, @fecha, @detalle, (SELECT SUBSTRING_INDEX(HOST, ':', 1) AS 'ip' FROM information_schema.PROCESSLIST WHERE ID = connection_id()))";
                        "values (@idusu, @fecha, @detalle, @host)";

                    cmd.Parameters.AddWithValue("@idusu", Modelos.Login.idUsuario);
                    cmd.Parameters.AddWithValue("@detalle", detalle);
                    cmd.Parameters.AddWithValue("@fecha", fecha);
                    cmd.Parameters.AddWithValue("@host", getIpNameMachine());

                    ManejoSql_My res = Utilerias.EjecutaSQL(bitacora, ref rows, cmd);

                    if (!res.ok) throw new Exception(res.numErr + ": " + res.descErr);
                    else result = cmd.LastInsertedId;
                }
            }

            return result;
        }

        // obtiene ip y nombre de maquina
        private string getIpNameMachine()
        {
            // local ip
            string localIP = string.Empty;
            try
            {
                using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
                {
                    socket.Connect("8.8.8.8", 65530);
                    IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                    localIP = endPoint.Address.ToString();
                }
            }
            catch (Exception e)
            {
                localIP = string.Empty;
            }

            return Environment.MachineName + (string.IsNullOrEmpty(localIP) ? string.Empty : ":" + localIP);
        }

        // verifica descargas
        public bool verifDescargas(string sucursal)
        {
            bool result = false;

            string sql = string.Format(
                "select count(*) pendientes from actualizacion where {0} = 'P'",
                sucursal);

            // define conexion con la cadena de conexion
            using (var conn = this._conexionMySQL.getConexionMySQL())
            {
                // abre la conexion
                conn.Open();

                using (var cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;

                    ManejoSql_My res = Utilerias.EjecutaSQL(sql, cmd);

                    if (res.ok)
                    {
                        if (res.reader.HasRows)
                            while (res.reader.Read())
                            {
                                int count = Convert.ToInt16(res.reader["pendientes"]);

                                if (count > 0) result = true;
                            }
                    }
                    else
                        throw new Exception(res.numErr + ": " + res.descErr);

                    // cerrar el reader
                    res.reader.Close();

                }
            }

            return result;
        }

        // obtiene los articulos a actualizar
        public List<Productos> getProductosActualizar(string sucursal, int bloque)
        {
            List<Productos> result = new List<Productos>();
            Productos ent = null;

            string sql = string.Format(
                        "select a.num_bloque, a.clave_articulo, p.descripcion, a.precio " +
                        "from actualizacion a " +
                        "left join productos p on (a.clave_articulo = p.clave) " +
                        "where a.{0} = 'P' and a.num_bloque = @bloque", sucursal);

            // define conexion con la cadena de conexion
            using (var conn = this._conexionMySQL.getConexionMySQL())
            {
                // abre la conexion
                conn.Open();

                using (var cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;

                    // define parametros
                    cmd.Parameters.AddWithValue("@bloque", bloque);

                    ManejoSql_My res = Utilerias.EjecutaSQL(sql, cmd);

                    if (res.ok)
                    {
                        if (res.reader.HasRows)
                            while (res.reader.Read())
                            {
                                ent = new Productos();

                                ent.bloque = Convert.ToInt16(res.reader["num_bloque"]);
                                ent.producto = Convert.ToString(res.reader["descripcion"]);
                                ent.clave = Convert.ToString(res.reader["clave_articulo"]);

                                // lista
                                if (res.reader["precio"] is DBNull) ent.precio = 0;
                                else
                                ent.precio = Convert.ToDecimal(Convert.ToString(res.reader["precio"]).TrimEnd(new Char[] { '0' }));

                                result.Add(ent);
                            }
                    }
                    else
                        throw new Exception(res.numErr + ": " + res.descErr);

                    // cerrar el reader
                    res.reader.Close();

                }
            }

            return result;
        }

        // obtiene el bloque mas antiguo que se tenga
        public int obtBloqueAnt(string sucursal)
        {
            int result = 0;

            string sql = string.Format(
                "select min(num_bloque) num_bloque from actualizacion where {0} = 'P'",
                sucursal);

            // define conexion con la cadena de conexion
            using (var conn = this._conexionMySQL.getConexionMySQL())
            {
                // abre la conexion
                conn.Open();

                using (var cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;

                    ManejoSql_My res = Utilerias.EjecutaSQL(sql, cmd);

                    if (res.ok)
                        if (res.reader.HasRows)
                            while (res.reader.Read())
                                result = res.reader["num_bloque"] == DBNull.Value ? 0 : Convert.ToInt16(res.reader["num_bloque"]);
                        else
                            throw new Exception(res.numErr + ": " + res.descErr);

                    // cerrar el reader
                    res.reader.Close();

                }
            }

            return result;
        }

        // libera el articulo como pendiente de descarga
        public bool liberaProducto(string clave, int bloque, string sucursal)
        {
            bool result = false;
            int rows = 0;

            using (var conn = this._conexionMySQL.getConexionMySQL())
            {
                conn.Open();

                using (var cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;

                    string bitacora = string.Format(
                        "update actualizacion set {0} = 'R' " +
                        "where num_bloque = @bloque and clave_articulo = @cveArt", sucursal);

                    cmd.Parameters.AddWithValue("@cveArt", clave);
                    cmd.Parameters.AddWithValue("@bloque", bloque);

                    ManejoSql_My res = Utilerias.EjecutaSQL(bitacora, ref rows, cmd);

                    if (!res.ok) throw new Exception(res.numErr + ": " + res.descErr);
                    else result = true;
                }
            }

            return result;
        }

        // busca si el bloque esta liberado totalmente
        public bool bloquesLiberados(int bloque, string sucursal)
        {
            bool result = true;

            string sql = string.Format(
                "select count(*) as count from actualizacion where num_bloque = @bloque and {0} = 'P'",
                sucursal);

            // define conexion con la cadena de conexion
            using (var conn = this._conexionMySQL.getConexionMySQL())
            {
                // abre la conexion
                conn.Open();

                using (var cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;

                    cmd.Parameters.AddWithValue("@bloque", bloque);

                    ManejoSql_My res = Utilerias.EjecutaSQL(sql, cmd);

                    if (res.ok)
                    {
                        if (res.reader.HasRows)
                            while (res.reader.Read())
                            {
                                int count = Convert.ToInt16(res.reader["count"]);

                                if (count > 0) result = false;
                            }
                    }
                    else
                        throw new Exception(res.numErr + ": " + res.descErr);

                    // cerrar el reader
                    res.reader.Close();

                }
            }

            return result;
        }

        // verifica si un bloque ha sido descargado en todas las sucursales
        public bool bloquesLiberados(int bloque)
        {
            bool result = true;

            string sql =
                "select count(*) as count from actualizacion where num_bloque = @bloque " + 
                "and (palmas = 'P' or dolores = 'P' or heroico = 'P' or mananero = 'P')";

            // define conexion con la cadena de conexion
            using (var conn = this._conexionMySQL.getConexionMySQL())
            {
                // abre la conexion
                conn.Open();

                using (var cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;

                    cmd.Parameters.AddWithValue("@bloque", bloque);

                    ManejoSql_My res = Utilerias.EjecutaSQL(sql, cmd);

                    if (res.ok)
                    {
                        if (res.reader.HasRows)
                            while (res.reader.Read())
                            {
                                int count = Convert.ToInt16(res.reader["count"]);

                                if (count > 0) result = false;
                            }
                    }
                    else
                        throw new Exception(res.numErr + ": " + res.descErr);

                    // cerrar el reader
                    res.reader.Close();

                }
            }

            return result;
        }

        // libera un bloque completo
        public void liberaBloque(int bloque)
        {
            int rows = 0;

            using (var conn = this._conexionMySQL.getConexionMySQL())
            {
                conn.Open();

                using (var cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;

                    string bitacora =
                        "update actualizacion set status = 'R' " +
                        "where num_bloque = @bloque";

                    cmd.Parameters.AddWithValue("@bloque", bloque);

                    ManejoSql_My res = Utilerias.EjecutaSQL(bitacora, ref rows, cmd);

                    if (!res.ok) throw new Exception(res.numErr + ": " + res.descErr);
                }
            }
        }
    }
}
