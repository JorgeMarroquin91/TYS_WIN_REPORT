namespace HTMonitorNet8
{
    partial class TysWinReportFrmConf
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
            label3 = new Label();
            chkUsarGrupos = new CheckBox();
            btnCancelar = new Button();
            btnAceptar = new Button();
            dtpFechaInicio = new DateTimePicker();
            dtpFechaTerminacion = new DateTimePicker();
            label4 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(92, 20);
            label1.TabIndex = 0;
            label1.Text = "Usar Grupos:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 48);
            label2.Name = "label2";
            label2.Size = new Size(111, 20);
            label2.TabIndex = 1;
            label2.Text = "Fecha de inicio:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 84);
            label3.Name = "label3";
            label3.Size = new Size(154, 20);
            label3.TabIndex = 2;
            label3.Text = "Fecha de terminación:";
            // 
            // chkUsarGrupos
            // 
            chkUsarGrupos.AutoSize = true;
            chkUsarGrupos.Location = new Point(293, 12);
            chkUsarGrupos.Name = "chkUsarGrupos";
            chkUsarGrupos.Size = new Size(18, 17);
            chkUsarGrupos.TabIndex = 3;
            chkUsarGrupos.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(12, 127);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(94, 29);
            btnCancelar.TabIndex = 6;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(217, 127);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(94, 29);
            btnAceptar.TabIndex = 7;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // dtpFechaInicio
            // 
            dtpFechaInicio.Format = DateTimePickerFormat.Short;
            dtpFechaInicio.Location = new Point(177, 43);
            dtpFechaInicio.Name = "dtpFechaInicio";
            dtpFechaInicio.Size = new Size(134, 27);
            dtpFechaInicio.TabIndex = 8;
            // 
            // dtpFechaTerminacion
            // 
            dtpFechaTerminacion.Format = DateTimePickerFormat.Short;
            dtpFechaTerminacion.Location = new Point(177, 79);
            dtpFechaTerminacion.Name = "dtpFechaTerminacion";
            dtpFechaTerminacion.Size = new Size(134, 27);
            dtpFechaTerminacion.TabIndex = 9;
            dtpFechaTerminacion.Value = new DateTime(2024, 7, 1, 23, 26, 18, 0);
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(112, 146);
            label4.Name = "label4";
            label4.Size = new Size(0, 20);
            label4.TabIndex = 10;
            // 
            // TysWinReportFrmConf
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(332, 175);
            ControlBox = false;
            Controls.Add(label4);
            Controls.Add(dtpFechaTerminacion);
            Controls.Add(dtpFechaInicio);
            Controls.Add(btnAceptar);
            Controls.Add(btnCancelar);
            Controls.Add(chkUsarGrupos);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "TysWinReportFrmConf";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Periodo Activo";
            Load += TysWinReportFrmConf_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private CheckBox chkUsarGrupos;
        private Button btnCancelar;
        private Button btnAceptar;
        private DateTimePicker dtpFechaInicio;
        private DateTimePicker dtpFechaTerminacion;
        private Label label4;
    }
}