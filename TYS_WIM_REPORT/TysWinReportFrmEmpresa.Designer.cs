namespace TYS_WIM_REPORT
{
    partial class TysWinReportFrmEmpresa
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
            txtEmpresa = new TextBox();
            txtRutaLogo = new TextBox();
            btnCancelar = new Button();
            btnGuardar = new Button();
            lblEmpresa = new Label();
            lblRutaLogo = new Label();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            dataGridView1 = new DataGridView();
            btnEditar = new Button();
            btnEliminar = new Button();
            btnActivar = new Button();
            openFileDialog1 = new OpenFileDialog();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 50);
            label1.Name = "label1";
            label1.Size = new Size(69, 20);
            label1.TabIndex = 0;
            label1.Text = "Empresa:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(29, 133);
            label2.Name = "label2";
            label2.Size = new Size(77, 20);
            label2.TabIndex = 1;
            label2.Text = "Ruta logo:";
            // 
            // txtEmpresa
            // 
            txtEmpresa.Location = new Point(29, 73);
            txtEmpresa.Name = "txtEmpresa";
            txtEmpresa.Size = new Size(297, 27);
            txtEmpresa.TabIndex = 5;
            // 
            // txtRutaLogo
            // 
            txtRutaLogo.Location = new Point(29, 156);
            txtRutaLogo.Name = "txtRutaLogo";
            txtRutaLogo.Size = new Size(297, 27);
            txtRutaLogo.TabIndex = 6;
            txtRutaLogo.Click += txtRutaLogo_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(170, 225);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(94, 29);
            btnCancelar.TabIndex = 10;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(29, 225);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(94, 29);
            btnGuardar.TabIndex = 11;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // lblEmpresa
            // 
            lblEmpresa.AutoSize = true;
            lblEmpresa.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEmpresa.ForeColor = Color.Red;
            lblEmpresa.Location = new Point(29, 101);
            lblEmpresa.Name = "lblEmpresa";
            lblEmpresa.Size = new Size(43, 17);
            lblEmpresa.TabIndex = 12;
            lblEmpresa.Text = "label3";
            lblEmpresa.Visible = false;
            // 
            // lblRutaLogo
            // 
            lblRutaLogo.AutoSize = true;
            lblRutaLogo.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRutaLogo.ForeColor = Color.Red;
            lblRutaLogo.Location = new Point(29, 184);
            lblRutaLogo.Name = "lblRutaLogo";
            lblRutaLogo.Size = new Size(43, 17);
            lblRutaLogo.TabIndex = 13;
            lblRutaLogo.Text = "label3";
            lblRutaLogo.Visible = false;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtRutaLogo);
            groupBox1.Controls.Add(lblRutaLogo);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(lblEmpresa);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(btnGuardar);
            groupBox1.Controls.Add(txtEmpresa);
            groupBox1.Controls.Add(btnCancelar);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(367, 276);
            groupBox1.TabIndex = 14;
            groupBox1.TabStop = false;
            groupBox1.Text = "Empresa";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dataGridView1);
            groupBox2.Location = new Point(400, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(547, 276);
            groupBox2.TabIndex = 15;
            groupBox2.TabStop = false;
            groupBox2.Text = "Empresas Registradas";
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = SystemColors.Control;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(6, 26);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(535, 244);
            dataGridView1.TabIndex = 0;
            dataGridView1.RowHeaderMouseClick += dataGridView1_RowHeaderMouseClick;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(626, 311);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(94, 29);
            btnEditar.TabIndex = 16;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Visible = false;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(738, 311);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(94, 29);
            btnEliminar.TabIndex = 17;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Visible = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnActivar
            // 
            btnActivar.Location = new Point(847, 311);
            btnActivar.Name = "btnActivar";
            btnActivar.Size = new Size(94, 29);
            btnActivar.TabIndex = 18;
            btnActivar.Text = "Activar";
            btnActivar.UseVisualStyleBackColor = true;
            btnActivar.Visible = false;
            btnActivar.Click += btnActivar_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // TysWinReportFrmEmpresa
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(961, 363);
            Controls.Add(btnActivar);
            Controls.Add(btnEliminar);
            Controls.Add(btnEditar);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            ForeColor = SystemColors.ControlText;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "TysWinReportFrmEmpresa";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Empresa";
            Load += TysWinReportFrmEmpresa_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtEmpresa;
        private TextBox txtRutaLogo;
        private Button btnCancelar;
        private Button btnGuardar;
        private Label lblEmpresa;
        private Label lblRutaLogo;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private DataGridView dataGridView1;
        private Button btnEditar;
        private Button btnEliminar;
        private Button btnActivar;
        private OpenFileDialog openFileDialog1;
    }
}