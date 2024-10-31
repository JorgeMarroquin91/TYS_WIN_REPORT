using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace TYS_WIM_REPORT.Modelos
{
    public class ConfiguracionCarril
    {
        public long? idConfiguracionCarril {  get; set; }
        public Int16? DIRECTION_NUMBER {  get; set; }
        public string? DIRECTION_NAME { get; set; }
        public Byte? LANE { get; set; }
        public string? LANE_NAME { get; set; }
        public long? idEstacion { get; set; }
        public string? nombreEstacion { get; set; }

        public ConfiguracionCarril()
        {
            this.idConfiguracionCarril = null;
            this.DIRECTION_NUMBER = null;
            this.DIRECTION_NAME = string.Empty;
            this.LANE = null;
            this.LANE_NAME = string.Empty;
            this.idEstacion = null;
            this.nombreEstacion = string.Empty;
        }
    }
}
