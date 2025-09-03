namespace TYS_WIM_REPORT
{
    partial class TysWinReportFrmConteoNuevaClasificacion
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
            reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            label1 = new Label();
            cbxEstacion = new ComboBox();
            label2 = new Label();
            label3 = new Label();
            btnGenerar = new Button();
            dateTimePickerInicio = new DateTimePicker();
            dateTimePickerFin = new DateTimePicker();
            SuspendLayout();
            // 
            // reportViewer1
            // 
            reportViewer1.Location = new Point(25, 60);
            reportViewer1.Name = "ReportViewer";
            reportViewer1.ServerReport.BearerToken = null;
            reportViewer1.Size = new Size(396, 246);
            reportViewer1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 19);
            label1.Name = "label1";
            label1.Size = new Size(67, 20);
            label1.TabIndex = 0;
            label1.Text = "Estación:";
            // 
            // cbxEstacion
            // 
            cbxEstacion.FormattingEnabled = true;
            cbxEstacion.Location = new Point(98, 16);
            cbxEstacion.Name = "cbxEstacion";
            cbxEstacion.Size = new Size(170, 28);
            cbxEstacion.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(306, 20);
            label2.Name = "label2";
            label2.Size = new Size(48, 20);
            label2.TabIndex = 2;
            label2.Text = "Inicio:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(515, 22);
            label3.Name = "label3";
            label3.Size = new Size(31, 20);
            label3.TabIndex = 3;
            label3.Text = "Fin:";
            // 
            // btnGenerar
            // 
            btnGenerar.Location = new Point(726, 16);
            btnGenerar.Name = "btnGenerar";
            btnGenerar.Size = new Size(94, 29);
            btnGenerar.TabIndex = 4;
            btnGenerar.Text = "Generar";
            btnGenerar.UseVisualStyleBackColor = true;
            btnGenerar.Click += btnGenerar_Click;
            // 
            // dateTimePickerInicio
            // 
            dateTimePickerInicio.Format = DateTimePickerFormat.Short;
            dateTimePickerInicio.Location = new Point(360, 17);
            dateTimePickerInicio.Name = "dateTimePickerInicio";
            dateTimePickerInicio.Size = new Size(122, 27);
            dateTimePickerInicio.TabIndex = 5;
            // 
            // dateTimePickerFin
            // 
            dateTimePickerFin.Format = DateTimePickerFormat.Short;
            dateTimePickerFin.Location = new Point(552, 17);
            dateTimePickerFin.Name = "dateTimePickerFin";
            dateTimePickerFin.Size = new Size(121, 27);
            dateTimePickerFin.TabIndex = 6;
            // 
            // TysWinReportFrmConteoNuevaClasificacion
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(846, 450);
            Controls.Add(dateTimePickerFin);
            Controls.Add(dateTimePickerInicio);
            Controls.Add(btnGenerar);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(cbxEstacion);
            Controls.Add(label1);
            Controls.Add(reportViewer1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "TysWinReportFrmConteoNuevaClasificacion";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Conteo vehicular nueva clasificacion";
            WindowState = FormWindowState.Maximized;
            Load += TysWinReportFrmConteoPorPeriodoYClasificacion_Load;
            SizeChanged += TysWinReportFrmConteoPorPeriodoYClasificacion_SizeChanged;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Label label1;
        private ComboBox cbxEstacion;
        private Label label2;
        private Label label3;
        private Button btnGenerar;
        private DateTimePicker dateTimePickerInicio;
        private DateTimePicker dateTimePickerFin;
    }
}