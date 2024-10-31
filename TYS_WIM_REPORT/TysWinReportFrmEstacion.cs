using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TYS_WIM_REPORT.Modelos;
using TYS_WIM_REPORT.Repositorios.Commands;
using TYS_WIM_REPORT.Repositorios.Queries;

namespace TYS_WIM_REPORT
{
    public partial class TysWinReportFrmEstacion : Form
    {
        private readonly EstacionRepositoryCommand _estacionRepositoryCommand = new();
        private readonly EstacionRepositoryQuery _estacionRepositoryQuery = new();
        private readonly TipoPavimentoRepositoryQuery _tipoPavimentoRepositoryQuery = new();
        private readonly CarrilRepositoryQuery _carrilRepositoryQuery = new();
        private readonly TipoViaRepositoryQuery _tipoViaRepositoryQuery = new();
        private readonly EmpresaRepositoryQuery _empresaRepositoryQuery = new();
        private Estacion estacion = new();
        private Boolean editar = false;

        public TysWinReportFrmEstacion()
        {
            InitializeComponent();
        }

        private void TysWinReportFrmEstacion_Load(object sender, EventArgs e)
        {
            this.cargarEstaciones();
        }

        private void cargarEstaciones()
        {
            var estaciones = _estacionRepositoryQuery.GetAll();

            dataGridView1.DataSource = estaciones;
            dataGridView1.Columns["idEstacion"].Visible = false;
            dataGridView1.Columns["idTipoPavimento"].Visible = false;
            dataGridView1.Columns["idTipoCamino"].Visible = false;
            dataGridView1.Columns["idTipovia"].Visible = false;
            dataGridView1.Columns["idEmpresa"].Visible = false;

            dataGridView1.Columns["numeroEstacion"].HeaderText ="Número estación";
            dataGridView1.Columns["nombreEstacion"].HeaderText = "Estación";
            dataGridView1.Columns["nombreTramoCarretera"].HeaderText = "Tramo carretera";
            dataGridView1.Columns["kilometraje"].HeaderText = "Kilometraje";
            dataGridView1.Columns["latitud"].HeaderText = "Latitud";
            dataGridView1.Columns["latitud"].ValueType = typeof(Decimal);
            dataGridView1.Columns["longitud"].HeaderText = "Longitud";
            dataGridView1.Columns["longitud"].ValueType = typeof(Decimal);

            var tipoPavimentos = _tipoPavimentoRepositoryQuery.GetAll();

            cbxTipoPavimento.DataSource = tipoPavimentos;
            cbxTipoPavimento.DisplayMember = "tipoPavimento";
            cbxTipoPavimento.ValueMember = "idTipoPavimento";

            var tipoCaminos = _carrilRepositoryQuery.GetAll();

            cbxCarril.DataSource = tipoCaminos;
            cbxCarril.DisplayMember = "tipoCamino";
            cbxCarril.ValueMember = "idTipoCamino";

            var tipoVias = _tipoViaRepositoryQuery.GetAll();

            cbxTipoVia.DataSource = tipoVias;
            cbxTipoVia.DisplayMember = "tipoVia";
            cbxTipoVia.ValueMember = "idTipoVia";

            var empresas = _empresaRepositoryQuery.GetAll();

            cbxEmpresa.DataSource = empresas;
            cbxEmpresa.DisplayMember = "nombreEmpresa";
            cbxEmpresa.ValueMember = "idEmpresa";
        }

        private void ocultarLabel()
        {
            lblNumeroEstacion.Visible = false;
            lblNombreEstacion.Visible = false;
            lblTramoCarretera.Visible = false;
            lblKilometraje.Visible = false;
            lblLatitud.Visible = false;
            lblLongitud.Visible = false;
            lblTipoPavimento.Visible = false;
            lblCarril.Visible = false;
            lblTipoVia.Visible = false;
            lblEmpresa.Visible = false;
        }

        private Boolean verificar()
        {
            Boolean verificado = true;

            if (txtNombreEstacion.Text == string.Empty)
            {
                lblNombreEstacion.Text = "La estación es obligatoria";
                lblNombreEstacion.Visible = true;
                verificado = false;
            }

            if (numNumeroEstacion.Value == (decimal)0.00)
            {
                lblNumeroEstacion.Text = "El número de la estación es obligatorio";
                lblNumeroEstacion.Visible = true;
                verificado = false;
            }

            if (txtTramoCarretera.Text == string.Empty)
            {
                lblTramoCarretera.Text = "El tramo de la carretera es obligatorio";
                lblTramoCarretera.Visible = true;
                verificado = false;
            }

            if (txtKilometraje.Text == string.Empty)
            {
                lblKilometraje.Text = "El kilometraje es obligatorio";
                lblKilometraje.Visible = true;
                verificado = false;
            }

            if (numLatitud.Value == (decimal)0.00)
            {
                lblLatitud.Text = "La latitud es obligatoria";
                lblLatitud.Visible = true;
                verificado = false;
            }

            if (numLongitud.Value == (decimal)0.00)
            {
                lblLongitud.Text = "La longitud es obligatoria";
                lblLongitud.Visible = true;
                verificado = false;
            }

            return verificado;
        }

