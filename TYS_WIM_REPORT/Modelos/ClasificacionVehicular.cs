using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TYS_WIM_REPORT.Modelos
{
    public class ClasificacionVehicular
    {
        public long? idClasificacionVehicular { get; set; }
        public string? clasificacion { get; set; }
        public decimal? pesoMaximo { get; set; }
        public long? idEmpresa { get; set; }

        public ClasificacionVehicular()
        {
            this.idClasificacionVehicular = null;
            this.clasificacion = string.Empty;
            this.pesoMaximo = null;
            this.idEmpresa = null;
        }
    }
}
