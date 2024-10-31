using Microsoft.ReportingServices.Interfaces;
using TYS_WIM_REPORT.Modelos;
using TYS_WIM_REPORT.Repositorios.Commands;
using TYS_WIM_REPORT.Repositorios.Queries;
using TYS_WIM_REPORT.Properties;

namespace TYS_WIM_REPORT
{
    public partial class TysWinReportFrmEmpresa : Form
    {
        private readonly EmpresaRepositoryCommand _empresaRepositoryCommand = new();
        private readonly EmpresaRepositoryQuery _empresaRepositoryQuery = new();
        private Empresa empresa = new();
        private Boolean editar = false;
        public TysWinReportFrmEmpresa()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.limpiarTextBox();
            this.ocultarLabel();
            editar = false;
        }

        private void limpiarTextBox()
        {
            txtEmpresa.Text = string.Empty;
            txtRutaLogo.Text = string.Empty;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            this.ocultarLabel();

            if (this.verificar())
            {
                empresa.nombreEmpresa = txtEmpresa.Text;
                empresa.logotipo = txtRutaLogo.Text;

                if (editar)
                {
                    var response = _empresaRepositoryCommand.Update(empresa);

                    if (response > 0)
                    {
                        MessageBox.Show("Registro actualizar", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.cargarEmpresas();
                    }
                }
                else
                {
                    var response = _empresaRepositoryCommand.Create(empresa);

                    if (response > 0)
                    {
                        MessageBox.Show("Registro guardado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.cargarEmpresas();
                    }
                }

            }
        }

        private bool verificar()
        {
            bool verificado = true;

            if (txtEmpresa.Text == "")
            {
                lblEmpresa.Text = "Campo empresa es obligatorio";
                lblEmpresa.Visible = true;
                verificado = false;
            }

            if (txtRutaLogo.Text == "")
            {
                lblRutaLogo.Text = "Campo ruta logo es obligatorio";
                lblRutaLogo.Visible = true;
                verificado = false;
            }

            return verificado;
        }

        private void ocultarLabel()
        {
            lblEmpresa.Visible = false;
            lblRutaLogo.Visible = false;
        }

        private void txtRutaLogo_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtRutaLogo.Text = openFileDialog1.FileName;
            }
        }

        private void TysWinReportFrmEmpresa_Load(object sender, EventArgs e)
        {
            this.cargarEmpresas();
        }

        private void cargarEmpresas()
        {
            var empresas = _empresaRepositoryQuery.GetAll();

            dataGridView1.DataSource = empresas;
            dataGridView1.Columns["idEmpresa"].Visible = false;
            dataGridView1.Columns["nombreEmpresa"].HeaderText = "Nombre empresa";
            dataGridView1.Columns["nombreEmpresa"].Width = 150;
            dataGridView1.Columns["logotipo"].HeaderText = "Ruta logotipo";
            dataGridView1.Columns["logotipo"].Width = 250;
            
            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.DataPropertyName = "activo";
            checkBoxColumn.Name = "activo";
            checkBoxColumn.HeaderText = "Activo";

            var indexColumn = dataGridView1.Columns["activo"].Index;
            dataGridView1.Columns.Remove("activo");
            dataGridView1.Columns.Insert(indexColumn,checkBoxColumn);
            dataGridView1.Columns["activo"].Width = 75;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            empresa = new();

            DataGridViewSelectedRowCollection filaSeleccionada = dataGridView1.SelectedRows;

            if (filaSeleccionada.Count < 1)
            {
                MessageBox.Show("Se debe seleccionar una fila", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                foreach (DataGridViewRow fila in filaSeleccionada)
                {
                    empresa.idEmpresa = Convert.ToInt64(fila.Cells["idEmpresa"].Value.ToString());
                    txtEmpresa.Text = fila.Cells["nombreEmpresa"].Value.ToString();
                    txtRutaLogo.Text = fila.Cells["logotipo"].Value.ToString();
                }
                editar = true;
                btnEditar.Visible = false;
                btnEliminar.Visible = false;
                btnActivar.Visible = false;
                this.ocultarLabel();
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
                    DialogResult result = MessageBox.Show("Empresa: " + fila.Cells["nombreEmpresa"].Value.ToString()
                                                            + " \n Ruta logo: " + fila.Cells["logotipo"].Value.ToString(), "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        var response = _empresaRepositoryCommand.Delete(Convert.ToInt64(fila.Cells["idEmpresa"].Value.ToString()));

                        if (response > 0)
                        {
                            MessageBox.Show("Registro eliminado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.cargarEmpresas();
                        }

                    }
                }
            }

            btnEditar.Visible = false;
            btnEliminar.Visible = false;
            btnActivar.Visible = false;
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnEditar.Visible = true;
            btnEliminar.Visible = true;
            btnActivar.Visible = true;
            this.limpiarTextBox();
            this.ocultarLabel();
        }

        private void btnActivar_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection filaSeleccionada = dataGridView1.SelectedRows;
            long idEmpresa = 0;

            if (filaSeleccionada.Count < 1)
            {
                MessageBox.Show("Se debe seleccionar una fila", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                foreach (DataGridViewRow fila in filaSeleccionada)
                {
                    DialogResult result = MessageBox.Show("Empresa: " + fila.Cells["nombreEmpresa"].Value.ToString()
                                                            + " \n Ruta logo: " + fila.Cells["logotipo"].Value.ToString(), "Activar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    idEmpresa = Convert.ToInt64(fila.Cells["idEmpresa"].Value.ToString());

                    if (result == DialogResult.Yes)
                    {
                        var response = _empresaRepositoryCommand.Activar(idEmpresa);

                        if (response > 0)
                        {
                            MessageBox.Show("Empresa activada", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Settings.Default.empresaActiva = idEmpresa;
                            this.cargarEmpresas();
                        }

                    }
                }
            }

            btnEditar.Visible = false;
            btnEliminar.Visible = false;
            btnActivar.Visible = false;
        }
    }
}
