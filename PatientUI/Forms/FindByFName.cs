using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatientUI.Forms
{
    public class FindByFName :FindBy
    {
        public FindByFName():base("Поиск по ФИО")
        {
            base.label1.Text = "Фамилия";
            base.label2.Text = "Имя";
        }
        public string LastName
        {
            get
            {
                return textBoxOneField.Text;
            }
        }
        public string FirstName
        {
            get
            {
                return textBoxSecondField.Text;
            }
        }
        protected override void buttonOk_Click(object sender, EventArgs e)
        {
            base.buttonOk_Click(sender, e);
            if (string.IsNullOrEmpty(textBoxOneField.Text))
            {
                this.DialogResult = MessageBox.Show(@"Вы не ввели текст для поиска! Повторить ввод?", @"Пустая Строка", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                ClearTextBox();
                if (this.DialogResult == DialogResult.No)
                {
                    this.Close();
                }
                return;
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
