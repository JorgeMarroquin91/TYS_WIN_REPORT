using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TYS_WIM_REPORT.Modelos
{
    public class Licencia
    {
        public string dia {  get; set; }
        public string mes {  get; set; }
        public string anio { get; set; }

        public Licencia()
        {
            this.dia = "0";
            this.mes = "0";
            this.anio = "0";
        }
    }
}
