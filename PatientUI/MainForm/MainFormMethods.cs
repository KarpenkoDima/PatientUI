using PatientUI.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatientUI
{
    partial class MainForm
    {
        private BindingSource _customerBindingSource;
        private BindingSource _genderBindingSource;
        private BindingSource _apppTprBindingSource;
        private BindingSource _errorBindingSource;
        private BindingSource _adminDivisionBindingSource;
        private BindingSource _typeStreetBindingSource;
        private BindingSource _addressBindingSource;

        private BindingSource _registerBindingSource;
        private BindingSource _registerTypeBindingSource;
        private BindingSource _secondRegisterTypeBindingSource;
        private BindingSource _whySecondDeRegisterBindingSource;
        private BindingSource _whyDeRegisterBindingSource;
        private BindingSource _landBindingSource;

        private BindingSource _invalidBindingSource;
        private BindingSource _benefitsBindingSource;
        private BindingSource _disabilityBindingSource;
        private BindingSource _chiperBindingSource;
        private BindingSource _invalidBenefitsBindingSource;

        private bool isLoadData = false;
        private void Initialize()
        {
            _customerBindingSource = new BindingSource();
            _apppTprBindingSource = new BindingSource();
            _genderBindingSource = new BindingSource();
            _errorBindingSource = new BindingSource();

            _adminDivisionBindingSource = new BindingSource();
            _typeStreetBindingSource = new BindingSource();
            _addressBindingSource = new BindingSource();

            _registerBindingSource = new BindingSource();
            _registerTypeBindingSource = new BindingSource();
            _secondRegisterTypeBindingSource = new BindingSource();
            _whySecondDeRegisterBindingSource = new BindingSource();
            _whyDeRegisterBindingSource = new BindingSource();
            _landBindingSource = new BindingSource();

            _invalidBindingSource = new BindingSource();
            _benefitsBindingSource = new BindingSource();
            _disabilityBindingSource = new BindingSource();
            _chiperBindingSource = new BindingSource();
            _invalidBenefitsBindingSource = new BindingSource();
            MainBindingNavigator.BindingSource = _customerBindingSource;

            bindingNavigatorAddNewItem.Enabled = false;
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

        private void BindingData(object data)
        {
            _apppTprBindingSource.DataSource = data;
            _apppTprBindingSource.DataMember = "ApppTpr";

            _genderBindingSource.DataSource = data;
            _genderBindingSource.DataMember = "Gender";

            _customerBindingSource.DataSource = data;
            _customerBindingSource.DataMember = "Customer";

            textBoxLastName.DataBindings.Clear();
            textBoxFirstName.DataBindings.Clear();
            textBoxMiddleName.DataBindings.Clear();
            maskedTextBoxBOD.DataBindings.Clear();
            textBoxMedCode.DataBindings.Clear();
            textBoxMedCard.DataBindings.Clear();
            textBoxError.DataBindings.Clear();
            textBoxCustomerNotaBene.DataBindings.Clear();

            textBoxLastName.DataBindings.Add("Text", _customerBindingSource, "LastName");
            textBoxFirstName.DataBindings.Add("Text", _customerBindingSource, "FirstName");
            textBoxMiddleName.DataBindings.Add("Text", _customerBindingSource, "MiddleName");
            maskedTextBoxBOD.DataBindings.Add("Text", _customerBindingSource, "Birthday");
            textBoxMedCode.DataBindings.Add("Text", _customerBindingSource, "CodeCustomer");
            textBoxMedCard.DataBindings.Add("Text", _customerBindingSource, "MedCard");
            textBoxCustomerNotaBene.DataBindings.Add("Text", _customerBindingSource, "NotaBene");

            _errorBindingSource.DataSource = _customerBindingSource;
            _errorBindingSource.DataMember = "FK_Error_Customer_CustomerID";

            textBoxError.DataBindings.Add("Text", _errorBindingSource, "Error");

            comboBoxApppTpr.DataSource = _apppTprBindingSource;
            comboBoxApppTpr.ValueMember = "APPPTPRID";
            comboBoxApppTpr.DataBindings.Clear();
            comboBoxApppTpr.DataBindings.Add("SelectedValue", _customerBindingSource, "APPPTPRID");
            comboBoxApppTpr.DisplayMember = "Name";

            comboBoxGender.DataSource = _genderBindingSource;
            comboBoxGender.ValueMember = "GenderID";
            comboBoxGender.DataBindings.Clear();
            comboBoxGender.DataBindings.Add("SelectedValue", _customerBindingSource, "GenderID");
            comboBoxGender.DisplayMember = "Name";

            checkBoxArch.DataBindings.Clear();
            checkBoxArch.DataBindings.Add("Checked", _customerBindingSource, "Arch");
            //////////////////////////////////////////////////////////////////////////////////
            /// 
            _adminDivisionBindingSource.DataSource = data;
            _adminDivisionBindingSource.DataMember = "AdminDivision";
            _typeStreetBindingSource.DataSource = data;
            _typeStreetBindingSource.DataMember = "TypeStreet";

            _addressBindingSource.DataSource = _customerBindingSource;
            _addressBindingSource.DataMember = "FK_Address_Customer_CustomerID";

            textBoxStreet.DataBindings.Clear();
            textBoxStreet.DataBindings.Add("Text", _addressBindingSource, "NameStreet");
            textBoxNumberApartment.DataBindings.Clear();
            textBoxNumberApartment.DataBindings.Add("Text", _addressBindingSource, "NumberApartment");
            textBoxNumberHouse.DataBindings.Clear();
            textBoxNumberHouse.DataBindings.Add("Text", _addressBindingSource, "NumberHouse");
            textBoxCity.DataBindings.Clear();
            textBoxCity.DataBindings.Add("Text", _addressBindingSource, "City");
            _addressBindingSource.AddingNew += AddressBindingSourceOnAddingNew;
            //////////////////////////////////////////////////////////////////////////////////////////
            /// Binding data to Register contrls
            _registerTypeBindingSource.DataSource = data;
            _registerTypeBindingSource.DataMember = "RegisterType";

            _secondRegisterTypeBindingSource.DataSource = data;
            _secondRegisterTypeBindingSource.DataMember = "RegisterType";

            _whySecondDeRegisterBindingSource.DataSource = data;
            _whySecondDeRegisterBindingSource.DataMember = "WhyDeRegister";

            _whyDeRegisterBindingSource.DataSource = data;
            _whyDeRegisterBindingSource.DataMember = "WhyDeRegister";

            _landBindingSource.DataSource = data;
            _landBindingSource.DataMember = "Land";

            _registerBindingSource.DataSource = _customerBindingSource;
            _registerBindingSource.DataMember = "FK_Register_Customer_CustomerID";

            maskedTextBoxFirstRegister.DataBindings.Clear();
            maskedTextBoxFirstRegister.DataBindings.Add("Text", _registerBindingSource, "FirstRegister");
            maskedTextBoxFirstDeRegister.DataBindings.Clear();
            maskedTextBoxFirstDeRegister.DataBindings.Add("Text", _registerBindingSource, "FirstDeRegister");
            maskedTextBoxSecondRegister.DataBindings.Clear();
            maskedTextBoxSecondRegister.DataBindings.Add("Text", _registerBindingSource, "SecondRegister");
            maskedTextBoxSecondDeRegister.DataBindings.Clear();
            maskedTextBoxSecondDeRegister.DataBindings.Add("Text", _registerBindingSource, "SecondDeRegister");
            textBoxDiagnosis.DataBindings.Clear();
            textBoxDiagnosis.DataBindings.Add("Text", _registerBindingSource, "Diagnosis");
            textBoxRegisterNotaBene.DataBindings.Clear();
            textBoxRegisterNotaBene.DataBindings.Add("Text", _registerBindingSource, "NotaBene");

            comboBoxFirstRegisterType.DataSource = _registerTypeBindingSource;
            comboBoxFirstRegisterType.ValueMember = "RegisterTypeID";
            comboBoxFirstRegisterType.DataBindings.Clear();
            comboBoxFirstRegisterType.DataBindings.Add("SelectedValue", _registerBindingSource, "RegisterTypeID");
            comboBoxFirstRegisterType.DisplayMember = "Name";

            comboBoxSecondRegisterType.DataSource = _secondRegisterTypeBindingSource;
            comboBoxSecondRegisterType.ValueMember = "RegisterTypeID";
            comboBoxSecondRegisterType.DataBindings.Clear();
            comboBoxSecondRegisterType.DataBindings.Add("SelectedValue", _registerBindingSource, "SecondRegisterTypeID");
            comboBoxSecondRegisterType.DisplayMember = "Name";

            comboBoxFirstDeRegisterType.DataSource = _whyDeRegisterBindingSource;
            comboBoxFirstDeRegisterType.ValueMember = "WhyDeREgisterID";
            comboBoxFirstDeRegisterType.DataBindings.Clear();
            comboBoxFirstDeRegisterType.DataBindings.Add("SelectedValue", _registerBindingSource, "WhyDeRegisterID");
            comboBoxFirstDeRegisterType.DisplayMember = "Name";

            comboBoxSecondDeRegisterType.DataSource = _whySecondDeRegisterBindingSource;
            comboBoxSecondDeRegisterType.ValueMember = "WhyDeRegisterID";
            comboBoxSecondDeRegisterType.DataBindings.Clear();
            comboBoxSecondDeRegisterType.DataBindings.Add("SelectedValue", _registerBindingSource,
                "WhySecondDeRegisterID");
            comboBoxSecondDeRegisterType.DisplayMember = "Name";

            comboBoxLand.DataSource = _landBindingSource;
            comboBoxLand.ValueMember = "LandID";
            comboBoxLand.DataBindings.Clear();
            comboBoxLand.DataBindings.Add("SelectedValue", _registerBindingSource, "LandID");
            comboBoxLand.DisplayMember = "Name";
            _registerBindingSource.AddingNew += RegisterBindingSourceOnAddingNew;
            ///////////////////////////////////////////////////////////////////////////////////////////////////
            //// Binding data to Invalid contrls  ////
            _benefitsBindingSource.DataSource = data;
            _benefitsBindingSource.DataMember = "BenefitsCategory";

            _disabilityBindingSource.DataSource = data;
            _disabilityBindingSource.DataMember = "DisabilityGroup";

            _chiperBindingSource.DataSource = data;
            _chiperBindingSource.DataMember = "ChiperRecept";

            _invalidBindingSource.DataSource = _customerBindingSource;
            _invalidBindingSource.DataMember = "FK_Invalid_Customer_CustomerID";

            _invalidBenefitsBindingSource.DataSource = data;
            _invalidBenefitsBindingSource.DataMember = "InvalidBenefitsCategory";
            comboBoxDisabilityGroup.DataSource = _disabilityBindingSource;
            comboBoxDisabilityGroup.ValueMember = "DisabilityGroupID";
            comboBoxDisabilityGroup.DataBindings.Clear();
            comboBoxDisabilityGroup.DataBindings.Add("SelectedValue", _invalidBindingSource, "DisabilityGroupID");
            comboBoxDisabilityGroup.DisplayMember = "Name";

            maskedTextBoxDateIncapable.DataBindings.Clear();
            maskedTextBoxDateIncapable.DataBindings.Add("Text", _invalidBindingSource, "DateIncapable");
            maskedTextBoxDateInvalid.DataBindings.Clear();
            maskedTextBoxDateInvalid.DataBindings.Add("Text", _invalidBindingSource, "DataInvalidity");
            maskedTextBoxPeriodInvalid.DataBindings.Clear();
            maskedTextBoxPeriodInvalid.DataBindings.Add("Text", _invalidBindingSource, "PeriodInvalidity");

            comboBoxCipherRecept.DataSource = _chiperBindingSource;
            comboBoxCipherRecept.ValueMember = "ChiperReceptID";
            comboBoxCipherRecept.DataBindings.Clear();
            comboBoxCipherRecept.DataBindings.Add("SelectedValue", _invalidBindingSource, "ChiperReceptID");
            comboBoxCipherRecept.DisplayMember = "Name";

            checkBoxInCapability.DataBindings.Clear();
            checkBoxInCapability.DataBindings.Add("Checked", _invalidBindingSource, "Incapable");

            boundChkBoxBenef.ChildDisplayMember = "Name";
            boundChkBoxBenef.ChildValueMember = "BenefitsID";
            boundChkBoxBenef.ParentValueMember = "InvID";
            boundChkBoxBenef.ParentIDMember = "InvalidID";
            boundChkBoxBenef.ChildIDMember = "BenefitsCategoryID";
            boundChkBoxBenef.ParentDataSource = _invalidBindingSource;
            boundChkBoxBenef.ChildDataSource = _benefitsBindingSource;
            boundChkBoxBenef.RelationDataSource = _invalidBenefitsBindingSource;

            boundChkBoxBenef.LostFocus += BoundChkBoxBenefitsOnLostFocus;

            _invalidBindingSource.AddingNew += InvalidBindingSourceOnAddingNew;

            _customerBindingSource.PositionChanged += CustomerBindingSourceOnPositionChanged;
                
            //    (sender, args) =>
            //{
            //    if (_invalidBindingSource.Current == null)
            //    {
            //        for (int i = 0; i < boundChkBoxBenef.Items.Count; i++)
            //        {
            //            boundChkBoxBenef.SetItemChecked(i, false);
            //        }
            //    }
            //};

            customerDataGridView.DataSource = _customerBindingSource;
            MainBindingNavigator.BindingSource = _customerBindingSource;
            bindingNavigatorAddNewItem.Enabled = true;
            if (_customerBindingSource.Count > 0)
                isLoadData = true;
            else isLoadData = false;
        }

        private void CustomerBindingSourceOnPositionChanged(object sender, EventArgs e)
        {
            {
                if (_invalidBindingSource.Current == null)
                {
                    for (int i = 0; i < boundChkBoxBenef.Items.Count; i++)
                    {
                        boundChkBoxBenef.SetItemChecked(i, false);
                    }
                }
            };
        }

        private void AddressBindingSourceOnAddingNew(object sender, AddingNewEventArgs e)
        {
            if (_addressBindingSource.List.Count >= 1) return;
            DataView view = _addressBindingSource.List as DataView;

            DataRowView row = view.AddNew();
            row["City"] = "Славянск";
            row["AdminDivisionID"] = 5;
            row["CustomerID"] = ((DataRowView)_customerBindingSource.Current)[0];
            e.NewObject = (object)row;
            _addressBindingSource.MoveLast();
        }

        private void RegisterBindingSourceOnAddingNew(object sender, AddingNewEventArgs e)
        {
            if (_registerBindingSource.List.Count >= 1) return;
            DataView view = _registerBindingSource.List as DataView;

            DataRowView row = view.AddNew();
            _landBindingSource.MoveFirst();
            row["LandID"] = ((DataRowView)_landBindingSource.Current)["LandID"];
            row["CustomerID"] = ((DataRowView)_customerBindingSource.Current)[0];
            e.NewObject = (object)row;
            _registerBindingSource.MoveLast();
        }
        private void InvalidBindingSourceOnAddingNew(object sender, AddingNewEventArgs e)
        {
            if (_invalidBindingSource.List.Count >= 1) return;
            DataView view = _invalidBindingSource.List as DataView;

            DataRowView row = view.AddNew();
            row["Incapable"] = 1;

            row["CustomerID"] = ((DataRowView)_customerBindingSource.Current)[0];
            e.NewObject = (object)row;
            _invalidBindingSource.MoveLast();
        }
        private void BoundChkBoxBenefitsOnLostFocus(object sender, EventArgs e)
        {
            if (isLoadData)
            {
                _invalidBindingSource.EndEdit();
                _benefitsBindingSource.EndEdit();
                _invalidBenefitsBindingSource.EndEdit();
            }
        }


        private void findByGlossary_Click(object sender, EventArgs e)
        {
            string name = ((ToolStripMenuItem)sender).Tag.ToString();
            FindByGlossary find = new FindByGlossary(GetSource(name), name);
            if (find.ShowDialog() == DialogResult.OK)
            {
                int id = find._ID;
                FilterByGlossary(name, id);
            }
        }
       protected void FilterByGlossary(string name, int id)
        {
            var service = new SOPB.BAL.CustomerService.CustomerSrevice(_repository);
            try
            {
                BindingData(service.FindByGlossary(name, id));
            }
            catch (Exception exception)
            {
                //Logger logger = LogManager.GetCurrentClassLogger();
                //logger.Warn(exception.Message);
                MessageBox.Show("Произошла ошибка. Приложение будет закрыто.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
        }
        private BindingSource GetSource(string name)
        {
            switch (name.ToUpper())
            {
                case "DISABILITYGROUP":
                    return _disabilityBindingSource;
                case "BENEFITSCATEGORY":
                    return _benefitsBindingSource;
                case "LAND":
                    return _landBindingSource;
                case "APPPTPR":
                    return _apppTprBindingSource;
                case "REGISTERTYPE":
                    return _registerTypeBindingSource;
                case "WHYDEREGISTER":
                    return _whyDeRegisterBindingSource;
                case "CHIPERRECEPT":
                    return _chiperBindingSource;
            }

            return _benefitsBindingSource;
        }
        private void ExportToExcel(object sender, EventArgs e)
        {
            throw new NotImplementedException("Not implementated");
        }

        private void printToolStripButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException("Not implementated");
        }
    }
}
