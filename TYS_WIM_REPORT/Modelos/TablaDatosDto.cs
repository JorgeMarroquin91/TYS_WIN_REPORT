using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TYS_WIM_REPORT.Modelos
{
    public class TablaDatosDto
    {
        public double SITE_NUMBER { get; set; }
        public double SERIAL_NUMBER { get; set; }
        public DateTime? DATE { get; set; }

        public TablaDatosDto()
        {
            this.SITE_NUMBER = 0;
            this.SERIAL_NUMBER = 0;
            this.DATE = null;
        }
    }
}
