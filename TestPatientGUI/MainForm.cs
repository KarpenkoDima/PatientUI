using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SOPB.BAL.Repository;

namespace TestPatientGUI
{
    public partial class MainForm : Form
    {
        private IRepository _repository;
        public MainForm(IRepository repository)
        {
            InitializeComponent();
            Init();

            InitializeComponent();
          //  Initialize();
            SetDataGridView();
            if (repository == null)
            {
                throw new ArgumentNullException("MainForm ctor repository");
            }
            _repository = repository;
        }

        private void SetDataGridView()
        {
            customerDataGridView.Columns.Clear();
            DataGridViewTextBoxColumn idColumn =
                new DataGridViewTextBoxColumn();
            idColumn.Name = "№ п/п";
            idColumn.DataPropertyName = "CustomerID";
            idColumn.ReadOnly = true;
            customerDataGridView.Columns.Add(idColumn);

            idColumn =
                new DataGridViewTextBoxColumn();
            idColumn.Name = "Фамилия";
            idColumn.DataPropertyName = "LastName";
            idColumn.ReadOnly = true;
            customerDataGridView.Columns.Add(idColumn);

            idColumn =
                new DataGridViewTextBoxColumn();
            idColumn.Name = "Имя";
            idColumn.DataPropertyName = "FirstName";
            idColumn.ReadOnly = true;
            customerDataGridView.Columns.Add(idColumn);

            idColumn = new DataGridViewTextBoxColumn();
            idColumn.Name = "Отчество";
            idColumn.DataPropertyName = "MiddleName";
            idColumn.ReadOnly = true;
            customerDataGridView.Columns.Add(idColumn);

            customerDataGridView.ReadOnly = true;
            customerDataGridView.AutoGenerateColumns = false;
            customerDataGridView.AllowUserToAddRows = customerDataGridView.AllowUserToDeleteRows = false;
        }


        protected void Init()
        {

            registerFisrt.maskedTextBoxRegister.TabIndex = 15;
            registerFisrt.comboBoxRegisterType.TabIndex = 16;
            deregisterFirst.maskedTextBoxRegister.TabIndex = 17;
            deregisterFirst.comboBoxRegisterType.TabIndex = 18;
            registerSecond.maskedTextBoxRegister.TabIndex = 19;
            registerSecond.comboBoxRegisterType.TabIndex = 20;
            deregisterSecond.maskedTextBoxRegister.TabIndex = 21;
            deregisterSecond.comboBoxRegisterType.TabIndex = 22;

            registerFisrt.labelFirstSecondReg.Text = @"1-й раз взят на учёт";
            registerFisrt.labelWhyReg.Text = @"в связи";
            deregisterFirst.labelFirstSecondReg.Text = @"1-й раз снят с учёт";
            deregisterFirst.labelWhyReg.Text = @"причина";
            registerSecond.labelFirstSecondReg.Text = @"Ещё раз взят на учёт";
            registerSecond.labelWhyReg.Text = @"в связи";
            deregisterSecond.labelFirstSecondReg.Text = @"2-й раз снят с учета";
            deregisterSecond.labelWhyReg.Text = @"причина";
        }
    }
}
