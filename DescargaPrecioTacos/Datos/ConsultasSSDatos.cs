using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DescargaPrecioTacos.Modelos;
using System.Data.SqlClient;

namespace DescargaPrecioTacos.Datos
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

        // obtiene el producto
        public ProductoSS buscaProduc(string clave)
        {
            Modelos.ProductoSS result = new ProductoSS();
            result = null;
            string sql =
                "select p.idproducto as clave, p.descripcion as producto, pd.precio, pd.impuesto1 " +
                "from productos p " +
                "left join productosdetalle pd on (p.idproducto = pd.idproducto) " +
                "where p.idproducto = @cveProd";

            // define conexion con la cadena de conexion
            using (var conn = this._conexionSS.getConexionSS())
            {
                // abre la conexion
                conn.Open();

                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = conn;

                    // parametros
                    cmd.Parameters.AddWithValue("@cveProd", clave);

                    ManejoSql_SS res = Utilerias.EjecutaSQL(sql, cmd);

                    if (res.ok)
                    {
                        while (res.reader.Read())
                        {
                            result = new ProductoSS();
                            result.clave = Convert.ToString(res.reader["clave"]);
                            result.impuesto = Convert.ToDecimal(res.reader["impuesto1"]);
                            result.precio = Convert.ToDecimal(res.reader["precio"]);
                            result.producto = Convert.ToString(res.reader["producto"]);
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

        // actualizar precio del producto
        public void actPrecio(string clave, decimal impuesto, decimal precio)
        {
            int rows = 0;

            // define conexion con la cadena de conexion
            using (var conn = this._conexionSS.getConexionSS())
            {
                // abre la conexion
                conn.Open();

                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = conn;

                    string sql =
                        "update productosdetalle set precio = @precio, preciosinimpuestos = @precSI " +
                        "where idproducto = @idProd ";

                    decimal imp = precio / ((100 + impuesto) / 100);

                    cmd.Parameters.AddWithValue("@precio", precio);
                    cmd.Parameters.AddWithValue("@idProd", clave);
                    cmd.Parameters.AddWithValue("@precSI", Decimal.Round(imp, 2));

                    ManejoSql_SS res = Utilerias.EjecutaSQL(sql, ref rows, cmd);

                    if (!res.ok) throw new Exception(res.numErr + ": " + res.descErr);
                }
            }
        }
    }
}
