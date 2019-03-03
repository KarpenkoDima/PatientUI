using SOPB.BAL.Repository;
using System;

namespace SOPB.BAL.CustomerService
{
    public class CustomerSrevice
    {
        protected IRepository _repository;
        public CustomerSrevice(IRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException("Customer service ctor: repository");
        }
        public void Account(string user, string password)
        {
            ((RepositoryBase)_repository).Account(user, password);
        }

        public object GetDictionary() => ((RepositoryBase)_repository).GetGlossary();
        public object GetCustomers()
        {
            return _repository.GetAll();
        }
        public void Upload()
        {
            _repository.FindByID(0);
        }

        public void Update()
        {
            _repository.Update(null);
        }

        public object FindByGlossary(string name, int id)
        {
            return ((RepositoryBase)_repository).FilterByGlossary(name, id);
        }

        public object FindBy(string criteria, params object[] values)
        {
            return _repository.FindBy(criteria, values);            
        }

        public void FromRegToArch()
        {
            _repository.FromRegToArch();
        }
    }
}
