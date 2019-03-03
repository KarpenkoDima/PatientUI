using SOPB.BAL.Repository;
using SOPB.DAL.AccessData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOPB.DAL.LoadData
{
    public class SQLArchRepository : RepositoryBase
    {

        const string _entity = "vGetCustomerArch";
        private readonly string _keyField;
        private string _whereClasure;
        CustomerAccess _customerAccess;
        public SQLArchRepository(string connectionString)
        {
            _customerAccess = new CustomerAccess(connectionString);
            if (_customerAccess == null)
            {
                throw new ArgumentNullException("customer arch access");
            }
            _keyField = "CustomerID";
        }
        #region RepositoryBase methods

        public override void Account(string user, string password)
        {
            SOPB.DAL.ConnectionManager.ConnectionManager.Account(user, password);
            _customerAccess.SetConnection();
        }
        protected override string GetBaseQuery()
        {
            return string.Format("SELECT * FROM {0}", _entity);
        }

        protected override string GetBaseWhereClause()
        {
            return string.Format("WHERE {0} = ", _keyField);
        }
        protected override string GetEntityName()
        {
            return _entity;
        }
        protected override string GetKeyFieldName()
        {
            return _keyField;
        }
        public override void FilterBy(string criteria, params string[] values)
        {
            throw new NotImplementedException();
        }
        public override int GetCount()
        {
            throw new NotImplementedException();
        }

        public override void FromRegToArch()
        {
            _customerAccess.FromRegToArch(0);
        }

        public override object FilterByGlossary(string criteria, int id)
        {
            _customerAccess.FilterByGlossary(criteria, id, 1);
            return _customerAccess.GetData();
        }
        #endregion

        #region IRepository members       

        public override object FindBy(string criteria, params string[] values)
        {
            int isArch = 1;
            object[] arr = new object[values.Length + 1];
            Array.Copy(values, arr, values.Length);
            arr[arr.Length - 1] = isArch;
            _customerAccess.GetDataByCriteria(criteria, arr);
            return _customerAccess.GetData();
        }

        public override object FindByID(int id)
        {
            if (id == 0)
            {
                _customerAccess.Upload();
            }
            return 0;
        }

        public override void Update(IList<string> list)
        {
            _customerAccess.Update();
        }

        public override object GetAll()
        {
            _customerAccess.FillDictionary();
            _customerAccess.FillCustomerDataArch();
            return _customerAccess.GetData();
        }
        #endregion

        public void Connection()
        {
            _customerAccess.SetConnection();
        }

        public override object GetGlossary()
        {
            _customerAccess.FillDictionary();
            return _customerAccess.GetData();
        }

        public override object FilterBy(string criteria, params object[] values)
        {
            int isArch = 1;
            object[] arr = new object[values.Length + 1];
            Array.Copy(values, arr, values.Length);
            arr[arr.Length - 1] = isArch;
            _customerAccess.GetDataByCriteria(criteria, arr);
            return _customerAccess.GetData();
        }
        public override object FindBy(string criteria, params object[] values)
        {
            return this.FilterBy(criteria, values);
        }
    }
}
