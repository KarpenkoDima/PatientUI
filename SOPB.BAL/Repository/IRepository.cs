using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOPB.BAL.Repository
{
    public interface IRepository
    {
        object FindBy(string criteria, params string[] values);       
        object FindBy(string criteria, params object[] values);
        object FindByID(int id);
        void Update(IList<string> list);
        object GetAll();
        void FromRegToArch();
    }
    
}
