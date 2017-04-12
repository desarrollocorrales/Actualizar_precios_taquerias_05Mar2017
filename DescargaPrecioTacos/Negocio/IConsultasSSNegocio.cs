using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DescargaPrecioTacos.Negocio
{
    public interface IConsultasSSNegocio
    {
        bool pruebaConn();

        string getFecha();

        Modelos.ProductoSS buscaProduc(string clave);

        void actPrecio(string clave, decimal impuesto, decimal precio);
    }
}
