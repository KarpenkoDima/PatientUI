using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace SOPB.DAL.ConnectionManager
{
    public static class ConnectionManager
    {
        private static string ConnectionString;
        private static SecureString SecureString = new SecureString();
        private static string User;
        private static SqlConnection Connection;

        public static void Account(string login, string password)
        {
            SecureString.Dispose();
            SecureString = null;
            SecureString = new SecureString();
            if (SecureString == null)
            {
                SecureString = new SecureString();
            }
            if (string.IsNullOrEmpty(password))
            {
                password = "";
            }
            foreach (char ch in password)
            {
                SecureString.AppendChar(ch);
            }
            SecureString.MakeReadOnly();
            User = login;
        }

        public static void SetConnection(string connectionString)
        {
            SqlCredential cred = new SqlCredential(User, SecureString);
            Connection = new SqlConnection();
            ConnectionString = Connection.ConnectionString = connectionString;
            Connection.Credential = cred;
            TestConnection();
        }

        public static SqlConnection GetConnection
        {
            get
            {
                SqlCredential cred = new SqlCredential(User, SecureString);
                Connection = new SqlConnection();
                Connection.ConnectionString = ConnectionString;
                Connection.Credential = cred;
                return Connection;
            }
        }

      

        private static bool TestConnection()
        {
            bool isOpen = false;
            try
            {
                
                using (SqlConnection connection = Connection)
                {
                    connection.Open();
                    isOpen = connection.State == ConnectionState.Open;
                    connection.Close();
                }
            }

            catch (SqlException)
            {
                throw;
            }

            return isOpen;
        }
    }
}
