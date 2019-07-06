namespace PatientUI.Forms
{
    partial class FindBy
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
            this.FindGroupBox = new System.Windows.Forms.GroupBox();
            this.textBoxOneField = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxSecondField = new System.Windows.Forms.TextBox();
            this.buttonOk = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.FindGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // FindGroupBox
            // 
            this.FindGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FindGroupBox.Controls.Add(this.textBoxOneField);
            this.FindGroupBox.Controls.Add(this.label1);
            this.FindGroupBox.Controls.Add(this.textBoxSecondField);
            this.FindGroupBox.Controls.Add(this.buttonOk);
            this.FindGroupBox.Controls.Add(this.label2);
            this.FindGroupBox.Controls.Add(this.buttonCancel);
            this.FindGroupBox.Location = new System.Drawing.Point(12, 12);
            this.FindGroupBox.Name = "FindGroupBox";
            this.FindGroupBox.Size = new System.Drawing.Size(254, 109);
            this.FindGroupBox.TabIndex = 5;
            this.FindGroupBox.TabStop = false;
            this.FindGroupBox.Text = "Критерий поиска";
            // 
            // textBoxOneField
            // 
            this.textBoxOneField.Location = new System.Drawing.Point(90, 36);
            this.textBoxOneField.Name = "textBoxOneField";
            this.textBoxOneField.Size = new System.Drawing.Size(158, 20);
            this.textBoxOneField.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Field#1";
            // 
            // textBoxSecondField
            // 
            this.textBoxSecondField.Location = new System.Drawing.Point(90, 77);
            this.textBoxSecondField.Name = "textBoxSecondField";
            this.textBoxSecondField.Size = new System.Drawing.Size(158, 20);
            this.textBoxSecondField.TabIndex = 1;
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.Location = new System.Drawing.Point(6, 80);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 2;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Field#2";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.AutoEllipsis = true;
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(173, 80);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // FindBy
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(278, 179);
            this.ControlBox = false;
            this.Controls.Add(this.FindGroupBox);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(294, 218);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(294, 218);
            this.Name = "FindBy";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FindByBOD";
            this.FindGroupBox.ResumeLayout(false);
            this.FindGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox FindGroupBox;
        private System.Windows.Forms.Button buttonOk;
        protected System.Windows.Forms.TextBox textBoxOneField;
        protected System.Windows.Forms.Label label1;
        protected System.Windows.Forms.TextBox textBoxSecondField;
        protected System.Windows.Forms.Label label2;
        protected System.Windows.Forms.Button buttonCancel;
    }
}