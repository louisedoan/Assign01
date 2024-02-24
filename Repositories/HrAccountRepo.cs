using BussinessObject;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class HrAccountRepo: IHrAccountRepo
    {
        public void AddAccount(Hraccount account)=>HrAccountDAO.Instance.AddAccount(account);
        

        public void DeleteAccount(string id)=>HrAccountDAO.Instance.DeleteAccount(id);
        

        public List<Hraccount> GetAccounts()=>HrAccountDAO.Instance.GetAccounts();
        

        public Hraccount GetById(string id)=>HrAccountDAO.Instance.GetById(id);
       

        public Hraccount GetManagementMember(string email) => HrAccountDAO.Instance.GetManagementMember(email);

        public List<Hraccount> SearchAccount(string value)=>HrAccountDAO.Instance.SearchAccount(value);
        

        public void UpdateAccount(Hraccount account)=>HrAccountDAO.Instance.UpdateAccount(account); 
       
    }
}
