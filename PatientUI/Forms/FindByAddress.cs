using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatientUI.Forms
{
    public class FindByAddress:FindBy
    {
        public FindByAddress():base("Поиск по адресу")
        {
            base.label1.Text = "Город";
            base.label2.Text = "Улица";
            base.textBoxOneField.Focus();
        }
        public string City
        {
            get
            {
                return textBoxOneField.Text;
            }
        }
        public string Street
        {
            get
            {
                return textBoxSecondField.Text;
            }
        }
        protected override void buttonOk_Click(object sender, EventArgs e)
        {
            base.buttonOk_Click(sender, e);
            if (string.IsNullOrEmpty(textBoxSecondField.Text))
            {
                this.DialogResult = MessageBox.Show(@"Вы не ввели текст для поиска! Повторить ввод?", @"Пустая Строка", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                ClearTextBox();
                if (this.DialogResult == DialogResult.No)
                {                  
                    this.Close();
                }

            }
            else
            {                
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        private void ClearTextBox()
        {
            textBoxOneField.Clear();
            textBoxSecondField.Clear();
        }

    }
}
