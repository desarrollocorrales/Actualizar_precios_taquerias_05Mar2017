using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DescargaPrecioTacos.Datos
{
    public interface IConsultasSSDatos
    {
        bool pruebaConn();

        string getFecha();

        Modelos.ProductoSS buscaProduc(string clave);

        void actPrecio(string clave, decimal impuesto, decimal precio);
    }
}
