namespace TestPatientGUI.UCotrols
{
    partial class RegisterType
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelFirstSecondReg = new System.Windows.Forms.Label();
            this.labelWhyReg = new System.Windows.Forms.Label();
            this.maskedTextBoxRegister = new System.Windows.Forms.MaskedTextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.comboBoxRegisterType = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelFirstSecondReg
            // 
            this.labelFirstSecondReg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelFirstSecondReg.AutoSize = true;
            this.labelFirstSecondReg.Location = new System.Drawing.Point(3, 9);
            this.labelFirstSecondReg.Name = "labelFirstSecondReg";
            this.labelFirstSecondReg.Size = new System.Drawing.Size(134, 13);
            this.labelFirstSecondReg.TabIndex = 0;
            this.labelFirstSecondReg.Text = "First/SecondReg";
            // 
            // labelWhyReg
            // 
            this.labelWhyReg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelWhyReg.AutoSize = true;
            this.labelWhyReg.Location = new System.Drawing.Point(263, 3);
            this.labelWhyReg.Name = "labelWhyReg";
            this.labelWhyReg.Size = new System.Drawing.Size(67, 26);
            this.labelWhyReg.TabIndex = 1;
            this.labelWhyReg.Text = "FirstSecondDeReg";
            // 
            // maskedTextBoxRegister
            // 
            this.maskedTextBoxRegister.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.maskedTextBoxRegister.Location = new System.Drawing.Point(143, 6);
            this.maskedTextBoxRegister.Mask = "00/00/0000";
            this.maskedTextBoxRegister.Name = "maskedTextBoxRegister";
            this.maskedTextBoxRegister.Size = new System.Drawing.Size(114, 20);
            this.maskedTextBoxRegister.TabIndex = 3;
            this.maskedTextBoxRegister.ValidatingType = typeof(System.DateTime);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.46067F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.96629F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.4045F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.maskedTextBoxRegister, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelWhyReg, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelFirstSecondReg, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxRegisterType, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.MaximumSize = new System.Drawing.Size(445, 32);
            this.tableLayoutPanel1.MinimumSize = new System.Drawing.Size(0, 28);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(445, 32);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // comboBoxRegisterType
            // 
            this.comboBoxRegisterType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxRegisterType.FormattingEnabled = true;
            this.comboBoxRegisterType.Location = new System.Drawing.Point(336, 5);
            this.comboBoxRegisterType.Name = "comboBoxRegisterType";
            this.comboBoxRegisterType.Size = new System.Drawing.Size(106, 21);
            this.comboBoxRegisterType.TabIndex = 4;
            // 
            // RegisterType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "RegisterType";
            this.Size = new System.Drawing.Size(448, 32);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        internal System.Windows.Forms.MaskedTextBox maskedTextBoxRegister;
        internal System.Windows.Forms.Label labelFirstSecondReg;
        internal System.Windows.Forms.Label labelWhyReg;
        internal System.Windows.Forms.ComboBox comboBoxRegisterType;
    }
}
