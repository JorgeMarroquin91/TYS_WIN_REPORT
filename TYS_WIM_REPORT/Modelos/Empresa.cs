using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TYS_WIM_REPORT.Modelos
{
    public class Empresa
    {
        public long? idEmpresa {  get; set; }
        public string? nombreEmpresa { get; set; }
        public string? logotipo { get; set; }
        public Boolean? activo { get; set; }

        public Empresa() 
        {
            this.idEmpresa = null;
            this.nombreEmpresa = string.Empty;
            this.logotipo = string.Empty;
            this.activo = false;
        }
    }
}
