using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TYS_WIM_REPORT.Properties;

namespace HTMonitorNet8
{
    public partial class TysWinReportFrmConf : Form
    {
        public TysWinReportFrmConf()
        {
            InitializeComponent();
        }

        private void TysWinReportFrmConf_Load(object sender, EventArgs e)
        {
            chkUsarGrupos.Checked = Settings.Default.usarGrupos;
            dtpFechaInicio.Value = Settings.Default.fechaInicio;
            dtpFechaTerminacion.Value = Settings.Default.fechaTerminacion;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Settings.Default.usarGrupos = chkUsarGrupos.Checked;
            Settings.Default.fechaInicio = dtpFechaInicio.Value;
            Settings.Default.fechaTerminacion = dtpFechaTerminacion.Value;
            Settings.Default.Save();
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
