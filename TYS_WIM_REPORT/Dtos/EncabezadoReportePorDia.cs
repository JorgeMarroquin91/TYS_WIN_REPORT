using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TYS_WIM_REPORT.Dtos
{
    public class EncabezadoReportePorDia
    {
        public string? nombreTramoCarretera { get; set; }
        public string? kilometraje { get; set; }
        public string? tipoCamino { get; set; }

        public EncabezadoReportePorDia()
        {
            this.nombreTramoCarretera = string.Empty;
            this.kilometraje = string.Empty;
            this.tipoCamino = string.Empty;
        }
    }
}
