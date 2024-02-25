using BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class HrAccountDAO
    {
        private static HrAccountDAO instance = null;

        private HrAccountDAO() { }

        public static HrAccountDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HrAccountDAO();
                }
                return instance;
            }

        }



        public Hraccount GetManagementMember(String email)
        {
            var dbContext = new CandidateManagement_03Context();
            

            return dbContext.Hraccounts.SingleOrDefault(m => m.Email.Equals(email));

        }




       
        public List<Hraccount> GetAccounts()
        {
            try
            {
                var dbContext = new CandidateManagement_03Context();
                return dbContext.Hraccounts.ToList();


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Hraccount GetById(string email)
        {
            try
            {
                var dbContext = new CandidateManagement_03Context();
                return dbContext.Hraccounts.SingleOrDefault(p => p.Email.Equals(email));



            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public void AddAccount(Hraccount account)
        {
            try
            {
                var dbContext = new CandidateManagement_03Context();
                Hraccount checkExit = GetById(account.Email);

                if (checkExit == null)
                {
                    dbContext.Hraccounts.Add(account);
                    dbContext.SaveChanges();
                }
                else
                {
                    throw new Exception("Job ID is existed");
                }



            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }





        public void DeleteAccount(string id)
        {
            try
            {
                var dbContext = new CandidateManagement_03Context();
                Hraccount account = GetById(id); // Lấy đối tượng CandidateProfile dựa trên ID
                if (account != null)
                {
                    dbContext.Hraccounts.Remove(account); // Xóa đối tượng từ DbContext
                    dbContext.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public void UpdateAccount(Hraccount account)
        {
            try
            {
                var dbContext = new CandidateManagement_03Context();
                if (account != null)
                {
                    dbContext.Hraccounts.Update(account);
                    dbContext.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Hraccount> SearchAccount(string value)
        {
            try
            {
                using (var dbContext = new CandidateManagement_03Context())
                {
                    return dbContext.Hraccounts.Where(p => p.FullName.Contains(value)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