        public void limpiarTextBox()
        {
            txtNombreEstacion.Text = string.Empty;
            numNumeroEstacion.Value = (decimal)0.00;
            txtTramoCarretera.Text = string.Empty;
            txtKilometraje.Text = string.Empty;
            numLatitud.Value = (decimal)0.00;
            numLongitud.Value = (decimal)0.00;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            this.ocultarLabel();

            if (this.verificar())
            {
                estacion.numeroEstacion = (int)numNumeroEstacion.Value;
                estacion.nombreEstacion = txtNombreEstacion.Text;
                estacion.nombreTramoCarretera = txtTramoCarretera.Text;
                estacion.kilometraje = txtKilometraje.Text;
                estacion.latitud = numLatitud.Value;
                estacion.longitud = numLongitud.Value;
                estacion.idTipoPavimento = (long)cbxTipoPavimento.SelectedValue;
                estacion.idTipoCamino = (long)cbxCarril.SelectedValue;
                estacion.idTipovia = (long)cbxTipoVia.SelectedValue;
                estacion.idEmpresa = (long)cbxEmpresa.SelectedValue;

                if (editar)
                {
                    var response = _estacionRepositoryCommand.Update(estacion);

                    if (response > 0)
                    {
                        MessageBox.Show("Registro guardado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.cargarEstaciones();
                        this.limpiarTextBox();
                    }
                }
                else
                {
                    var response = _estacionRepositoryCommand.Create(estacion);

                    if (response > 0)
                    {
                        MessageBox.Show("Registro guardado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.cargarEstaciones();
                        this.limpiarTextBox();
                    }
                }
                editar = false;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.ocultarLabel();
            this.limpiarTextBox();
            editar = false;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            estacion = new Estacion();
            DataGridViewSelectedRowCollection filaSeleccionada = dataGridView1.SelectedRows;

            if (filaSeleccionada.Count < 1)
            {
                MessageBox.Show("Se debe seleccionar una fila", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                foreach (DataGridViewRow fila in filaSeleccionada)
                {
                    estacion.idEstacion = Convert.ToInt64(fila.Cells["idEstacion"].Value.ToString());
                    txtNombreEstacion.Text = fila.Cells["nombreEstacion"].Value.ToString();
                    numNumeroEstacion.Value = Convert.ToInt64(fila.Cells["numeroEstacion"].Value);
                    txtTramoCarretera.Text = fila.Cells["nombreTramoCarretera"].Value.ToString();
                    txtKilometraje.Text = fila.Cells["kilometraje"].Value.ToString();
                    numLatitud.Value = (decimal)fila.Cells["latitud"].Value;
                    numLongitud.Value = (decimal)fila.Cells["longitud"].Value;
                    cbxTipoPavimento.SelectedValue = Convert.ToInt64(fila.Cells["idTipoPavimento"].Value.ToString());
                    cbxCarril.SelectedValue = Convert.ToInt64(fila.Cells["idTipoCamino"].Value.ToString());
                    cbxTipoVia.SelectedValue = Convert.ToInt64(fila.Cells["idTipoVia"].Value.ToString());
                    cbxEmpresa.SelectedValue = Convert.ToInt64(fila.Cells["idEmpresa"].Value.ToString());
                }
                editar = true;
                btnEditar.Visible = false;
                btnEliminar.Visible = false;
                this.ocultarLabel();
            }
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnEditar.Visible = true;
            btnEliminar.Visible = true;
            this.limpiarTextBox();
            this.ocultarLabel();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection filaSeleccionada = dataGridView1.SelectedRows;

            if (filaSeleccionada.Count < 1)
            {
                MessageBox.Show("Se debe seleccionar una fila", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                foreach (DataGridViewRow fila in filaSeleccionada)
                {
                    DialogResult result = MessageBox.Show("Estación: " + fila.Cells["nombreEstacion"].Value.ToString()
                                                            + " \n Número estación: " + fila.Cells["numeroEstacion"].Value.ToString()
                                                            + " \n Tramo carretera: " + fila.Cells["nombreTramoCarretera"].Value.ToString()
                                                            + " \n kilometraje: " + fila.Cells["kilometraje"].Value.ToString()
                                                            + " \n Latitud: " + fila.Cells["latitud"].Value.ToString()
                                                            + " \n Longitud: " + fila.Cells["longitud"].Value.ToString(), "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        var response = _estacionRepositoryCommand.Delete(Convert.ToInt64(fila.Cells["idEstacion"].Value.ToString()));

                        if (response > 0)
                        {
                            MessageBox.Show("Registro eliminado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.cargarEstaciones();
                        }

                    }
                }
            }

            btnEditar.Visible = false;
            btnEliminar.Visible = false;
        }
    }
}
