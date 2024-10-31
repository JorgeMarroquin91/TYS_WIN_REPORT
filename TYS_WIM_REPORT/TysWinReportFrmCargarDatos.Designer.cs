namespace TYS_WIM_REPORT
{
    partial class TysWinReportFrmCargarDatos
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
            components = new System.ComponentModel.Container();
            cbxEstacion = new ComboBox();
            label1 = new Label();
            btnCargar = new Button();
            btnCancelar = new Button();
            chkTodas = new CheckBox();
            progressBar1 = new ProgressBar();
            timer1 = new System.Windows.Forms.Timer(components);
            lblProgresBar = new Label();
            label3 = new Label();
            lblCarga = new Label();
            SuspendLayout();
            // 
            // cbxEstacion
            // 
            cbxEstacion.FormattingEnabled = true;
            cbxEstacion.Location = new Point(12, 32);
            cbxEstacion.Name = "cbxEstacion";
            cbxEstacion.Size = new Size(222, 28);
            cbxEstacion.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(67, 20);
            label1.TabIndex = 1;
            label1.Text = "Estación.";
            // 
            // btnCargar
            // 
            btnCargar.Location = new Point(12, 93);
            btnCargar.Name = "btnCargar";
            btnCargar.Size = new Size(94, 29);
            btnCargar.TabIndex = 3;
            btnCargar.Text = "Cargar";
            btnCargar.UseVisualStyleBackColor = true;
            btnCargar.Click += btnCargar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(140, 93);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(94, 29);
            btnCancelar.TabIndex = 4;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // chkTodas
            // 
            chkTodas.AutoSize = true;
            chkTodas.Location = new Point(316, 34);
            chkTodas.Name = "chkTodas";
            chkTodas.Size = new Size(73, 24);
            chkTodas.TabIndex = 5;
            chkTodas.Text = "Todas.";
            chkTodas.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(12, 217);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(377, 29);
            progressBar1.TabIndex = 6;
            progressBar1.Visible = false;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // lblProgresBar
            // 
            lblProgresBar.AutoSize = true;
            lblProgresBar.Location = new Point(12, 168);
            lblProgresBar.Name = "lblProgresBar";
            lblProgresBar.Size = new Size(87, 20);
            lblProgresBar.TabIndex = 7;
            lblProgresBar.Text = "Cargando ...";
            lblProgresBar.Visible = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 268);
            label3.Name = "label3";
            label3.Size = new Size(63, 20);
            label3.TabIndex = 8;
            label3.Text = "Tiempo:";
            label3.Visible = false;
            // 
            // lblCarga
            // 
            lblCarga.AutoSize = true;
            lblCarga.Location = new Point(92, 268);
            lblCarga.Name = "lblCarga";
            lblCarga.Size = new Size(63, 20);
            lblCarga.TabIndex = 9;
            lblCarga.Text = "00:00:00";
            lblCarga.Visible = false;
            // 
            // TysWinReportFrmCargarDatos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(405, 321);
            Controls.Add(lblCarga);
            Controls.Add(label3);
            Controls.Add(lblProgresBar);
            Controls.Add(progressBar1);
            Controls.Add(chkTodas);
            Controls.Add(btnCancelar);
            Controls.Add(btnCargar);
            Controls.Add(label1);
            Controls.Add(cbxEstacion);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "TysWinReportFrmCargarDatos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cargar Datos";
            Load += TysWinReportFrmCargarDatos_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cbxEstacion;
        private Label label1;
        private Button btnCargar;
        private Button btnCancelar;
        private CheckBox chkTodas;
        private ProgressBar progressBar1;
        private System.Windows.Forms.Timer timer1;
        private Label lblProgresBar;
        private Label label3;
        private Label lblCarga;
    }
}