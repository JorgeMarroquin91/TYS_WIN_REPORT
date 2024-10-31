using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TYS_WIM_REPORT.Helper
{
    public class Reloj
    {
        TimeSpan timeSpan { get; set; }
        public Boolean start = false;

        public Reloj() { }
        public void startReloj(Label label)
        {
            timeSpan = TimeSpan.Zero;
            label.Text = timeSpan.ToString();
            label.Refresh();
            this.start = true;
        }

        public void stopReloj()
        {
            this.start = false;
        }

        public void addSecond(Label label)
        {
            timeSpan = timeSpan + TimeSpan.FromSeconds(1);
            label.Text = timeSpan.ToString();
            label.Refresh();
        }
    }
}
