using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TYS_WIM_REPORT.Modelos
{
    public class TipoVia
    {
        public long? idTipoVia {  get; set; }
        public string? tipoVia { get; set;}

        public TipoVia()
        {
            this.idTipoVia = null;
            this.tipoVia = string.Empty;
        }
    }
}
