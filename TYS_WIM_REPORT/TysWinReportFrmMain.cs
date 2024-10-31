using TYS_WIM_REPORT;
using TYS_WIM_REPORT.Repositorios.Queries;

namespace HTMonitorNet8
{
    public partial class TysWinReportFrmMain : Form
    {
        private readonly EmpresaRepositoryQuery _empresaRepositoryQuery = new();
        public TysWinReportFrmMain()
        {
            InitializeComponent();
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form? frmCopy = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is TysWinReportFrmCopy);

            if (frmCopy != null)
            {
                frmCopy.BringToFront();
            }
            else
            {
                frmCopy = new TysWinReportFrmCopy();
                frmCopy.MdiParent = this;
                frmCopy.Show();
            }

        }

        private void periodoActivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form? frmConf = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is TysWinReportFrmConf);

            if (frmConf != null)
            {
                frmConf.BringToFront();
            }
            else
            {
                frmConf = new TysWinReportFrmConf();
                frmConf.MdiParent = this;
                frmConf.Show();
            }
        }

        private void carpetaDeDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form? frmPath = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is TysWinReportFrmPath);

            if (frmPath != null)
            {
                frmPath.BringToFront();
            }
            else
            {
                frmPath = new TysWinReportFrmPath();
                frmPath.MdiParent = this;
                frmPath.Show();
            }
        }

        private void TysWinRepostFrmMain_Load(object sender, EventArgs e)
        {
            TysWinReportFrmCopy frmCopy = new TysWinReportFrmCopy();
            frmCopy.MdiParent = this;
            this.cargarLogo();
            frmCopy.Show();
        }

        private void cargarLogo()
        {
            try
            {
                var empresa = _empresaRepositoryQuery.GetEmpresaActiva();
                this.BackgroundImage = Image.FromFile(empresa.logotipo);
                this.BackgroundImageLayout = ImageLayout.Center;
            }
            catch (Exception ex)
            {
            }

        }

        private void configuraciónEmpresaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form? frmEmpresa = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is TysWinReportFrmEmpresa);

            if (frmEmpresa != null)
            {
                frmEmpresa.BringToFront();
            }
            else
            {
                frmEmpresa = new TysWinReportFrmEmpresa();
                frmEmpresa.MdiParent = this;
                frmEmpresa.Show();
            }
        }

        private void clasificaciónVehicularToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form? frmClasificacionVehicular = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is TysWinReportFrmClasificacionVehicular);

            if (frmClasificacionVehicular != null)
            {
                frmClasificacionVehicular.BringToFront();
            }
            else
            {
                frmClasificacionVehicular = new TysWinReportFrmClasificacionVehicular();
                frmClasificacionVehicular.MdiParent = this;
                frmClasificacionVehicular.Show();
            }
        }

        private void configuraciónEstaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form? frmEstacion = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is TysWinReportFrmEstacion);

            if (frmEstacion != null)
            {
                frmEstacion.BringToFront();
            }
            else
            {
                frmEstacion = new TysWinReportFrmEstacion();
                frmEstacion.MdiParent = this;
                frmEstacion.Show();
            }
        }

        private void cargarDatosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form? frmCargarDatos = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is TysWinReportFrmCargarDatos);

            if (frmCargarDatos != null)
            {
                frmCargarDatos.BringToFront();
            }
            else
            {
                frmCargarDatos = new TysWinReportFrmCargarDatos();
                frmCargarDatos.MdiParent = this;
                frmCargarDatos.Show();
            }
        }

        private void conteoVehicularPorDiaYClasificaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form? frmConteoPorDiayClasificacion = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is TysWinReportFrmConteoVehicularPorDiaYClasificacion);

            if (frmConteoPorDiayClasificacion != null)
            {
                frmConteoPorDiayClasificacion.BringToFront();
            }
            else
            {
                frmConteoPorDiayClasificacion = new TysWinReportFrmConteoVehicularPorDiaYClasificacion();
                frmConteoPorDiayClasificacion.MdiParent = this;
                frmConteoPorDiayClasificacion.Show();
            }
        }

        private void configuraciónCarrilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form? frmConfiguracionCarril = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is TysWinReportFrmConfiguracionCarril);

            if (frmConfiguracionCarril != null)
            {
                frmConfiguracionCarril.BringToFront();
            }
            else
            {
                frmConfiguracionCarril = new TysWinReportFrmConfiguracionCarril();
                frmConfiguracionCarril.MdiParent = this;
                frmConfiguracionCarril.Show();
            }
        }

        private void conteoVehicularPorPeriodoYClasificaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form? frmConteoPorPeriodoyClasificacion = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is TysWinReportFrmConteoPorPeriodoYClasificacion);

            if (frmConteoPorPeriodoyClasificacion != null)
            {
                frmConteoPorPeriodoyClasificacion.BringToFront();
            }
            else
            {
                frmConteoPorPeriodoyClasificacion = new TysWinReportFrmConteoPorPeriodoYClasificacion();
                frmConteoPorPeriodoyClasificacion.MdiParent = this;
                frmConteoPorPeriodoyClasificacion.Show();
            }
        }

        private void conteoVehicularPorPeriodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form? frmConteoVehicularPorPeriodo = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is TysWinReportFrmConteoVehicularPorPeriodo);

            if (frmConteoVehicularPorPeriodo != null)
            {
                frmConteoVehicularPorPeriodo.BringToFront();
            }
            else
            {
                frmConteoVehicularPorPeriodo = new TysWinReportFrmConteoVehicularPorPeriodo();
                frmConteoVehicularPorPeriodo.MdiParent = this;
                frmConteoVehicularPorPeriodo.Show();
            }
        }

        private void conteoVehicularPorDiaYHoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form? frmConteoPorDiaPorHora = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is TysWinReportFrmConteoVehicularPorDiaPorHora);

            if (frmConteoPorDiaPorHora != null)
            {
                frmConteoPorDiaPorHora.BringToFront();
            }
            else
            {
                frmConteoPorDiaPorHora = new TysWinReportFrmConteoVehicularPorDiaPorHora();
                frmConteoPorDiaPorHora.MdiParent = this;
                frmConteoPorDiaPorHora.Show();
            }
        }

        private void conteoVehicularPorDiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form? frmConteoPorDiaPorHoraPorClase = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is TysWinReportFrmConteoVehicularPorDiaPorHoraPorClase);

            if (frmConteoPorDiaPorHoraPorClase != null)
            {
                frmConteoPorDiaPorHoraPorClase.BringToFront();
            }
            else
            {
                frmConteoPorDiaPorHoraPorClase = new TysWinReportFrmConteoVehicularPorDiaPorHoraPorClase();
                frmConteoPorDiaPorHoraPorClase.MdiParent = this;
                frmConteoPorDiaPorHoraPorClase.Show();
            }
        }

        private void sobrepesoPorDíaYClasificaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form? frmSobrepesoPorDiaYClasificacion = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is TysWinReportFrmSobrepesoPorDiaYClasificacion);

            if (frmSobrepesoPorDiaYClasificacion != null)
            {
                frmSobrepesoPorDiaYClasificacion.BringToFront();
            }
            else
            {
                frmSobrepesoPorDiaYClasificacion = new TysWinReportFrmSobrepesoPorDiaYClasificacion();
                frmSobrepesoPorDiaYClasificacion.MdiParent = this;
                frmSobrepesoPorDiaYClasificacion.Show();
            }
        }

        private void sobrepesoPorPeriodoYClasificaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form? frmSobrepesoPorPeriodoYClasificacion = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is TysWinReportFrmSobrepesoPorPeriodoYClasificacion);

            if (frmSobrepesoPorPeriodoYClasificacion != null)
            {
                frmSobrepesoPorPeriodoYClasificacion.BringToFront();
            }
            else
            {
                frmSobrepesoPorPeriodoYClasificacion = new TysWinReportFrmSobrepesoPorPeriodoYClasificacion();
                frmSobrepesoPorPeriodoYClasificacion.MdiParent = this;
                frmSobrepesoPorPeriodoYClasificacion.Show();
            }
        }

        private void pesoPorDíaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form? frmPesoPorDiaYClasificacion = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is TysWinReportFrmPesoPorDiaYClasificacion);

            if (frmPesoPorDiaYClasificacion != null)
            {
                frmPesoPorDiaYClasificacion.BringToFront();
            }
            else
            {
                frmPesoPorDiaYClasificacion = new TysWinReportFrmPesoPorDiaYClasificacion();
                frmPesoPorDiaYClasificacion.MdiParent = this;
                frmPesoPorDiaYClasificacion.Show();
            }
        }

        private void perToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form? frmPesoPorPeriodoYClasificacion = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is TysWinReportFrmPesoPorPeriodoYClasificacion);

            if (frmPesoPorPeriodoYClasificacion != null)
            {
                frmPesoPorPeriodoYClasificacion.BringToFront();
            }
            else
            {
                frmPesoPorPeriodoYClasificacion = new TysWinReportFrmPesoPorPeriodoYClasificacion();
                frmPesoPorPeriodoYClasificacion.MdiParent = this;
                frmPesoPorPeriodoYClasificacion.Show();
            }
        }

        private void tPDAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form? frmCalcularTPDA = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is TysWinReportFrmCalcularTPDA);

            if (frmCalcularTPDA != null)
            {
                frmCalcularTPDA.BringToFront();
            }
            else
            {
                frmCalcularTPDA = new TysWinReportFrmCalcularTPDA();
                frmCalcularTPDA.MdiParent = this;
                frmCalcularTPDA.Show();
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}