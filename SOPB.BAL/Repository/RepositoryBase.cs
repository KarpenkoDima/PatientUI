using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOPB.BAL.Repository
{
    public abstract class RepositoryBase : IRepository
    {
        protected abstract string GetBaseQuery();
        protected abstract string GetBaseWhereClause();
        protected abstract string GetEntityName();
        protected abstract string GetKeyFieldName();
        public abstract void Account(string user, string password);
        public abstract void FilterBy(string criteria, params string[] values);
        public abstract object FilterBy(string criteria, params object[] values);
        public abstract object FilterByGlossary(string criteria, int id);

        public abstract object GetGlossary();

        #region IRepository methods

        public abstract object FindBy(string criteria, params string[] values);
        public abstract object FindBy(string criteria, params object[] values);

        public abstract object FindByID(int id);

        public abstract void Update(IList<string> list);

        public abstract object GetAll();

        public abstract int GetCount();
        public abstract void FromRegToArch();
        #endregion
    }
}
