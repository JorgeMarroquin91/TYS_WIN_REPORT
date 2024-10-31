using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TYS_WIM_REPORT.Modelos
{
    public class TipoCamino
    {
        public long? idTipoCamino { get; set; }
        public string? tipoCamino { get; set; }

        public TipoCamino() 
        {
            this.idTipoCamino = null;
            this.tipoCamino = string.Empty;
        }
    }
}
