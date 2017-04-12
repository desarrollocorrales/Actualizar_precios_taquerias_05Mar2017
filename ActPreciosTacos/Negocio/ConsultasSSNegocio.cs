using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ActPreciosTacos.Datos;

namespace ActPreciosTacos.Negocio
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

        public List<Modelos.Productos> obtieneProductos()
        {
            return this._consultasSSDatos.obtieneProductos();
        }
    }
}
