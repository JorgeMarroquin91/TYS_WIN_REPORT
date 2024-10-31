using System.Diagnostics;

namespace TYS_WIM_REPORT
{
    partial class TysWinReportFrmConteoVehicularPorPeriodo
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
            label2 = new Label();
            label3 = new Label();
            cbxEstacion = new ComboBox();
            dateTimePickerInicio = new DateTimePicker();
            dateTimePickerFin = new DateTimePicker();
            btnGenerar = new Button();
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
            label1.Location = new Point(26, 20);
            label1.Name = "label1";
            label1.Size = new Size(67, 20);
            label1.TabIndex = 0;
            label1.Text = "Estación:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(318, 20);
            label2.Name = "label2";
            label2.Size = new Size(48, 20);
            label2.TabIndex = 1;
            label2.Text = "Inicio:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(520, 20);
            label3.Name = "label3";
            label3.Size = new Size(31, 20);
            label3.TabIndex = 2;
            label3.Text = "Fin:";
            // 
            // cbxEstacion
            // 
            cbxEstacion.FormattingEnabled = true;
            cbxEstacion.Location = new Point(99, 17);
            cbxEstacion.Name = "cbxEstacion";
            cbxEstacion.Size = new Size(184, 28);
            cbxEstacion.TabIndex = 3;
            // 
            // dateTimePickerInicio
            // 
            dateTimePickerInicio.Format = DateTimePickerFormat.Short;
            dateTimePickerInicio.Location = new Point(372, 17);
            dateTimePickerInicio.Name = "dateTimePickerInicio";
            dateTimePickerInicio.Size = new Size(122, 27);
            dateTimePickerInicio.TabIndex = 4;
            // 
            // dateTimePickerFin
            // 
            dateTimePickerFin.Format = DateTimePickerFormat.Short;
            dateTimePickerFin.Location = new Point(557, 15);
            dateTimePickerFin.Name = "dateTimePickerFin";
            dateTimePickerFin.Size = new Size(124, 27);
            dateTimePickerFin.TabIndex = 5;
            // 
            // btnGenerar
            // 
            btnGenerar.Location = new Point(729, 14);
            btnGenerar.Name = "btnGenerar";
            btnGenerar.Size = new Size(95, 28);
            btnGenerar.TabIndex = 6;
            btnGenerar.Text = "Generar";
            btnGenerar.UseVisualStyleBackColor = true;
            btnGenerar.Click += btnGenerar_Click;
            // 
            // TysWinReportFrmConteoVehicularPorPeriodo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(836, 450);
            Controls.Add(btnGenerar);
            Controls.Add(dateTimePickerFin);
            Controls.Add(dateTimePickerInicio);
            Controls.Add(cbxEstacion);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(reportViewer1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "TysWinReportFrmConteoVehicularPorPeriodo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Conteo vehicular por periodo";
            WindowState = FormWindowState.Maximized;
            Load += TysWinReportFrmConteoVehicularPorPeriodo_Load;
            SizeChanged += TysWinReportFrmConteoVehicularPorPeriodo_SizeChanged;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Label label1;
        private Label label2;
        private Label label3;
        private ComboBox cbxEstacion;
        private DateTimePicker dateTimePickerInicio;
        private DateTimePicker dateTimePickerFin;
        private Button btnGenerar;
    }
}