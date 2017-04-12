using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ActPreciosTacos.Negocio
{
    public interface IConsultasSSNegocio
    {
        bool pruebaConn();

        string getFecha();

        List<Modelos.Productos> obtieneProductos();
    }
}
