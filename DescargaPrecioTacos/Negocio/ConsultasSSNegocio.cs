using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DescargaPrecioTacos.Datos;

namespace DescargaPrecioTacos.Negocio
{
    public class ConsultasSSNegocio : IConsultasSSNegocio
    {
        private IConsultasSSDatos _consultasSSDatos;

        public ConsultasSSNegocio()
        {
            this._consultasSSDatos = new ConsultasSSDatos();
        }

        public bool pruebaConn()
        {
            return this._consultasSSDatos.pruebaConn();
        }

        public string getFecha()
        {
            return this._consultasSSDatos.getFecha();
        }

        public Modelos.ProductoSS buscaProduc(string clave)
        {
            return this._consultasSSDatos.buscaProduc(clave);
        }

        public void actPrecio(string clave, decimal impuesto, decimal precio)
        {
            this._consultasSSDatos.actPrecio(clave, impuesto, precio);
        }
    }
}
