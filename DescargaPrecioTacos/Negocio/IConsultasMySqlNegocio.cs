using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DescargaPrecioTacos.Datos;

namespace DescargaPrecioTacos.Negocio
{
    public interface IConsultasMySqlNegocio
    {
        bool pruebaConn();

        Modelos.Response validaAcceso(string usuario, string pass);

        long generaBitacora(string detalle, string fecha);

        bool verifDescargas(string sucursal);

        List<Modelos.Productos> getProductosActualizar(string sucursal);

        bool liberaProducto(string clave, int bloque, string sucursal);

        bool liberaBloque(int bloque, string sucursal);

        bool liberarBloques(int bloque);
    }
}
