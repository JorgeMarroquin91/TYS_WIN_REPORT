namespace TYS_WIM_REPORT
{
    partial class TysWinReportFrmPesoPorPeriodoYClasificacion
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
            dateTimePickerInicio = new DateTimePicker();
            btnGenerar = new Button();
            label3 = new Label();
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
            label1.Location = new Point(34, 15);
            label1.Name = "label1";
            label1.Size = new Size(67, 20);
            label1.TabIndex = 0;
            label1.Text = "Estación:";
            // 
            // cbxEstacion
            // 
            cbxEstacion.FormattingEnabled = true;
            cbxEstacion.Location = new Point(107, 15);
            cbxEstacion.Name = "cbxEstacion";
            cbxEstacion.Size = new Size(194, 28);
            cbxEstacion.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(345, 17);
            label2.Name = "label2";
            label2.Size = new Size(48, 20);
            label2.TabIndex = 2;
            label2.Text = "Inicio:";
            // 
            // dateTimePickerInicio
            // 
            dateTimePickerInicio.Format = DateTimePickerFormat.Short;
            dateTimePickerInicio.Location = new Point(399, 12);
            dateTimePickerInicio.Name = "dateTimePickerInicio";
            dateTimePickerInicio.Size = new Size(122, 27);
            dateTimePickerInicio.TabIndex = 3;
            dateTimePickerInicio.Value = new DateTime(2024, 8, 20, 0, 0, 0, 0);
            // 
            // btnGenerar
            // 
            btnGenerar.Location = new Point(807, 17);
            btnGenerar.Name = "btnGenerar";
            btnGenerar.Size = new Size(94, 29);
            btnGenerar.TabIndex = 4;
            btnGenerar.Text = "Generar";
            btnGenerar.UseVisualStyleBackColor = true;
            btnGenerar.Click += btnGenerar_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(568, 15);
            label3.Name = "label3";
            label3.Size = new Size(31, 20);
            label3.TabIndex = 5;
            label3.Text = "Fin:";
            // 
            // dateTimePickerFin
            // 
            dateTimePickerFin.Format = DateTimePickerFormat.Short;
            dateTimePickerFin.Location = new Point(605, 13);
            dateTimePickerFin.Name = "dateTimePickerFin";
            dateTimePickerFin.Size = new Size(127, 27);
            dateTimePickerFin.TabIndex = 6;
            // 
            // TysWinReportFrmPesoPorPeriodoYClasificacion
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(925, 450);
            Controls.Add(dateTimePickerFin);
            Controls.Add(label3);
            Controls.Add(btnGenerar);
            Controls.Add(dateTimePickerInicio);
            Controls.Add(label2);
            Controls.Add(cbxEstacion);
            Controls.Add(label1);
            Controls.Add(reportViewer1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "TysWinReportFrmPesoPorPeriodoYClasificacion";
            Text = "Peso por periodo y clasificación";
            WindowState = FormWindowState.Maximized;
            Load += TysWinReportFrmConteoVehicularPorDiaYClasificacion_Load;
            SizeChanged += TysWinReportFrmConteoVehicularPorDiaYClasificacion_SizeChanged;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Label label1;
        private ComboBox cbxEstacion;
        private Label label2;
        private DateTimePicker dateTimePickerInicio;
        private Button btnGenerar;
        private Label label3;
        private DateTimePicker dateTimePickerFin;
    }
}