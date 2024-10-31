using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TYS_WIM_REPORT.Modelos
{
    public class TipoPavimento
    {
        public long? idTipoPavimento { get; set; }
        public string? tipoPavimento { get; set; }

        public TipoPavimento()
        {
            this.idTipoPavimento = null;
            this.tipoPavimento = string.Empty;

        }
    }
}
