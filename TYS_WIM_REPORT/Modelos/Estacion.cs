using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TYS_WIM_REPORT.Modelos
{
    public class Estacion
    {
        public long? idEstacion {  get; set; }
        public int? numeroEstacion { get; set; }
        public string? nombreEstacion { get; set; }
        public string? nombreTramoCarretera { get; set; }
        public string? kilometraje {  get; set; }
        public decimal? latitud {  get; set; }
        public decimal? longitud { get; set; }
        public long? idTipoPavimento { get; set; }
        public long? idTipoCamino { get; set; }
        public long? idTipovia { get; set; }
        public long? idEmpresa { get; set; }

        public Estacion()
        {
            this.idEstacion = null;
            this.numeroEstacion = null;
            this.nombreEstacion = string.Empty;
            this.nombreTramoCarretera = string.Empty;
            this.kilometraje = string.Empty;
            this.latitud = null;
            this.longitud = null;
            this.idTipoPavimento = null;
            this.idTipoCamino = null;
            this.idTipovia = null;
            this.idEmpresa = null;
        }
    }
}
