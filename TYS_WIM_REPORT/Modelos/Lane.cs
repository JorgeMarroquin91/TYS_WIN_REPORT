using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TYS_WIM_REPORT.Modelos
{
    public class Lane
    {
        public long? idLANE {  get; set; }
        public Byte? LANE { get; set; }

        public Lane() {
            this.idLANE = null;
            this.LANE = null;
        }
    }
}
