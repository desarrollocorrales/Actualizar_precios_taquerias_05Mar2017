using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DescargaPrecioTacos.Modelos
{
    public class Productos
    {
        public int bloque { get; set; }
        public string clave { get; set; }
        public string producto { get; set; }
        public decimal precio { get; set; }
    }

    public class ProductoSS
    {
        public string clave { get; set; }
        public string producto { get; set; }
        public decimal precio { get; set; }
        public decimal impuesto { get; set; }
    }
}
