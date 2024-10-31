using TYS_WIM_REPORT.Modelos;
using TYS_WIM_REPORT.Repositorios.Commands;
using TYS_WIM_REPORT.Repositorios.Queries;

namespace TYS_WIM_REPORT
{
    public partial class TysWinReportFrmConfiguracionCarril : Form
    {
        private readonly EstacionRepositoryQuery _estacionRepositoryQuery = new();
        private readonly ConfiguracionCarrilRepositoryQuery _configuracionCarrilRepositoryQuery = new();
        private readonly ConfiguracionCarrilRepositoryCommand _configuracionCarrilRepositoryCommand = new();
        private ConfiguracionCarril configuracionCarril = new();
        private Boolean editar = false;

        public TysWinReportFrmConfiguracionCarril()
        {
            InitializeComponent();
        }

        private void TysWinReportFrmConfiguracionCarril_Load(object sender, EventArgs e)
        {
            this.cargarConfiguracionCarril();
        }

        private void cargarConfiguracionCarril()
        {
            var configuracionCarril = _configuracionCarrilRepositoryQuery.GetAll();

            dataGridView1.DataSource = configuracionCarril;
            dataGridView1.Columns["idConfiguracionCarril"].Visible = false;
            dataGridView1.Columns["DIRECTION_NUMBER"].HeaderText = "Dirección";
            dataGridView1.Columns["DIRECTION_NUMBER"].Width = 100;

            dataGridView1.Columns["DIRECTION_NAME"].HeaderText = "Nombre";
            dataGridView1.Columns["DIRECTION_NAME"].Width = 100;

            dataGridView1.Columns["LANE"].HeaderText = "Carril";
            dataGridView1.Columns["LANE"].Width = 100;

            dataGridView1.Columns["LANE_NAME"].HeaderText = "Nombre";
            dataGridView1.Columns["LANE_NAME"].Width = 100;

            dataGridView1.Columns["idEstacion"].Visible = false;
            dataGridView1.Columns["nombreEstacion"].HeaderText = "Estación";
            dataGridView1.Columns["nombreEstacion"].Width = 100;

            var estacion = _estacionRepositoryQuery.GetAll();

            cbxEstacion.DataSource = estacion;
            cbxEstacion.DisplayMember = "nombreEstacion";
            cbxEstacion.ValueMember = "idEstacion";

            var directions = _configuracionCarrilRepositoryQuery.GetAllDirection();

            cbxDireccion.DataSource = directions;
            cbxDireccion.DisplayMember = "DIRECTION";
            cbxDireccion.ValueMember = "idDIRECTION";

            var lanes = _configuracionCarrilRepositoryQuery.GetAllLane();

            cbxCarril.DataSource = lanes;
            cbxCarril.DisplayMember = "LANE";
            cbxCarril.ValueMember = "idLANE";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            this.ocultarLabel();

            if (this.verificar())
            {
                var direction = (Direction)cbxDireccion.SelectedItem;
                var carril = (Lane)cbxCarril.SelectedItem;
                var estacion = (Estacion)cbxEstacion.SelectedItem;

                configuracionCarril.DIRECTION_NUMBER = direction.DIRECTION;
                configuracionCarril.DIRECTION_NAME = txtNombreDireccion.Text;
                configuracionCarril.LANE = carril.LANE;
                configuracionCarril.LANE_NAME = txtNombreCarril.Text;
                configuracionCarril.idEstacion = estacion.idEstacion;

                if (editar)
                {
                    var response = _configuracionCarrilRepositoryCommand.Update(configuracionCarril);

                    if (response > 0)
                    {
                        MessageBox.Show("Registro actualizado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.cargarConfiguracionCarril();
                        this.limpiarTextBox();
                    }
                }
                else
                {
                    var response = _configuracionCarrilRepositoryCommand.Create(configuracionCarril);

                    if (response > 0)
                    {
                        MessageBox.Show("Registro guardado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.cargarConfiguracionCarril();
                        this.limpiarTextBox();
                    }
                }
            }
        }

        private void ocultarLabel()
        {
            lblEstacion.Visible = false;
            lblDireccion.Visible = false;
            lblNombreDireccion.Visible = false;
            lblCarril.Visible = false;
            lblNombreCarril.Visible = false;
        }

        private bool verificar()
        {
            bool verificado = true;

            if (cbxEstacion.SelectedItem == null)
            {
                lblEstacion.Text = "La estación es obligatoria";
                lblEstacion.Visible = true;
                verificado = false;
            }

            if (cbxDireccion.SelectedItem == null)
            {
                lblDireccion.Text = "La dirección es obligatoria";
                lblDireccion.Visible = true;
                verificado = false;
            }

            if (txtNombreDireccion.Text == "")
            {
                lblNombreDireccion.Text = "El nombre es obligatorio";
                lblNombreDireccion.Visible = true;
                verificado = false;
            }

            if (cbxCarril.SelectedItem == null)
            {
                lblCarril.Text = "El carril es obligatorio";
                lblCarril.Visible = true;
                verificado = false;
            }

            if (txtNombreCarril.Text == "")
            {
                lblNombreCarril.Text = "El nombre es obligatorio";
                lblNombreCarril.Visible = true;
                verificado = false;
            }

            return verificado;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.limpiarTextBox();
            this.ocultarLabel();
            this.editar = false;
        }

        private void limpiarTextBox()
        {
            txtNombreDireccion.Clear();
            txtNombreCarril.Clear();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnEditar.Visible = true;
            btnEliminar.Visible = true;
            this.limpiarTextBox();
            this.ocultarLabel();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            configuracionCarril = new();

            DataGridViewSelectedRowCollection filaSeleccionada = dataGridView1.SelectedRows;

            if (filaSeleccionada.Count < 1)
            {
                MessageBox.Show("Se debe seleccionar una fila", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                foreach (DataGridViewRow fila in filaSeleccionada)
                {
                    configuracionCarril.idConfiguracionCarril = Convert.ToInt64(fila.Cells["idConfiguracionCarril"].Value.ToString());
                    cbxEstacion.SelectedValue = fila.Cells["idEstacion"].Value;

                    var direction = fila.Cells["DIRECTION_NUMBER"].Value;

                    foreach (Direction item in cbxDireccion.Items)
                    {
                        if (item.DIRECTION == (short)direction)
                        {
                            cbxDireccion.SelectedValue = (long)item.idDIRECTION;
                            break;
                        }
                    }

                    txtNombreDireccion.Text = fila.Cells["DIRECTION_NAME"].Value.ToString();

                    var lane = fila.Cells["LANE"].Value;

                    foreach (Lane item in cbxCarril.Items)
                    {
                        if (item.LANE == (Byte)lane)
                        {
                            cbxCarril.SelectedValue = (long)item.idLANE;
                            break;
                        }
                    }

                    txtNombreCarril.Text = fila.Cells["LANE_NAME"].Value.ToString();
                }
                editar = true;
                btnEditar.Visible = false;
                btnEliminar.Visible = false;
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
                    DialogResult result = MessageBox.Show("Estación: " + fila.Cells["nombreEstacion"].Value.ToString()
                                                            + " \n Dirección: " + fila.Cells["DIRECTION_NUMBER"].Value.ToString()
                                                            + " \n Nombre: " + fila.Cells["DIRECTION_NAME"].Value.ToString()
                                                            + " \n Carril: " + fila.Cells["LANE"].Value.ToString()
                                                            + " \n Nombre: " + fila.Cells["LANE_NAME"].Value.ToString(), "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        var response = _configuracionCarrilRepositoryCommand.Delete(Convert.ToInt64(fila.Cells["idConfiguracionCarril"].Value.ToString()));

                        if (response > 0)
                        {
                            MessageBox.Show("Registro eliminado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.cargarConfiguracionCarril();
                        }

                    }
                }
            }

            btnEditar.Visible = false;
            btnEliminar.Visible = false;
        }
    }
}
