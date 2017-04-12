using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ActPreciosTacos.Modelos
{
    public class Actualizacion
    {
        public int idActualizacion { get; set; }
        public int numBloque { get; set; }
        public string fecha { get; set; }
        public string claveArticulo { get; set; }

        public string producto { get; set; }

        public string palmas { get; set; }
        public string dolores { get; set; }
        public string heroico { get; set; }
        public string mananero { get; set; }
        public decimal precio { get; set; }
        public string status { get; set; }
    }
}
