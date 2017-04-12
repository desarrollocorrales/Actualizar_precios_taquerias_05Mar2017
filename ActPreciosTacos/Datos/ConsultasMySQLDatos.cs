using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using ActPreciosTacos.Modelos;
using System.Net.Sockets;
using System.Net;

namespace ActPreciosTacos.Datos
{
    public class ConsultasMySQLDatos : IConsultasMySQLDatos
    {
        // Variable que almacena el estado de la conexión a la base de datos
        IConexionMySQL _conexionMySQL;

        public ConsultasMySQLDatos()
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

        // valida las credenciales del usuario
        public Modelos.Usuarios validaAcceso(string usuario, string pass)
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

        // inserta todos los productos obtenidos de softrestaurant
        // antes elimina los que ya existen
        public void insertaProductos(List<Productos> productos)
        {
            int rows = 0;
            MySqlTransaction trans;

            using (var conn = this._conexionMySQL.getConexionMySQL())
            {
                conn.Open();

                using (var cmd = new MySqlCommand())
                {

                    trans = conn.BeginTransaction();

                    try
                    {
                        cmd.Connection = conn;
                        cmd.Transaction = trans;

                        // elimina los articulos
                        string sql = "delete from productos";

                        ManejoSql_My res = Utilerias.EjecutaSQL(sql, ref rows, cmd);

                        if (!res.ok)
                            throw new Exception(res.numErr + ": " + res.descErr);


                        // inserta los articulos
                        string sqlDet =
                            "INSERT INTO productos (clave, descripcion, precio) " +
                            "VALUES (@clave, @desc, @precio)";

                        foreach (Modelos.Productos prod in productos)
                        {
                            // define parametros
                            cmd.Parameters.AddWithValue("@clave", prod.clave);
                            cmd.Parameters.AddWithValue("@desc", prod.producto);
                            cmd.Parameters.AddWithValue("@precio", prod.precio);

                            res = Utilerias.EjecutaSQL(sqlDet, ref rows, cmd);

                            if (!res.ok) throw new Exception(res.numErr + ": " + res.descErr);

                            cmd.Parameters.Clear();
                        }

                        trans.Commit();
                    }
                    catch (Exception e)
                    {
                        trans.Rollback();
                        throw new Exception(e.Message);
                    }
                }
            }
        }

