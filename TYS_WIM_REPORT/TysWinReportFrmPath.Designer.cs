namespace HTMonitorNet8
{
    partial class TysWinReportFrmPath
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
            btnCancelar = new Button();
            btnAsignar = new Button();
            label1 = new Label();
            label2 = new Label();
            txtCarpetaOrigen = new TextBox();
            txtCarpetaHistorica = new TextBox();
            folderBrowserDialog1 = new FolderBrowserDialog();
            label3 = new Label();
            txtCarpetaErrores = new TextBox();
            SuspendLayout();
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(13, 251);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(94, 29);
            btnCancelar.TabIndex = 1;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnAsignar
            // 
            btnAsignar.Location = new Point(149, 251);
            btnAsignar.Name = "btnAsignar";
            btnAsignar.Size = new Size(94, 29);
            btnAsignar.TabIndex = 2;
            btnAsignar.Text = "Asignar";
            btnAsignar.UseVisualStyleBackColor = true;
            btnAsignar.Click += btnAsignar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 18);
            label1.Name = "label1";
            label1.Size = new Size(108, 20);
            label1.TabIndex = 3;
            label1.Text = "Carpeta origen";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 90);
            label2.Name = "label2";
            label2.Size = new Size(121, 20);
            label2.TabIndex = 4;
            label2.Text = "Carpeta historica";
            // 
            // txtCarpetaOrigen
            // 
            txtCarpetaOrigen.Location = new Point(13, 41);
            txtCarpetaOrigen.Name = "txtCarpetaOrigen";
            txtCarpetaOrigen.Size = new Size(475, 27);
            txtCarpetaOrigen.TabIndex = 5;
            txtCarpetaOrigen.Click += txtCarpetaOrigen_Click;
            // 
            // txtCarpetaHistorica
            // 
            txtCarpetaHistorica.Location = new Point(13, 113);
            txtCarpetaHistorica.Name = "txtCarpetaHistorica";
            txtCarpetaHistorica.Size = new Size(475, 27);
            txtCarpetaHistorica.TabIndex = 6;
            txtCarpetaHistorica.Click += txtCarpetaHistorica_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 165);
            label3.Name = "label3";
            label3.Size = new Size(111, 20);
            label3.TabIndex = 7;
            label3.Text = "Carpeta Errores";
            // 
            // txtCarpetaErrores
            // 
            txtCarpetaErrores.Location = new Point(13, 188);
            txtCarpetaErrores.Name = "txtCarpetaErrores";
            txtCarpetaErrores.Size = new Size(475, 27);
            txtCarpetaErrores.TabIndex = 8;
            txtCarpetaErrores.Click += textBox1_Click;
            // 
            // TysWinReportFrmPath
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(508, 308);
            ControlBox = false;
            Controls.Add(txtCarpetaErrores);
            Controls.Add(label3);
            Controls.Add(txtCarpetaHistorica);
            Controls.Add(txtCarpetaOrigen);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnAsignar);
            Controls.Add(btnCancelar);
            Name = "TysWinReportFrmPath";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Carpeta de Trabajo";
            Load += TysWinReportFrmPath_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnCancelar;
        private Button btnAsignar;
        private Label label1;
        private Label label2;
        private TextBox txtCarpetaOrigen;
        private TextBox txtCarpetaHistorica;
        private FolderBrowserDialog folderBrowserDialog1;
        private Label label3;
        private TextBox txtCarpetaErrores;
    }
}