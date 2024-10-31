using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TYS_WIM_REPORT.Dtos;
using TYS_WIM_REPORT.Modelos;
using TYS_WIM_REPORT.Reportes;
using TYS_WIM_REPORT.Reportes.ConteoVehicularPorDiaYClasificacion.DataSet1TableAdapters;
using TYS_WIM_REPORT.Repositorios.Queries;

namespace TYS_WIM_REPORT
{
    public partial class TysWinReportFrmConteoVehicularPorDiaYClasificacion: Form
    {
        private readonly EstacionRepositoryQuery _estacionRepositoryQuery = new();
        private readonly EmpresaRepositoryQuery _empresaRepositoryQuery = new();
        private readonly ConfiguracionCarrilRepositoryQuery _configuracionCarrilRepositoryQuery = new();
        private List<Estacion> estaciones = new List<Estacion>();
        public TysWinReportFrmConteoVehicularPorDiaYClasificacion()
        {
            InitializeComponent();
        }

        private void TysWinReportFrmConteoVehicularPorDiaYClasificacion_Load(object sender, EventArgs e)
        {
            this.listarEstacion();
            this.limitDate();
            reportViewer1.Width = this.Width - 60;
            reportViewer1.Height = this.Height - 125;
        }

        private void listarEstacion()
        {
            this.estaciones.Clear();

            this.estaciones = (List<Estacion>)_estacionRepositoryQuery.GetAll();

            cbxEstacion.DataSource = this.estaciones;
            cbxEstacion.DisplayMember = "nombreEstacion";
            cbxEstacion.ValueMember = "idEstacion";
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            var estacion = (Estacion)cbxEstacion.SelectedItem;
            var fecha = dateTimePicker1.Value;
            var encabezadoReportePorDia = _estacionRepositoryQuery.ObtenerEncabezadoReportePorDia((long)estacion.idEstacion);

            ReportParameter[] parametros = new ReportParameter[19];
            this.inicializarParametros(parametros);
            parametros[0] = new ReportParameter("periodoAforo", dateTimePicker1.Value.ToLongDateString());
            parametros[1] = new ReportParameter("vialidadAforo", encabezadoReportePorDia.nombreTramoCarretera + " " + encabezadoReportePorDia.kilometraje);
            parametros[2] = new ReportParameter("tipoCamino", encabezadoReportePorDia.tipoCamino);
            parametros[3] = new ReportParameter("fechaActual", DateTime.UtcNow.ToShortDateString());

            var configuracionCarril = _configuracionCarrilRepositoryQuery.ObtenerConfiguracionCarril((long)estacion.idEstacion);

            this.configurarEncabezadosReporte(configuracionCarril, parametros);          

            try
            {
                var empresa = _empresaRepositoryQuery.GetEmpresaActiva();

                parametros[6] = new ReportParameter("nombreEmpresa", empresa.nombreEmpresa);
                parametros[7] = new ReportParameter("logotipo", new Uri(empresa.logotipo).AbsoluteUri);

                var reportDataSource = new ReportDataSource(name: "DataSet1", dataSourceValue: (DataTable)(new SP_ConteoPorDiaYClasificacionTableAdapter().GetDataConteoPorDiaYClasificacion(estacion.nombreEstacion + fecha.Year, fecha.ToString("yyyy/MM/dd"))));
                reportViewer1.LocalReport.ReportPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reportes\\ConteoVehicularPorDiaYClasificacion\\Report1.rdlc");
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

        private void TysWinReportFrmConteoVehicularPorDiaYClasificacion_SizeChanged(object sender, EventArgs e)
        {
            reportViewer1.Width = this.Width - 60;
            reportViewer1.Height = this.Height - 125;
        }

        private void configurarEncabezadosReporte(IList<ConfiguracionCarril> configuracionCarrils, ReportParameter[] parametros)
        {
            foreach (var configuracion in configuracionCarrils)
            {
                switch (configuracion.DIRECTION_NUMBER)
                {
                    case 1:
                        parametros[4] = new ReportParameter("direccionUno", configuracion.DIRECTION_NAME);
                        switch (configuracion.LANE)
                        {
                            case 1:
                                parametros[8] = new ReportParameter("AL1", configuracion.LANE_NAME);
                                break;
                            case 2:
                                parametros[9] = new ReportParameter("AL2", configuracion.LANE_NAME);
                                break;
                            case 3:
                                parametros[10] = new ReportParameter("AL3", configuracion.LANE_NAME);
                                break;
                            case 4:
                                parametros[11] = new ReportParameter("AL4", configuracion.LANE_NAME);
                                break;
                        }
                        break;
                    case 2:
                        parametros[5] = new ReportParameter("direccionDos", configuracion.DIRECTION_NAME);
                        switch (configuracion.LANE)
                        {
                            case 1:
                                parametros[12] = new ReportParameter("BL1", configuracion.LANE_NAME);
                                break;
                            case 2:
                                parametros[13] = new ReportParameter("BL2", configuracion.LANE_NAME);
                                break;
                            case 3:
                                parametros[14] = new ReportParameter("BL3", configuracion.LANE_NAME);
                                break;
                            case 4:
                                parametros[15] = new ReportParameter("BL4", configuracion.LANE_NAME);
                                break;
                        }
                        break;
                }
            }
        }

        private void inicializarParametros(ReportParameter[] parametros)
        {
            parametros[0] = new ReportParameter("periodoAforo", "Periodo");
            parametros[1] = new ReportParameter("vialidadAforo", "Vialidad");
            parametros[2] = new ReportParameter("tipoCamino", "Tipo");
            parametros[3] = new ReportParameter("fechaActual", "Fecha");
            parametros[4] = new ReportParameter("direccionUno", "Direccion 1");
            parametros[5] = new ReportParameter("direccionDos", "Direccion 2");
            parametros[6] = new ReportParameter("nombreEmpresa", "Empresa");
            parametros[7] = new ReportParameter("logotipo", "Logo");
            parametros[8] = new ReportParameter("AL1", "AL1");
            parametros[9] = new ReportParameter("AL2", "AL2");
            parametros[10] = new ReportParameter("AL3", "AL3");
            parametros[11] = new ReportParameter("AL4", "AL4");
            parametros[12] = new ReportParameter("BL1", "BL1");
            parametros[13] = new ReportParameter("BL2", "BL2");
            parametros[14] = new ReportParameter("BL3", "BL3");
            parametros[15] = new ReportParameter("BL4", "BL4");
            parametros[16] = new ReportParameter("titulo", "Hora");
            parametros[17] = new ReportParameter("descripcion", "Conteo Vehicular por Día y Clasificación");
            parametros[18] = new ReportParameter("clase", "");
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

        private void limitDate()
        {
            dateTimePicker1.MaxDate = DateTime.Now;
        }
    }
}