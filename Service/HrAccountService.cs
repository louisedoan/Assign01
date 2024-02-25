using BussinessObject;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class HrAccountService : IHrAccountService
    {

        private IHrAccountRepo memRepo;

        public HrAccountService()
        {
            memRepo = new HrAccountRepo();
        }

        public void AddAccount(Hraccount account)
        {
            memRepo.AddAccount(account);
        }

        public void DeleteAccount(string id)
        {
            memRepo.DeleteAccount(id);
        }

        public List<Hraccount> GetAccounts()
        {
            return memRepo.GetAccounts();
        }

        public Hraccount GetById(string id)
        {
           return memRepo.GetById(id);
        }

        public Hraccount GetManagementMember(string email)
        {
            return memRepo.GetManagementMember(email);
        }

        public List<Hraccount> SearchAccount(string value)
        {
            return memRepo.SearchAccount(value);
        }

        public void UpdateAccount(Hraccount account)
        {
            memRepo.UpdateAccount(account);
        }
    }
}
