using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TYS_WIM_REPORT.Interfaces
{
    public class ConteoVehicularPorDiaYClasificacion
    {
        public string clase { get; set; }
        public int al1 { get; set; }
        public int al2 { get; set; }
        public int al3 { get; set; }
        public int al4 { get; set; }
        public int bl1 { get; set; }
        public int bl2 { get; set; }
        public int bl3 { get; set; }
        public int bl4 { get; set; }
        public int total { get; set; }

        public ConteoVehicularPorDiaYClasificacion(string clase, int al1, int al2, int al3, int al4, int bl1, int bl2, int bl3, int bl4, int total)
        {
            this.clase = clase;
            this.al1 = al1;
            this.al2 = al2;
            this.al3 = al3;
            this.al4 = al4;
            this.bl1 = bl1;
            this.bl2 = bl2;
            this.bl3 = bl3;
            this.bl4 = bl4;
            this.total = total;
        }
    }
}