        // obtiene los productos cargados 
        public List<Productos> obtieneProductos()
        {
            List<Modelos.Productos> result = new List<Modelos.Productos>();
            Modelos.Productos ent;

            string sql =
                "SELECT clave, descripcion, precio FROM productos ORDER BY descripcion";

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
                                ent = new Modelos.Productos();

                                ent.clave = Convert.ToString(res.reader["clave"]);
                                ent.producto = Convert.ToString(res.reader["descripcion"]);

                                // precio
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

        // busca si el usuario no existe
        public bool buscaCorreo(string correo)
        {
            bool result = false;

            string sql = "select count(*) from usuarios where trim(correo) = @correo and status = 'A'";

            // define conexion con la cadena de conexion
            using (var conn = this._conexionMySQL.getConexionMySQL())
            {
                // abre la conexion
                conn.Open();

                using (var cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;

                    // define parametros
                    cmd.Parameters.AddWithValue("@correo", correo);

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

        // inserta un nuevo usuario
        public bool insertaUsuario(string nombreCompleto, string correo, string usuario, string clave, string fecha)
        {
            MySqlTransaction trans;

            bool result = true;

            string sql = string.Empty;

            int rows = 0;

            string error = string.Empty;

            using (var conn = this._conexionMySQL.getConexionMySQL())
            {
                conn.Open();
                using (var cmd = new MySqlCommand())
                {
                    trans = conn.BeginTransaction();

                    try
                    {
                        cmd.Connection = conn;
                        cmd.Transaction = trans;

                        // inserta actuaizacion
                        sql =
                            "INSERT INTO usuarios (nombre_completo, correo, fecha_creacion, usuario, clave, status) " +
                            "VALUES (@nombreCompleto, @correo, @fecha, @usuario, @clave, @status)";

                        string claveBase64 = Utilerias.Base64Encode(clave);

                        // define parametros
                        cmd.Parameters.AddWithValue("@nombreCompleto", nombreCompleto);
                        cmd.Parameters.AddWithValue("@correo", correo);
                        cmd.Parameters.AddWithValue("@usuario", usuario);
                        cmd.Parameters.AddWithValue("@clave", claveBase64);
                        cmd.Parameters.AddWithValue("@status", "A");
                        cmd.Parameters.AddWithValue("@fecha", fecha);

                        ManejoSql_My res = Utilerias.EjecutaSQL(sql, ref rows, cmd);

                        if (!res.ok)
                            throw new Exception(res.numErr + ": " + res.descErr);

                        trans.Commit();
                    }
                    catch (Exception e)
                    {
                        trans.Rollback();
                        throw new Exception(e.Message);
                    }
                }
            }

            return result;
        }

        // valida que la clave es correcta
        public bool validaClave(string claveActual, int _idUsuario)
        {
            bool result = false;

            string sql = "select count(*) from usuarios where clave = @clave and id_usuario = @idUsuario";

            // define conexion con la cadena de conexion
            using (var conn = this._conexionMySQL.getConexionMySQL())
            {
                // abre la conexion
                conn.Open();

                using (var cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;

                    // define parametros
                    cmd.Parameters.AddWithValue("@clave", Utilerias.Base64Encode(claveActual));
                    cmd.Parameters.AddWithValue("@idUsuario", _idUsuario);

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

        // actualiza clave
        public bool actualizaClave(string clave, int idUsuario, string usuario)
        {
            string sql = "update usuarios set clave = @clave where id_usuario = @idUsuario";

            bool result = true;

            int rows = 0;

            using (var conn = this._conexionMySQL.getConexionMySQL())
            {
                conn.Open();

                using (var cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;

                    // define parametros
                    cmd.Parameters.AddWithValue("@clave", Utilerias.Base64Encode(clave));
                    cmd.Parameters.AddWithValue("@idUsuario", idUsuario);

                    ManejoSql_My res = Utilerias.EjecutaSQL(sql, ref rows, cmd);

                    if (!res.ok)
                        throw new Exception(res.numErr + ": " + res.descErr);
                }
            }

            return result;
        }

        // obtiene el siguiente bloque
        public int getSigBloque()
        {
            int result = 0;

            string sql = "select ifnull(max(num_bloque), 0) bloque from actualizacion";

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
                                result = Convert.ToInt32(res.reader["bloque"]);

                            }
                        else result = 0;
                    }
                    else
                        throw new Exception(res.numErr + ": " + res.descErr);

                    // cerrar el reader
                    res.reader.Close();

                }
            }

            return result;
        }

        // guarda actualizacion
        public bool guardaActualizacion(List<Productos> seleccionados, int bloque, string fecha)
        {
            MySqlTransaction trans;

            bool result = true;

            string sql = string.Empty;

            long idInserted = 0;
            int rows = 0;

            string error = string.Empty;


            using (var conn = this._conexionMySQL.getConexionMySQL())
            {
                conn.Open();
                using (var cmd = new MySqlCommand())
                {
                    trans = conn.BeginTransaction();

                    try
                    {
                        cmd.Connection = conn;
                        cmd.Transaction = trans;

                        cmd.Parameters.Clear();

                        foreach (Modelos.Productos art in seleccionados)
                        {
                            // inserta actuaizacion
                            sql =
                                "INSERT INTO actualizacion (num_bloque, fecha, clave_articulo, palmas, dolores, heroico, mananero, precio, status) " +
                                "VALUES (@numBloque, @fecha, @claveArticulo, @palmas, @dolores, @heroico, @mananero, @precio, @status)";

                            // define parametros
                            cmd.Parameters.AddWithValue("@numBloque", bloque);
                            cmd.Parameters.AddWithValue("@fecha", fecha);
                            cmd.Parameters.AddWithValue("@claveArticulo", art.clave);
                            cmd.Parameters.AddWithValue("@palmas", "P");
                            cmd.Parameters.AddWithValue("@dolores", "P");
                            cmd.Parameters.AddWithValue("@heroico", "P");
                            cmd.Parameters.AddWithValue("@mananero", "P");
                            cmd.Parameters.AddWithValue("@precio", art.precio);
                            cmd.Parameters.AddWithValue("@status", "P");

                            ManejoSql_My res = Utilerias.EjecutaSQL(sql, ref rows, cmd);

                            if (res.ok)
                            {
                                if (rows != 0) idInserted = cmd.LastInsertedId;
                            }
                            else
                                throw new Exception(res.numErr + ": " + res.descErr);

                            cmd.Parameters.Clear();
                        }

                        trans.Commit();
                    }
                    catch (Exception e)
                    {
                        trans.Rollback();
                        throw new Exception(e.Message);
                    }
                }
            }

            return result;
        }

        // guarda bitacora de cambios de precios
        public void guardaBitacora(List<Productos> anteriores, List<Productos> seleccionados, long resultado)
        {
            int rows = 0;
            MySqlTransaction trans;

            using (var conn = this._conexionMySQL.getConexionMySQL())
            {
                conn.Open();

                using (var cmd = new MySqlCommand())
                {

                    trans = conn.BeginTransaction();

                    try
                    {
                        cmd.Connection = conn;
                        cmd.Transaction = trans;

                        // inserta los articulos
                        string sqlDet =
                            "INSERT INTO bitacora_det (id_bitacora, clave, precio) " +
                            "VALUES (@idBit, @clave, @precio)";

                        Modelos.Productos ant;

                        foreach (Modelos.Productos art in seleccionados)
                        {
                            ant = new Modelos.Productos();
                            ant = anteriores.Where(w => w.clave.Equals(art.clave)).FirstOrDefault();

                            // define parametros
                            cmd.Parameters.AddWithValue("@idBit", resultado);
                            cmd.Parameters.AddWithValue("@clave", art.clave);

                            cmd.Parameters.AddWithValue("@precio", ant.precio != art.precio ? ("A:" + ant.precio + " => N:" + art.precio) : "-");

                            ManejoSql_My res = Utilerias.EjecutaSQL(sqlDet, ref rows, cmd);

                            if (!res.ok) throw new Exception(res.numErr + ": " + res.descErr);

                            cmd.Parameters.Clear();
                        }

                        trans.Commit();
                    }
                    catch (Exception e)
                    {
                        trans.Rollback();
                        throw new Exception(e.Message);
                    }
                }
            }
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

        // obtiene los bloques dentro de un rango de fechas
        public List<int> obtieneBloques(string fechaIni, string fechaFin)
        {
            List<int> result = new List<int>();

            string sql =
                        "select num_bloque from actualizacion " +
                        "where fecha between @fechaIni and @fechaFin group by num_bloque";

            // define conexion con la cadena de conexion
            using (var conn = this._conexionMySQL.getConexionMySQL())
            {
                // abre la conexion
                conn.Open();

                using (var cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;

                    // define parametros
                    cmd.Parameters.AddWithValue("@fechaIni", fechaIni);
                    cmd.Parameters.AddWithValue("@fechaFin", fechaFin);

                    ManejoSql_My res = Utilerias.EjecutaSQL(sql, cmd);

                    if (res.ok)
                        while (res.reader.Read())
                            result.Add(Convert.ToInt16(res.reader["num_bloque"]));
                    else
                        throw new Exception(res.numErr + ": " + res.descErr);

                    // cerrar el reader
                    res.reader.Close();

                }
            }

            return result;
        }

        // regresa toda la informacion sobre los articulos a actualizar
        public List<Actualizacion> obtieneInformacion(string fechaIni, string fechaFin, int bloque, bool pendiente, bool realizado)
        {
            List<Actualizacion> result = new List<Actualizacion>();
            Actualizacion ent;

            string sql =
                        "select ac.id_actualizacion, ac.num_bloque, ac.fecha, ac.clave_articulo, p.descripcion, ac.precio, " +
                            "if(ac.palmas = 'P' , 'PENDIENTE', 'REALIZADO') as palmas, " +
                            "if(ac.dolores = 'P' , 'PENDIENTE', 'REALIZADO') as dolores, " +
                            "if(ac.heroico = 'P' , 'PENDIENTE', 'REALIZADO') as heroico, " +
                            "if(ac.mananero = 'P' , 'PENDIENTE', 'REALIZADO') as mananero, " +
                            "if(ac.status = 'P' , 'PENDIENTE', 'REALIZADO') as status  " +

                        "from actualizacion ac " +

                        "left join productos p on (ac.clave_articulo = p.clave) " +

                        "where ac.fecha between @fechaIni and @fechaFin ";

            if (bloque > 0)
                sql += "and ac.num_bloque = @bloque ";

            if (pendiente)
                if (realizado)
                    sql += "and (ac.status = 'R' or ac.status = 'P')";
                else
                    sql += "and (ac.status = 'P')";
            else
                if (realizado)
                    sql += "and (ac.status = 'R')";

            sql += " order by ac.num_bloque asc";

            // define conexion con la cadena de conexion
            using (var conn = this._conexionMySQL.getConexionMySQL())
            {
                // abre la conexion
                conn.Open();

                using (var cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;

                    // define parametros
                    cmd.Parameters.AddWithValue("@fechaIni", fechaIni);
                    cmd.Parameters.AddWithValue("@fechaFin", fechaFin);

                    if (bloque > 0) cmd.Parameters.AddWithValue("@bloque", bloque);

                    ManejoSql_My res = Utilerias.EjecutaSQL(sql, cmd);

                    if (res.ok)
                    {
                        while (res.reader.Read())
                        {
                            ent = new Modelos.Actualizacion();

                            ent.idActualizacion = Convert.ToInt16(res.reader["id_actualizacion"]);
                            ent.claveArticulo = Convert.ToString(res.reader["clave_articulo"]);

                            var a = res.reader["clave_articulo"];

                            ent.numBloque = Convert.ToInt16(res.reader["num_bloque"]);

                            ent.fecha = Convert.ToString(res.reader["fecha"]);

                            ent.palmas = Convert.ToString(res.reader["palmas"]);
                            ent.dolores = Convert.ToString(res.reader["dolores"]);
                            ent.heroico = Convert.ToString(res.reader["heroico"]);
                            ent.mananero = Convert.ToString(res.reader["mananero"]);

                            ent.status = Convert.ToString(res.reader["status"]);

                            ent.producto = Convert.ToString(res.reader["descripcion"]);
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
    }
}
