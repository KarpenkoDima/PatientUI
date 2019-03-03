using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SOPB.BAL.CustomerService;
using SOPB.BAL.Repository;

namespace PatientUI.Forms
{
    public partial class GlossaryForm : Form
    {
        private readonly BindingSource _bindingGlossary;
        private IRepository _repository;

        public GlossaryForm(IRepository repository, string nameGlossary, BindingSource bindingGlossary, string[] columnName)
        {
            _repository = repository;
            InitializeComponent();
            _bindingGlossary = new BindingSource(bindingGlossary.DataSource, bindingGlossary.DataMember);
            this.Text += @" " + nameGlossary;
            glossasryDataGridView.DataSource = _bindingGlossary;
            _bindingGlossary.ListChanged += BindingGlossary_DataSourceChanged;
            glossasryDataGridView.ColumnAdded += GlossasryDataGridView_ColumnAdded;
            glossasryDataGridView.Columns[0].Visible = false;
            
            for (int i = 0; i < columnName.Length; i++)
            {
                glossasryDataGridView.Columns[i + 1].HeaderText = columnName[i];
            }

            bindingNavigator1.BindingSource = _bindingGlossary;
        }

        private void GlossasryDataGridView_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
#if DEBUG
            Debug.WriteLine("Changed Add column {0}", glossasryDataGridView.ColumnCount);
#endif
        }

        private void BindingGlossary_DataSourceChanged(object sender, EventArgs e)
        {
#if DEBUG
            Debug.WriteLine("Changed DataSource {0}", glossasryDataGridView.ColumnCount);
#endif
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            _bindingGlossary.EndEdit();
            try
            {
                var service = new CustomerSrevice(_repository);
                service.Update();
                MessageBox.Show(glossasryDataGridView.ColumnCount.ToString());
                this.Close();
            }
            catch (Exception exception)
            {
                //Logger logger = LogManager.GetCurrentClassLogger();
                //logger.Warn(exception.Message);
                MessageBox.Show("Произошла ошибка. Приложение будет закрыто.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.Abort;
                this.Close();
            }
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                _bindingGlossary.EndEdit();
                var service = new CustomerSrevice(_repository);
                service.Update();
            }
            catch (Exception exception)
            {
#if DEBUG
                MessageBox.Show(exception.Message);
#endif
                //Logger logger = LogManager.GetCurrentClassLogger();
                //logger.Warn(exception.Message);
                MessageBox.Show("Произошла ошибка. Приложение будет закрыто.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.Abort;
                this.Close();
            }
        }
    }
}
