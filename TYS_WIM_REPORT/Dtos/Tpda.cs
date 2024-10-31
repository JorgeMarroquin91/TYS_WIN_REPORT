using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TYS_WIM_REPORT.Dtos
{
    public class Tpda
    {
        public string? estacion {  get; set; }
        public int? tpda { get; set; }

        public Tpda()
        {
            this.estacion = string.Empty;
            this.tpda = null;
        }
    }
}
