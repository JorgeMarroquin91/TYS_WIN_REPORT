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
    public partial class TysWinReportFrmClasificacionVehicular : Form
    {
        private readonly ClasificacionVehicularRepositoryQuery _clasificacionVehicularRepositoryQuery = new();
        private readonly ClasificacionVehicularRepositoryCommand _clasificacionVehicularRepositoryCommand = new();
        private readonly EmpresaRepositoryQuery _empresaRepositoryQuery = new();
        private ClasificacionVehicular clasificacionVehicular = new();
        private bool editar = false;
        public TysWinReportFrmClasificacionVehicular()
        {
            InitializeComponent();
        }

        private void TysWinReportFrmClasificacionVehicular_Load(object sender, EventArgs e)
        {
            this.cargarDatos();
        }

        private void cargarDatos()
        {
            var clasificaciones = _clasificacionVehicularRepositoryQuery.GetAll();

            dataGridView1.DataSource = clasificaciones;
            dataGridView1.Columns["idClasificacionVehicular"].Visible = false;
            dataGridView1.Columns["idEmpresa"].Visible = false;
            dataGridView1.Columns["clasificacion"].HeaderText = "Clasificación";
            dataGridView1.Columns["clasificacion"].Width = 140;
            dataGridView1.Columns["pesoMaximo"].HeaderText = "Peso máximo";
            dataGridView1.Columns["pesoMaximo"].Width = 140;

            var empresas = _empresaRepositoryQuery.GetAll();

            cbxEmpresa.DataSource = empresas;
            cbxEmpresa.DisplayMember = "nombreEmpresa";
            cbxEmpresa.ValueMember = "idEmpresa";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.limpiarTextBox();
            this.ocultarTextBox();
            editar = false;
        }

        private void limpiarTextBox()
        {
            txtClasificacion.Clear();
            numPesoMaximo.Value = (decimal)0.00;
            //numPesoMaximoEje.Value = (decimal)0.00;
        }

        private bool validarTextBox()
        {
            bool validado = false;

            if(txtClasificacion.Text == "")
            {
                lblClasificacion.Text = "La clasificación es obligatoria.";
                lblClasificacion.Visible = true;
                validado = true;
            }

            if (numPesoMaximo.Value < (decimal)0.00)
            {
                lblPesoMaximo.Text = "El peso máximo es obligatorio.";
                lblPesoMaximo.Visible = true;
                validado = true;
            }

            //if (numPesoMaximoEje.Value == (decimal)0.00)
            //{
            //    lblPesoMaximoEje.Text = "El peso máximo por eje es obligatorio.";
            //    lblPesoMaximoEje.Visible = true;
            //    validado = true;
            //}

            return validado;
        }

        private void ocultarTextBox()
        {
            lblClasificacion.Visible = false;
            lblPesoMaximo.Visible = false;
            //lblPesoMaximoEje.Visible = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            this.ocultarTextBox();

            if (this.validarTextBox())
            {
                return;
            }

            if (editar)
            {
                clasificacionVehicular.clasificacion = txtClasificacion.Text;
                clasificacionVehicular.pesoMaximo = numPesoMaximo.Value;
                //clasificacionVehicular.pesoMaximoEje = numPesoMaximoEje.Value;
                clasificacionVehicular.idEmpresa = (long)cbxEmpresa.SelectedValue;

                var response = _clasificacionVehicularRepositoryCommand.Update(clasificacionVehicular);

                if (response > 0)
                {
                    MessageBox.Show("Registro guardado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.cargarDatos();
                    this.limpiarTextBox();
                }
            }
            else
            {
                clasificacionVehicular.clasificacion = txtClasificacion.Text;
                clasificacionVehicular.pesoMaximo = numPesoMaximo.Value;
                //clasificacionVehicular.pesoMaximoEje = numPesoMaximoEje.Value;
                clasificacionVehicular.idEmpresa = (long)cbxEmpresa.SelectedValue;

                var response = _clasificacionVehicularRepositoryCommand.Create(clasificacionVehicular);

                if (response > 0)
                {
                    MessageBox.Show("Registro guardado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.cargarDatos();
                    this.limpiarTextBox();
                }
            }

            editar = false;
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnEditar.Visible = true;
            btnEliminar.Visible = true;
            this.limpiarTextBox();
            this.ocultarTextBox();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            clasificacionVehicular = new ClasificacionVehicular();
            DataGridViewSelectedRowCollection filaSeleccionada = dataGridView1.SelectedRows;

            if (filaSeleccionada.Count < 1)
            {
                MessageBox.Show("Se debe seleccionar una fila", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                foreach (DataGridViewRow fila in filaSeleccionada)
                {
                    clasificacionVehicular.idClasificacionVehicular = Convert.ToInt64(fila.Cells["idClasificacionVehicular"].Value.ToString());
                    txtClasificacion.Text = fila.Cells["clasificacion"].Value.ToString();
                    numPesoMaximo.Value = (decimal)fila.Cells["pesoMaximo"].Value;
                    //numPesoMaximoEje.Value = (decimal)fila.Cells["pesoMaximoEje"].Value;
                    cbxEmpresa.SelectedValue = Convert.ToInt64(fila.Cells["idEmpresa"].Value.ToString());
                }
                editar = true;
                btnEditar.Visible = false;
                btnEliminar.Visible = false;
                this.ocultarTextBox();
            }
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
                    DialogResult result = MessageBox.Show("Clasificación: " + fila.Cells["clasificacion"].Value.ToString()
                                                            + " \n Peso máximo: " + fila.Cells["pesoMaximo"].Value.ToString(), "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        var response = _clasificacionVehicularRepositoryCommand.Delete(Convert.ToInt64(fila.Cells["idClasificacionVehicular"].Value.ToString()));

                        if (response > 0)
                        {
                            MessageBox.Show("Registro eliminado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.cargarDatos();
                        }

                    }
                }
            }

            btnEditar.Visible = false;
            btnEliminar.Visible = false;
        }
    }
}
