using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TYS_WIM_REPORT.Modelos
{
    public class Direction
    {
        public long? idDIRECTION { get; set; }
        public Int16? DIRECTION { get; set; }

        public Direction()
        {
            this.idDIRECTION = null;
            this.DIRECTION = null;
        }
    }
}
