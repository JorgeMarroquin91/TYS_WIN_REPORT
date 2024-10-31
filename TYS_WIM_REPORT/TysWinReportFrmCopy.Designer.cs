namespace HTMonitorNet8
{
    partial class TysWinReportFrmCopy
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TysWinReportFrmCopy));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            label5 = new Label();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(175, 9);
            label1.Name = "label1";
            label1.Size = new Size(210, 31);
            label1.TabIndex = 0;
            label1.Text = "TYS-WIM-REPORT";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(149, 56);
            label2.Name = "label2";
            label2.Size = new Size(91, 20);
            label2.TabIndex = 1;
            label2.Text = "Versión 1.0.0";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(149, 88);
            label3.Name = "label3";
            label3.Size = new Size(170, 20);
            label3.TabIndex = 2;
            label3.Text = "Copyright @2024 TYSSA";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(149, 118);
            label4.Name = "label4";
            label4.Size = new Size(344, 20);
            label4.TabIndex = 3;
            label4.Text = "Software para monitoreo vehicular de uso general.";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = TYS_WIM_REPORT.Properties.Resources.Tyssa;
            pictureBox1.Location = new Point(12, 83);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(111, 38);
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Black;
            panel1.Location = new Point(12, 158);
            panel1.Name = "panel1";
            panel1.Size = new Size(485, 1);
            panel1.TabIndex = 5;
            // 
            // label5
            // 
            label5.Location = new Point(12, 175);
            label5.Name = "label5";
            label5.Size = new Size(376, 121);
            label5.TabIndex = 6;
            label5.Text = resources.GetString("label5.Text");
            // 
            // button1
            // 
            button1.Location = new Point(408, 218);
            button1.Name = "button1";
            button1.Size = new Size(85, 29);
            button1.TabIndex = 7;
            button1.Text = "Aceptar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // HTMonitorFrmCopy
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(511, 310);
            ControlBox = false;
            Controls.Add(button1);
            Controls.Add(label5);
            Controls.Add(panel1);
            Controls.Add(pictureBox1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "HTMonitorFrmCopy";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Acerca de TYS-WIM-REPORT";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private PictureBox pictureBox1;
        private Panel panel1;
        private Label label5;
        private Button button1;
    }
}