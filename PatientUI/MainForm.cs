using PatientUI.Forms;
using SOPB.BAL.Repository;
using SOPB.BAL.CustomerService;
using System;
using System.Windows.Forms;
using SOPB.DAL.LoadData;
using System.Collections.Generic;
using System.Diagnostics;

namespace PatientUI
{
    public partial class MainForm : Form
    {
        void UICulture()
        {
            //System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo("en-US");
            //System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo("en-US");
        }

        private IRepository _repository;
        public MainForm(IRepository repository)
        {
            //UICulture();
            //();
            InitializeComponent();
            Initialize();
            SetDataGridView();
            if (repository == null)
            {
                throw new ArgumentNullException("MainForm ctor repository");
            }
            _repository = repository;
            

        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            while (true)
            {
                LogIn login = new LogIn();
                DialogResult result = login.ShowDialog();
                if (result == DialogResult.Cancel)
                {
                    this.Close();
                    return;
                }

                try
                {
                    var service = new CustomerSrevice(_repository);
                    service.Account(login.User, login.Password);
                    if (!isLoadData)
                    {
                        this.BindingData(service.GetDictionary());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    continue;
                }
                break;
            }
        }

        private void toolStripButtonLoad_Click(object sender, EventArgs e)
        {
            LoadUpdateCustomers();
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            _customerBindingSource.MoveLast();
            _customerBindingSource.EndEdit();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            UpdateCustomers();
        }

        private void UpdateCustomers()
        {
            try
            {
                var service = new CustomerSrevice(_repository);
                //if (isLoadData)
                //{
                _customerBindingSource.EndEdit();
                _addressBindingSource.EndEdit();
                _registerBindingSource.EndEdit();
                _invalidBindingSource.EndEdit();
                _invalidBenefitsBindingSource.EndEdit();
                service.Update();
            }
            catch (Exception exception)
            {
                //Logger logger = LogManager.GetCurrentClassLogger();
                //logger.Warn(exception.Message);
                MessageBox.Show(exception.Message);
                MessageBox.Show("Произошла ошибка. Приложение будет закрыто.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
        }
        private void LoadUpdateCustomers()
        {
            try
            {
                var service = new CustomerSrevice(_repository);
                //if (isLoadData)
                //{
                    _customerBindingSource.EndEdit();
                    _addressBindingSource.EndEdit();
                    _registerBindingSource.EndEdit();
                    _invalidBindingSource.EndEdit();
                    _invalidBenefitsBindingSource.EndEdit();
                    service.Update();
                //}
                var customersData = service.GetCustomers();
                if (customersData != null)
                {
                    BindingData(customersData);
                }
            }
            catch (Exception exception)
            {
                //Logger logger = LogManager.GetCurrentClassLogger();
                //logger.Warn(exception.Message);
                MessageBox.Show(exception.Message);
                MessageBox.Show("Произошла ошибка. Приложение будет закрыто.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
        }

        private void Cusrtomer_Validated(object sender, EventArgs e)
        {
            if (isLoadData)
            {
                if (_customerBindingSource.Current == null)
                {
                    string customerText = ((Control)sender).Text;
                    _customerBindingSource.AddNew();
                    ((Control)sender).Text = customerText;
                }
                _customerBindingSource.EndEdit();
                var service = new CustomerSrevice(_repository);
               // service.Update();
            }
        }
        private void Registred_Validated(object sender, EventArgs e)
        {
            if (isLoadData || _customerBindingSource.Count >= 1)
            {
                if (_registerBindingSource.Current == null)
                {
                    string registerText = ((Control)sender).Text;
                    _registerBindingSource.AddNew();
                    ((Control)sender).Text = registerText;
                }
                _registerBindingSource.EndEdit();
                //CustomRepository<string> repo = new CustomRepository<string>();
                //repo.Update(null);
            }
        }
        private void Address_Validated(object sender, EventArgs e)
        {
            if (isLoadData || _customerBindingSource.Count >= 1)
            {
                if (_addressBindingSource.Current == null)
                {
                    string registerText = ((Control)sender).Text;
                    _addressBindingSource.AddNew();
                    ((Control)sender).Text = registerText;
                }
                _addressBindingSource.EndEdit();
            }
        }
        private void Invalid_Validated(object sender, EventArgs e)
        {
            if (isLoadData || _customerBindingSource.Count >= 1)
            {
                if (_invalidBindingSource.Current == null)
                {
                    string invalidText = ((Control)sender).Text;
                    _invalidBindingSource.AddNew();
                    ((Control)sender).Text = invalidText;
                }
                _invalidBindingSource.EndEdit();
            }
        }
        private void boundChkBoxBenefits_Validated(object sender, EventArgs e)
        {
            if (isLoadData)
            {
                if (_invalidBindingSource.Current == null)
                {
                    List<int> checkedList = new List<int>(boundChkBoxBenef.Items.Count);
                    for (int i = 0; i < boundChkBoxBenef.Items.Count; i++)
                    {
                        if (boundChkBoxBenef.GetItemChecked(i))
                        {
                            checkedList.Add(i);
                        }
                    }
                    _invalidBindingSource.AddNew();
                    _invalidBindingSource.EndEdit();
                    for (int i = 0; i < checkedList.Count; i++)
                    {
                        boundChkBoxBenef.SetItemChecked(checkedList[i], true);
                    }

                }
                _invalidBindingSource.EndEdit();
                var service = new CustomerSrevice(_repository);
                service.Update();
            }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _customerBindingSource.CancelEdit();
            _registerBindingSource.CancelEdit();
            _addressBindingSource.CancelEdit();
            _invalidBindingSource.CancelEdit();
        }

        private void ToolStripMenuItemLastName_Click(object sender, EventArgs e)
        {
            try
            {
                FindByFName find = new FindByFName();
                if (find.ShowDialog() == DialogResult.OK)
                {
                    string lName = find.LastName;
                    string fname = find.FirstName;
                    var service = new CustomerSrevice(_repository);
                    if (isLoadData)
                    {
                        service.FindBy("LastName", lName);
                    }
                   else BindingData(service.FindBy("LastName", lName));
                }
            }
            catch (Exception exception)
            {
                //Logger logger = LogManager.GetCurrentClassLogger();
                //logger.Warn(exception.Message);
                MessageBox.Show("Произошла ошибка. Приложение будет закрыто.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
        }

        private void ToolStripMenuItemAddress_Click(object sender, EventArgs e)
        {
            try
            {
                FindByAddress find = new FindByAddress();
                if (find.ShowDialog() == DialogResult.OK)
                {
                    string street = find.Street;
                    string city = find.City;

                    var service = new CustomerSrevice(_repository);
                    if (isLoadData)
                    {
                        service.FindBy("Address", city, street);
                    }
                    else BindingData(service.FindBy("Address", city, street));
                }
            }
            catch (Exception exception)
            {
                //Logger logger = LogManager.GetCurrentClassLogger();
                //logger.Warn(exception.Message);
                MessageBox.Show("Произошла ошибка. Приложение будет закрыто.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
        }
        private void ToolStripMenuItemBOD_Click(object sender, EventArgs e)
        {
            try
            {
                FindByBOD findByBirthday = new FindByBOD();
                if (findByBirthday.ShowDialog() == DialogResult.OK)
                {
                    CustomerSrevice customer = new CustomerSrevice(_repository);

                    if (isLoadData) customer.FindBy("Birthday", findByBirthday.BithDay, findByBirthday.BirthOfDayEnd, findByBirthday.Predicate);
                    else
                    {
                        BindingData(customer.FindBy("Birthday", findByBirthday.BithDay, findByBirthday.BirthOfDayEnd, findByBirthday.Predicate));
                    }

                }
            }
            catch (Exception exception)
            {
                //Logger logger = LogManager.GetCurrentClassLogger();
                //logger.Warn(exception.Message);
                MessageBox.Show("Произошла ошибка. Приложение будет закрыто.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
        }

        private void FromRegToArch(object sender, EventArgs e)
        {
            string message = string.Format("Перевести {0} пациентов в архив?", _customerBindingSource.Count);
            if (MessageBox.Show(message, @"Перевод в архивную группу", MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question) == DialogResult.OK)
            {
                CustomerSrevice customer = new CustomerSrevice(_repository);
                customer.FromRegToArch();
                customer.Update();
            }
        }

        private void customizeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void landToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_genderBindingSource == null || (_genderBindingSource.Current == null || _genderBindingSource.Count <= 0))
            {

                var service = new CustomerSrevice(_repository);
                var customerData = service.GetCustomers();
                BindingData(customerData);
            }
            string glossary = ((ToolStripMenuItem)sender).Tag.ToString();
            string nameColumn = ((ToolStripMenuItem)sender).Text;
#if DEBUG
            Debug.WriteLine(glossary);
#endif
            DialogResult result = DialogResult.No;
            var bindingSource = GetSource(glossary);
            //if (string.Equals(glossary, "regType"))
            //{
                GlossaryForm glossaryForm = new GlossaryForm(_repository, nameColumn, bindingSource, new string[] { nameColumn, "Описание" });
                result = glossaryForm.ShowDialog();
            //}
            //else if (string.Equals(glossary, "Disability"))
            //{
            //    GlossaryForm glossaryForm = new GlossaryForm(_repository, "Группа инвалидности", _disabilityBindingSource, new string[] { "Группа Ивалидностим", "Описание" });
            //    result = glossaryForm.ShowDialog();
            //}
            //else if (string.Equals(glossary, "apppTpr"))
            //{
            //    GlossaryForm glossaryForm = new GlossaryForm(_repository, "АППП/ТПР", _apppTprBindingSource, new string[] { "Имя" });
            //    result = glossaryForm.ShowDialog();
            //}
            //else if (string.Equals(glossary, "Benefits"))
            //{
            //    GlossaryForm glossaryForm = new GlossaryForm(_repository, "Льготы", _benefitsBindingSource, new string[] { "Льгота", "Описание" });
            //    result = glossaryForm.ShowDialog();
            //}
            //else if (string.Equals(glossary, "chiperRecept"))
            //{
            //    GlossaryForm glossaryForm = new GlossaryForm(_repository, "Шифр рецепта", _chiperBindingSource, new string[] { "Шифр рецепта", "Описание" });
            //    result = glossaryForm.ShowDialog();
            //}
            //else if (string.Equals(glossary, "Land"))
            //{
            //    GlossaryForm glossaryForm = new GlossaryForm(_repository, "Участок", _landBindingSource, new string[] { "Участок" });
            //    result = glossaryForm.ShowDialog();
            //}
            //else if (string.Equals(glossary, "whyDeReg"))
            //{
            //    GlossaryForm glossaryForm = new GlossaryForm(_repository, "Причина снятия с учета", _whyDeRegisterBindingSource, new string[] { "Причина снятия с учёта", "Описание" });
            //    result = glossaryForm.ShowDialog();
            //}

            if (result == DialogResult.Abort)
            {
                MessageBox.Show("Произошла ошибка. Приложение будет закрыто.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
        }
    }
}
