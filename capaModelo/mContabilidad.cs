using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaModelo
{
    public class mContabilidad
    {
        public DateTime? fecha { get; set; }
        public string descripcion { get; set; }
        public decimal? ingresos { get; set; }
        public decimal? gastos { get; set; }
        public int local_id { get; set; }

        public mContabilidad() { }

      
        

    }
}
