namespace TYS_WIM_REPORT
{
    partial class TysWinReportFrmClasificacionVehicular
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            txtClasificacion = new TextBox();
            btnCancelar = new Button();
            btnGuardar = new Button();
            groupBox1 = new GroupBox();
            numPesoMaximo = new NumericUpDown();
            lblPesoMaximo = new Label();
            lblClasificacion = new Label();
            cbxEmpresa = new ComboBox();
            label4 = new Label();
            groupBox2 = new GroupBox();
            dataGridView1 = new DataGridView();
            btnEliminar = new Button();
            btnEditar = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numPesoMaximo).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 56);
            label1.Name = "label1";
            label1.Size = new Size(95, 20);
            label1.TabIndex = 0;
            label1.Text = "Clasificación:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(26, 138);
            label2.Name = "label2";
            label2.Size = new Size(100, 20);
            label2.TabIndex = 1;
            label2.Text = "Peso máximo:";
            // 
            // txtClasificacion
            // 
            txtClasificacion.Location = new Point(26, 79);
            txtClasificacion.Name = "txtClasificacion";
            txtClasificacion.Size = new Size(318, 27);
            txtClasificacion.TabIndex = 3;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(150, 301);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(94, 27);
            btnCancelar.TabIndex = 6;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(26, 300);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(94, 28);
            btnGuardar.TabIndex = 7;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(numPesoMaximo);
            groupBox1.Controls.Add(lblPesoMaximo);
            groupBox1.Controls.Add(lblClasificacion);
            groupBox1.Controls.Add(cbxEmpresa);
            groupBox1.Controls.Add(btnCancelar);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(btnGuardar);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtClasificacion);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(387, 347);
            groupBox1.TabIndex = 9;
            groupBox1.TabStop = false;
            groupBox1.Text = "Clasificación";
            // 
            // numPesoMaximo
            // 
            numPesoMaximo.DecimalPlaces = 2;
            numPesoMaximo.Location = new Point(26, 161);
            numPesoMaximo.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numPesoMaximo.Name = "numPesoMaximo";
            numPesoMaximo.Size = new Size(318, 27);
            numPesoMaximo.TabIndex = 11;
            // 
            // lblPesoMaximo
            // 
            lblPesoMaximo.AutoSize = true;
            lblPesoMaximo.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPesoMaximo.ForeColor = Color.Red;
            lblPesoMaximo.Location = new Point(26, 189);
            lblPesoMaximo.Name = "lblPesoMaximo";
            lblPesoMaximo.Size = new Size(43, 17);
            lblPesoMaximo.TabIndex = 9;
            lblPesoMaximo.Text = "label5";
            lblPesoMaximo.Visible = false;
            // 
            // lblClasificacion
            // 
            lblClasificacion.AutoSize = true;
            lblClasificacion.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblClasificacion.ForeColor = Color.Red;
            lblClasificacion.Location = new Point(26, 107);
            lblClasificacion.Name = "lblClasificacion";
            lblClasificacion.Size = new Size(43, 17);
            lblClasificacion.TabIndex = 8;
            lblClasificacion.Text = "label5";
            lblClasificacion.Visible = false;
            // 
            // cbxEmpresa
            // 
            cbxEmpresa.FormattingEnabled = true;
            cbxEmpresa.Location = new Point(26, 244);
            cbxEmpresa.Name = "cbxEmpresa";
            cbxEmpresa.Size = new Size(318, 28);
            cbxEmpresa.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(26, 221);
            label4.Name = "label4";
            label4.Size = new Size(69, 20);
            label4.TabIndex = 6;
            label4.Text = "Empresa:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dataGridView1);
            groupBox2.Location = new Point(405, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(525, 347);
            groupBox2.TabIndex = 10;
            groupBox2.TabStop = false;
            groupBox2.Text = "Clasificación Registrada";
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = SystemColors.Control;
            dataGridView1.ColumnHeadersHeight = 29;
            dataGridView1.Location = new Point(6, 31);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(513, 310);
            dataGridView1.TabIndex = 0;
            dataGridView1.RowHeaderMouseClick += dataGridView1_RowHeaderMouseClick;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(847, 382);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(77, 29);
            btnEliminar.TabIndex = 12;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Visible = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(744, 382);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(77, 29);
            btnEditar.TabIndex = 13;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Visible = false;
            btnEditar.Click += btnEditar_Click;
            // 
            // TysWinReportFrmClasificacionVehicular
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(953, 430);
            Controls.Add(btnEditar);
            Controls.Add(btnEliminar);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "TysWinReportFrmClasificacionVehicular";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Clasificación Vehicular";
            Load += TysWinReportFrmClasificacionVehicular_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numPesoMaximo).EndInit();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtClasificacion;
        private Button btnCancelar;
        private Button btnGuardar;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private DataGridView dataGridView1;
        private ComboBox cbxEmpresa;
        private Label label4;
        private Label lblClasificacion;
        private Label lblPesoMaximo;
        private Button btnEliminar;
        private Button btnEditar;
        private NumericUpDown numPesoMaximo;
    }
}