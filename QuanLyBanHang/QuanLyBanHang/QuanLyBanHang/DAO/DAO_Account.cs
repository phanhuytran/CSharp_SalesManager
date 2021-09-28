using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.DAO
{
    class DAO_Account
    {
        NWDataContext db;
        public DAO_Account()
        {
            db = new NWDataContext();
        }

        public int TKTotalOrderByMonthAndYear(int month, int year)
        {
            int rs = db.GetTotalAmountOrderSoldByMonthAndYear(month, year);
            return rs;
        }

        public dynamic TKOrderByMonthAndYear(int month, int year)
        {
            var rs = db.GetOrdersByMonthAndYear(month, year).Select(s => new
            {
                s.OrderID,
                s.CompanyName,
                s.OrderDate,
                Employee = string.Format("{0} {1}", s.FirstName, s.LastName)
            }).ToList();
            return rs;
        }

        public bool CheckAccount(string username, string password)
        {
            var rs = db.Accounts.FirstOrDefault(s => (s.username == username && s.password == password));
            if (rs != null)
                return true;
            return false;
        }

        public bool CheckAccountByUserName(string username)
        {
            var rs = db.Accounts.FirstOrDefault(s => (s.username == username));
            if (rs != null)
                return true;
            return false;
        }

        public bool CheckAccountById(int id)
        {
            var rs = db.Accounts.FirstOrDefault(s => (s.id == id));
            if (rs != null)
                return true;
            return false;
        }

        public Account GetAccountByUserName(string username)
        {
            var rs = db.Accounts.FirstOrDefault(s => s.username == username);
            return rs;
        }

        // hay khỏi để tớ tách fName với LName ra v
        public dynamic GetAll()
        {
            var rs = db.Accounts.Select(s => new { 
                s.Employee.FirstName,
                s.Employee.LastName,
                s.username,
                s.password,
                Role = s.role1.role1,
            });
            return rs;
        }

        public List<role> GetRole()
        {
            var rs = db.roles.ToList();
            return rs;
        }

        public bool Delete(Account account)
        {
            if (account.username == FDangNhap.currentAccount.username)            // Nếu là user role Admin đang login thì ko xóa đc
                return false;

            int slgAdmin = db.Accounts.Count(s => s.role == 1);

            if (slgAdmin == 1 && account.role == 1)                 // Nếu là user role Admin cuối cùng thì không thể xóa
                return false;

            if(CheckAccountByUserName(account.username))
            {
                var acc = GetAccountByUserName(account.username);
                db.Accounts.DeleteOnSubmit(acc);
                db.SubmitChanges();
                return true;
            }    
            else
                return false;
        }

        public bool Add(Account account)
        {
            if (string.IsNullOrEmpty(account.username))
                return false;

            if (!CheckAccountByUserName(account.username) && !CheckAccountById(account.id))
            {
                db.Accounts.InsertOnSubmit(account);
                db.SubmitChanges();
                return true;
            }
            else
                return false;
        }

        public bool ChangePassword(string password)
        {
            string username = FDangNhap.currentAccount.username;
            var acc = GetAccountByUserName(username);
            acc.password = password;
            db.SubmitChanges();
            return true;
        }

        public bool ResetPassword(string username)
        {
            if (CheckAccountByUserName(username))
            {
                var acc = GetAccountByUserName(username);
                acc.password = acc.username;
                db.SubmitChanges();
                return true;
            }
            else
                return false;
        }
    }
}
