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
    public partial class FindBy : Form
    {
        public FindBy(string caption)
        {
            InitializeComponent();
            this.Text = caption;
        }

        protected virtual void buttonOk_Click(object sender, EventArgs e)
        {

        }
    }
}
