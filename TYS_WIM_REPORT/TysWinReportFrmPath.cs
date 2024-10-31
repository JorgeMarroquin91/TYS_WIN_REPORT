using TYS_WIM_REPORT.Properties;

namespace HTMonitorNet8
{
    public partial class TysWinReportFrmPath : Form
    {
        public TysWinReportFrmPath()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            Settings.Default.directorioOrigen = txtCarpetaOrigen.Text;
            Settings.Default.directorioDestino = txtCarpetaHistorica.Text;
            Settings.Default.directorioError = txtCarpetaErrores.Text;
            Settings.Default.Save();
            this.Close();
        }

        private void txtCarpetaOrigen_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtCarpetaOrigen.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void txtCarpetaHistorica_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtCarpetaHistorica.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void TysWinReportFrmPath_Load(object sender, EventArgs e)
        {
            txtCarpetaOrigen.Text = Settings.Default.directorioOrigen;
            txtCarpetaHistorica.Text = Settings.Default.directorioDestino;
            txtCarpetaErrores.Text = Settings.Default.directorioError;
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtCarpetaErrores.Text = folderBrowserDialog1.SelectedPath;
            }
        }
    }
}
