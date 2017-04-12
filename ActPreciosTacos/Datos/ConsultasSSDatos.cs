using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using ActPreciosTacos.Modelos;

namespace ActPreciosTacos.Datos
{
    public class ConsultasSSDatos : IConsultasSSDatos
    {
        // Variable que almacena el estado de la conexión a la base de datos
        IConexionSS _conexionSS;

        public ConsultasSSDatos()
        {
            this._conexionSS = new ConexionSS(Modelos.ConectionString.connSS);
        }

        // realiza una prueba de conexion a la base de datos de FIREBIRD
        public bool pruebaConn()
        {
            using (var conn = this._conexionSS.getConexionSS())
            {
                try
                {
                    conn.Open();
                    return true;
                }
                catch (SqlException)
                {
                    return false;
                }
            }
        }

        // obtiene la fecha del sqlserver, es la hora exacta mas cercana posible
        // ya que se debe de contar con la hora real para los tickets
        public string getFecha()
        {
            string result = Convert.ToString(DateTime.Now);

            string sql = "select GETDATE() as fecha";

            // define conexion con la cadena de conexion
            using (var conn = this._conexionSS.getConexionSS())
            {
                // abre la conexion
                conn.Open();

                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = conn;

                    ManejoSql_SS res = Utilerias.EjecutaSQL(sql, cmd);

                    if (res.ok)
                        while (res.reader.Read()) result = Convert.ToString(res.reader["fecha"]).Trim();
                    else
                        throw new Exception(res.numErr + ": " + res.descErr);

                    // cerrar el reader
                    res.reader.Close();

                }
            }

            DateTime dt = DateTime.Parse(result);

            return dt.ToString("yyyy-MM-dd HH:mm:ss");
        }

        // obtiene todos los productos de softrestaurant (SQLSERVER)
        public List<Productos> obtieneProductos()
        {
            List<Modelos.Productos> result = new List<Modelos.Productos>();
            Modelos.Productos ent;

            string sql =
                "SELECT " +
                        "p.idproducto AS clave, " +
                        "p.descripcion AS producto, " +
                        "pd.precio " +

                "FROM productos p " +

                "LEFT JOIN productosdetalle pd ON (p.idproducto = pd.idproducto)" +
                "ORDER BY p.descripcion";

            // define conexion con la cadena de conexion
            using (var conn = this._conexionSS.getConexionSS())
            {
                // abre la conexion
                conn.Open();

                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    
                    ManejoSql_SS res = Utilerias.EjecutaSQL(sql, cmd);

                    if (res.ok)
                    {
                        if (res.reader.HasRows)
                            while (res.reader.Read())
                            {
                                ent = new Modelos.Productos();

                                ent.clave = Convert.ToString(res.reader["clave"]);
                                ent.producto = Convert.ToString(res.reader["producto"]);

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
    }
}
