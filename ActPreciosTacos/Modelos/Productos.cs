using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ActPreciosTacos.Modelos
{
    public class Productos
    {
        public bool seleccionado { get; set; }
        public string clave { get; set; }
        public string producto { get; set; }
        public decimal? precio { get; set; }
    }
}
