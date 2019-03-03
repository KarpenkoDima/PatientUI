using SOPB.DAL.ARCH.LoadData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace SOPB.DAL.ARCH.AccessData
{
    internal class CustomerAccess
    {
        private  Tables _tables = new Tables();
        private  string whereClasure = String.Empty;
        private  IConvertible value;
        private  string dbType = String.Empty;
        private string _connectionString;

        public Dictionary<string, string> ParametersForUsp = new Dictionary<string, string>()
        { {Utilites.QueryCriteria.Bithday, "@BirthOfDay:;@BirthOfDayEnd:;@predicate:10"},
            {Utilites.QueryCriteria.Address, "@City:100;@NameStreet:100"},
            {Utilites.QueryCriteria.LastName, "@LastName:100"}
        };
        

        public CustomerAccess(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DbType DbTypeConversionKey(string fullName)
        {

            Dictionary<string, DbType> conversionKey = new Dictionary<string, DbType>
            { {"System.Int64", DbType.Int64},
                {"System.Byte[]",DbType.Binary},
                {"System.Boolean",DbType.Boolean},
                {"System.String",DbType.String},
                {"System.DateTime",DbType.DateTime},
                {"System.Decimal",DbType.Decimal},
                {"System.Double",DbType.Double},
                {"System.Int32", DbType.Int32},
                {"System.Int16", DbType.Int16},
                {"System.Byte", DbType.Byte},
                {"System.Guid", DbType.Guid},
                {"System.Object", DbType.Object},
                {"System.Single", DbType.Single},
                {"System.Char", DbType.AnsiStringFixedLength}};
            if (conversionKey.ContainsKey(fullName))
            {
                return conversionKey[fullName];
            }
            return DbType.Object;
        }

        internal void FilterByGlossary(string glossaryName, int id)
        {
            ClearData();
            TransactionWork transactionWork = null;
            string storageProcedureName = string.Format("uspGet{0}By{1}", "Customer", glossaryName);
            SqlParameter parameter = new SqlParameter();
            parameter.DbType = DbType.Int32;
            parameter.ParameterName = "@ID";
            parameter.Value = id;
            string storageProcedureNameReg = string.Format("uspGet{0}By{1}", "Register", glossaryName);
            SqlParameter parameterReg = new SqlParameter();
            parameterReg.DbType = DbType.Int32;
            parameterReg.ParameterName = "@ID";
            parameterReg.Value = id;
            string storageProcedureNameInv = string.Format("uspGet{0}By{1}", "Invalid", glossaryName);
            SqlParameter parameterInv = new SqlParameter();
            parameterInv.DbType = DbType.Int32;
            parameterInv.ParameterName = "@ID";
            parameterInv.Value = id;

            string storageProcedureNameInvBenefits = string.Format("uspGet{0}By{1}", "InvalidBenefits", glossaryName);
            SqlParameter parameterInvBenefits = new SqlParameter();
            parameterInvBenefits.DbType = DbType.Int32;
            parameterInvBenefits.ParameterName = "@ID";
            parameterInvBenefits.Value = id;

            string storageProcedureNameAddr = string.Format("uspGet{0}By{1}", "Address", glossaryName);
            SqlParameter parameterAddr = new SqlParameter();
            parameterAddr.DbType = DbType.Int32;
            parameterAddr.ParameterName = "@ID";
            parameterAddr.Value = id;
            try
            {
                using (transactionWork = (TransactionWork)TransactionFactory.Create())
                {
                    transactionWork.Execute(_tables.CustomerDataTable, storageProcedureName, parameter);
                    transactionWork.Execute(_tables.RegisterDataTable, storageProcedureNameReg, parameterReg);
                    transactionWork.Execute(_tables.InvalidDataTable, storageProcedureNameInv, parameterInv);
                    transactionWork.Execute(_tables.InvalidBenefitsDataTable, storageProcedureNameInvBenefits, parameterInvBenefits);
                    transactionWork.Execute(_tables.AddressDataTable, storageProcedureNameAddr, parameterAddr);
                    transactionWork.Commit();
                }
                WhereClasure(glossaryName, new object[] { id }, "=");
                //whereClasure = "where " + glossaryName + "ID = @param";
                //value = id;
                //dbType = "@param int";
            }
            catch (Exception)
            {
                transactionWork?.Rollback();
                throw;
            }
        }

        internal void Update()
        {
            TransactionWork transactionWork = null;
            try
            {
                using (transactionWork = (TransactionWork)TransactionFactory.Create())
                {
                    for (int i = 0; i < _tables.DispancerDataSet.Tables.Count; i++)
                    {
                        if (_tables.DispancerDataSet.Tables[i].TableName != _tables.ErrorDataTable.TableName)
                            transactionWork.UpdateData(_tables.DispancerDataSet.Tables[i]);
                    }
                    _tables.ErrorDataTable.Clear();
                    transactionWork.Commit();
                }
            }
            catch (Exception)
            {
                transactionWork?.Rollback();
                throw;
            }
        }

        internal void Upload()
        {
            _tables = new Tables();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        internal object GetData()
        {
            return _tables.DispancerDataSet;
        }
        public void FillDictionary()
        {
            ClearAll();
            TransactionWork transactionWork = null;
            try
            {
                using (transactionWork = (TransactionWork)TransactionFactory.Create())
                {
                    transactionWork.ReadData(_tables.DispancerDataSet.Tables["ApppTpr"]);
                    transactionWork.ReadData(_tables.DispancerDataSet.Tables["Gender"]);
                    transactionWork.ReadData(_tables.DispancerDataSet.Tables["AdminDivision"]);
                    transactionWork.ReadData(_tables.DispancerDataSet.Tables["TypeStreet"]);
                    transactionWork.ReadData(_tables.DispancerDataSet.Tables["ChiperRecept"]);
                    transactionWork.ReadData(_tables.DispancerDataSet.Tables["BenefitsCategory"]);
                    transactionWork.ReadData(_tables.DispancerDataSet.Tables["DisabilityGroup"]);
                    transactionWork.ReadData(_tables.DispancerDataSet.Tables["Land"]);
                    transactionWork.ReadData(_tables.DispancerDataSet.Tables["RegisterType"]);
                    transactionWork.ReadData(_tables.DispancerDataSet.Tables["WhyDeRegister"]);
                    transactionWork.Commit();
                }
            }
            catch (Exception  ex)
            {
                transactionWork?.Rollback();
                throw;
            }
        }

       

        public void FillCustomerData()
        {
            ClearData();
            TransactionWork transactionWork = null;
            try
            {
                using (transactionWork = (TransactionWork)TransactionFactory.Create())
                {
                    transactionWork.ReadData(_tables.DispancerDataSet.Tables["Customer"]);
                    transactionWork.ReadData(_tables.DispancerDataSet.Tables["Address"]);
                    transactionWork.ReadData(_tables.DispancerDataSet.Tables["Invalid"]);
                    transactionWork.ReadData(_tables.DispancerDataSet.Tables["InvalidBenefitsCategory"]);
                    transactionWork.ReadData(_tables.DispancerDataSet.Tables["Register"]);
                    transactionWork.Commit();
                }
                whereClasure = String.Empty;
                value = null;
                dbType = string.Empty;
            }
            catch (Exception)
            {
                transactionWork?.Rollback();
                throw;
            }
        }
        internal void GetDataByCriteria<T>(string criteria, T[] values) where T : IComparable<T>
        {
            
        }

        protected static SqlDbType SqlTypeConversionKey(string fullName)
        {

            var conversionKey = new Dictionary<string, SqlDbType>
            { {"System.Int64", SqlDbType.BigInt},
                {"System.Byte[]",SqlDbType.Binary},
                {"System.Boolean",SqlDbType.Bit},
                {"System.String",SqlDbType.VarChar},
                {"System.DateTime",SqlDbType.DateTime},
                {"System.Decimal",SqlDbType.Decimal},
                {"System.Double",SqlDbType.Float},
                {"System.Int32", SqlDbType.Int},
                {"System.Int16", SqlDbType.SmallInt},
                {"System.Byte", SqlDbType.TinyInt},
                {"System.Guid", SqlDbType.UniqueIdentifier},
                {"System.Object", SqlDbType.Variant},
                {"System.Single", SqlDbType.Real},
                {"System.Char", SqlDbType.NChar}};
            if (conversionKey.ContainsKey(fullName))
            {
                return conversionKey[fullName];
            }
            return SqlDbType.Variant;
        }

        public void SetConnection()
        {
            ConnectionManager.ConnectionManager.SetConnection(_connectionString);
        }
        private void ClearData()
        {
            //
            _tables.AddressDataTable.Clear();
            _tables.InvalidBenefitsDataTable.Clear();
            _tables.InvalidBenefitsDataTable.Dispose();
            _tables.InvalidDataTable.Clear();
            _tables.InvalidDataTable.Dispose();
            _tables.RegisterDataTable.Clear();
            _tables.RegisterDataTable.Dispose();
            _tables.ErrorDataTable.Clear();
            _tables.ErrorDataTable.Dispose();
            _tables.CustomerDataTable.Clear();
            _tables.CustomerDataTable.Dispose();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
        private void ClearAll()
        {
            _tables = new Tables();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void WhereClasure(string criteria, object[] parameters, string predicate)
        {
            if (parameters.Length == 2 && string.Equals(predicate.ToUpper(), "BETWEEN"))
            {
                whereClasure = $"where {criteria} {predicate} @param1 AND @param2";
                //value = 
            }
            else
            {
                whereClasure = $"where {criteria} " + predicate + " @param";
                value = (IConvertible)parameters[0];
                dbType = "@param " + SqlTypeConversionKey(parameters[0].GetType().FullName);
            }
        }
    }
}
