using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TYS_WIM_REPORT.Dtos;
using TYS_WIM_REPORT.Modelos;
using TYS_WIM_REPORT.Reportes.ConteoVehicularPorDiaYClasificacion.DataSet1TableAdapters;
using TYS_WIM_REPORT.Repositorios.Queries;

namespace TYS_WIM_REPORT
{
    public partial class TysWinReportFrmCalcularTPDA : Form
    {
        private readonly EmpresaRepositoryQuery _empresaRepositoryQuery = new();
        private readonly EstacionDatosRepositoryQuery _estacionDatosRepositoryQuery = new();
        private List<Estacion> estaciones = new List<Estacion>();

        public TysWinReportFrmCalcularTPDA()
        {
            InitializeComponent();
            reportViewer1.Width = this.Width - 60;
            reportViewer1.Height = this.Height - 125;
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy";
            dateTimePicker1.ShowUpDown = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Tpda> listaTpda = new List<Tpda>();
            ReportParameter[] parametros = new ReportParameter[3];
            this.inicializarParametros(parametros);
            parametros[0] = new ReportParameter("periodo", dateTimePicker1.Value.Year.ToString());

            try
            {
                var empresa = _empresaRepositoryQuery.GetEmpresaActiva();

                parametros[1] = new ReportParameter("nombreEmpresa", empresa.nombreEmpresa);
                parametros[2] = new ReportParameter("logotipo", new Uri(empresa.logotipo).AbsoluteUri);

                var estaciones = _estacionDatosRepositoryQuery.GetAll(dateTimePicker1.Value.Year);

                foreach (var estacion in estaciones)
                {
                    var datosTpda = _estacionDatosRepositoryQuery.GetAllTPDA(estacion.tabla);
                    if (datosTpda.Count > 0)
                    {
                        Tpda tpda = new Tpda();
                        tpda.estacion = estacion.tabla.Substring(0,estacion.tabla.Length - 4);
                        tpda.tpda = (int)datosTpda.Average(r => r.CONTEO);
                        listaTpda.Add(tpda);
                    }
                }
                var reportDataSource = new ReportDataSource(name: "DataSet3", dataSourceValue: listaTpda);
                reportViewer1.LocalReport.ReportPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reportes\\TPDA\\Report3.rdlc");
                reportViewer1.LocalReport.DataSources.Clear();
                this.alterExport(reportViewer1);
                reportViewer1.LocalReport.EnableExternalImages = true;
                reportViewer1.LocalReport.DataSources.Add(reportDataSource);
                reportViewer1.LocalReport.SetParameters(parametros);
                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No hay datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void inicializarParametros(ReportParameter[] parametros)
        {
            parametros[0] = new ReportParameter("periodo", "Periodo");
            parametros[1] = new ReportParameter("nombreEmpresa", "Empresa");
            parametros[2] = new ReportParameter("logotipo", "Logo");
        }

        private void alterExport(ReportViewer reportViewer1)
        {
            foreach (RenderingExtension extension in reportViewer1.LocalReport.ListRenderingExtensions())
            {
                if (extension.Name == "MHTML" || extension.Name == "HTML4.0" || extension.Name == "HTML5")
                {
                    // Access the internal field 'm_isVisible' to hide the extension
                    FieldInfo fieldInfo = extension.GetType().GetField("m_isVisible", BindingFlags.Instance | BindingFlags.NonPublic);
                    if (fieldInfo != null)
                    {
                        fieldInfo.SetValue(extension, false);
                    }
                }
            }
        }

        private void TysWinReportFrmCalcularTPDA_SizeChanged(object sender, EventArgs e)
        {
            reportViewer1.Width = this.Width - 60;
            reportViewer1.Height = this.Height - 125;
        }
    }
}
