﻿using Microsoft.Reporting.WinForms;
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
using TYS_WIM_REPORT.Modelos;
using TYS_WIM_REPORT.Reportes.ConteoVehicularPorDiaYClasificacion.DataSet1TableAdapters;
using TYS_WIM_REPORT.Repositorios.Queries;

namespace TYS_WIM_REPORT
{
    public partial class TysWinReportFrmSobrepesoPorPeriodoYClasificacion : Form
    {
        private readonly EstacionRepositoryQuery _estacionRepositoryQuery = new();
        private readonly EmpresaRepositoryQuery _empresaRepositoryQuery = new();
        private readonly ConfiguracionCarrilRepositoryQuery _configuracionCarrilRepositoryQuery = new();
        private readonly EstacionDatosRepositoryQuery _estacionDatosRepositoryQuery = new();
        private List<Estacion> estaciones = new List<Estacion>();

        public TysWinReportFrmSobrepesoPorPeriodoYClasificacion()
        {
            InitializeComponent();
        }

        private void TysWinReportFrmConteoPorPeriodoYClasificacion_Load(object sender, EventArgs e)
        {
            this.listarEstacion();
            this.limitDate();
            this.reportViewer1.Width = this.Width - 60;
            this.reportViewer1.Height = this.Height - 125;
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
            try
            {
                var estacion = (Estacion)cbxEstacion.SelectedItem;
                var fechaInicio = dateTimePickerInicio.Value;
                var fechaFin = dateTimePickerFin.Value;
                var encabezadoReportePorDia = _estacionRepositoryQuery.ObtenerEncabezadoReportePorDia((long)estacion.idEstacion);
                var estacionQuery = this.createQuery(estacion.nombreEstacion, fechaInicio.Year, fechaFin.Year);

                ReportParameter[] parametros = new ReportParameter[19];
                this.inicializarParametros(parametros);
                parametros[0] = new ReportParameter("periodoAforo", "del " + fechaInicio.ToShortDateString() + " Hasta " + fechaFin.ToShortDateString());
                parametros[1] = new ReportParameter("vialidadAforo", encabezadoReportePorDia.nombreTramoCarretera + " " + encabezadoReportePorDia.kilometraje);
                parametros[2] = new ReportParameter("tipoCamino", encabezadoReportePorDia.tipoCamino);
                parametros[3] = new ReportParameter("fechaActual", DateTime.UtcNow.ToShortDateString());

                var configuracionCarril = _configuracionCarrilRepositoryQuery.ObtenerConfiguracionCarril((long)estacion.idEstacion);

                this.configurarEncabezadosReporte(configuracionCarril, parametros);

                var empresa = _empresaRepositoryQuery.GetEmpresaActiva();

                parametros[6] = new ReportParameter("nombreEmpresa", empresa.nombreEmpresa);
                parametros[7] = new ReportParameter("logotipo", new Uri(empresa.logotipo).AbsoluteUri);

                var reportDataSource = new ReportDataSource(name: "DataSet1", dataSourceValue: (DataTable)(new SP_ConteoPorDiaYClasificacionTableAdapter().GetDataBySobrepesoPorPeriodoYClasificacion (estacionQuery, fechaInicio.ToString("yyyy/MM/dd"), fechaFin.ToString("yyyy/MM/dd"))));
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
                if(ex.GetType().Name == "SqlException")
                {
                    MessageBox.Show("No hay datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
        }

        private void TysWinReportFrmConteoPorPeriodoYClasificacion_SizeChanged(object sender, EventArgs e)
        {
            this.reportViewer1.Width = this.Width - 60;
            this.reportViewer1.Height = this.Height - 125;
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
            parametros[16] = new ReportParameter("titulo", "Clase");
            parametros[17] = new ReportParameter("descripcion", "Sobrepeso por Periodo y Clasificación");
            parametros[18] = new ReportParameter("clase", "");
        }

        private string createQuery(string estacion, int inicio, int fin)
        {
            string query = "";
            List<int> listaAnio = new();

            if (inicio != fin)
            {
                for (var i = inicio; i <= fin; i++)
                {
                    var result = _estacionDatosRepositoryQuery.ExistsTable(estacion + i);

                    if (result)
                    {
                        listaAnio.Add(i);
                    }
                }

                if (listaAnio.Count > 1)
                {
                    var contador = 1;

                    foreach (var anio in listaAnio)
                    {
                        if (contador == 1)
                        {
                            query += "(SELECT * FROM " + estacion + anio.ToString() + " UNION ";
                        }
                        else if (anio == fin)
                        {
                            query += "SELECT * FROM " + estacion + anio.ToString() + ")";
                        }
                        else
                        {
                            query += "SELECT * FROM " + estacion + anio.ToString() + " UNION ";
                        }
                        contador++;
                    }
                }
                else
                {
                    if (listaAnio.Count > 0)
                    {
                        query = estacion + listaAnio[0].ToString();
                    }
                }
            }
            else
            {
                query = estacion + inicio.ToString();
            }

            return query;
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
            dateTimePickerInicio.MaxDate = DateTime.Now;
            dateTimePickerFin.MaxDate = DateTime.Now;
        }
    }
}
