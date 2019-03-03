using SOPB.BAL.Repository;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PatientUI
{
    static class Program
    {
        static string UICulture()
        {
            var dbDatabaseName = ConfigurationManager.AppSettings["DatabaseName"];
            var dbServerName = ConfigurationManager.AppSettings["ServerName"];
            var dbProviderName = ConfigurationManager.AppSettings["ProviderName"];
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = dbServerName;
            builder.InitialCatalog = dbDatabaseName;
            builder.MultipleActiveResultSets = true;
            return builder.ToString();
        }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DialogResult result = MessageBox.Show("Test","", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);
            string repositoryType;
            if (result == DialogResult.Yes)
            {
                repositoryType = "RepositoryType";
            }
            else if (result == DialogResult.No) repositoryType = "ArchRepositoryType";
            else repositoryType = "";
            string repositoryTypeName =
               ConfigurationManager.AppSettings[repositoryType];
            var productRepositoryType =
                Type.GetType(repositoryTypeName, true);
            var repository =
                (IRepository)Activator.CreateInstance(
                productRepositoryType, UICulture());
            Application.Run(new MainForm(repository));
        }
    }
}
