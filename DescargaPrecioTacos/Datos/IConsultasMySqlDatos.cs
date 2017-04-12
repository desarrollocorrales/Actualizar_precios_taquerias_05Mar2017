using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DescargaPrecioTacos.Datos
{
    public interface IConsultasMySqlDatos
    {
        bool pruebaConn();

        bool buscaUsuario(string usuario);

        Modelos.Usuarios validaAcceso(string usuario, string pass);

        long generaBitacora(string detalle, string fecha);

        bool verifDescargas(string sucursal);

        List<Modelos.Productos> getProductosActualizar(string sucursal, int bloque);

        int obtBloqueAnt(string sucursal);

        bool liberaProducto(string clave, int bloque, string sucursal);

        bool bloquesLiberados(int bloque, string sucursal);

        bool bloquesLiberados(int bloque);

        void liberaBloque(int bloque);
    }
}
