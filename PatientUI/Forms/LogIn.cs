using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatientUI.Forms
{
    public partial class LogIn : Form
    {
        public string User { get; set; }
        public string Password { get; set; }
        public LogIn()
        {
            InitializeComponent();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            this.User = textBoxLogin.Text;
            this.Password = textBoxPassword.Text;
            this.Close();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearTextBox();
        }

        private void ClearTextBox()
        {
            textBoxLogin.Text = textBoxPassword.Text = string.Empty;
        }

        private void textBoxLogin_Enter(object sender, EventArgs e)
        {
            textBoxLogin.BackColor = textBoxPassword.BackColor = SystemColors.Window;
        }
    }
}
