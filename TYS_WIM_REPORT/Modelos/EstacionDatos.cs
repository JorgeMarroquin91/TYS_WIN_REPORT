using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TYS_WIM_REPORT.Modelos
{
    public class EstacionDatos
    {
        public long? idEstacionDatos {  get; set; }
        public string? tabla {  get; set; }
        public long? idEstacion { get; set;}

        public EstacionDatos()
        {
            this.idEstacionDatos = null;
            this.tabla = string.Empty;
            this.idEstacion = null;
        }
    }
}
