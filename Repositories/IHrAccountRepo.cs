using BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IHrAccountRepo
    {
        Hraccount GetManagementMember(String email);

        public List<Hraccount> GetAccounts();

        public Hraccount GetById(string id);

        public void AddAccount(Hraccount account);

        public void DeleteAccount(string id);
        public void UpdateAccount(Hraccount account);

        public List<Hraccount> SearchAccount(string value);
    }
}
