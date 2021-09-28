using QuanLyBanHang.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang.BUS
{
    class BUS_Account
    {
        DAO_Account da;
        public BUS_Account()
        {
            da = new DAO_Account();
        }

        public void LayDSTaiKhoan(DataGridView dg)
        {
            dg.DataSource = da.GetAll();
        }

        public void LayDSRole(ComboBox cb)
        {
            cb.DataSource = da.GetRole();
            cb.DisplayMember = "role1";
            cb.ValueMember = "id";
        }

        public void ThemTaiKhoan(Account account)
        {
            if (da.Add(account))
            {
                MessageBox.Show("You have successfully created an account");
            }
            else
            {
                MessageBox.Show("You have unsuccessfully created an account");
            }
        }

        public void ResetPasswordTaiKhoan(string username)
        {
            if (da.ResetPassword(username))
            {
                MessageBox.Show("You have successfully reset your account password");
            }
            else
            {
                MessageBox.Show("You have unsuccessfully reset your account password");
            }
        }

        public void ChangePasswordTaiKhoan(string password)
        {
            if (da.ChangePassword(password))
            {
                MessageBox.Show("You have successfully changed your account password");
            }
            else
            {
                MessageBox.Show("You have unsuccessfully changed your account password");
            }
        }

        public void XoaTaiKhoan(Account account)
        {
            if (da.Delete(account))
            {
                MessageBox.Show("You have successfully removed your account password");
            }
            else
            {
                MessageBox.Show("You have unsuccessfully removed your account password");
            }
        }

        public bool CheckTaiKhoan(string username, string password)
        {
            if (da.CheckAccount(username, password))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Account GetCurrentAccount(string username)
        {
            return da.GetAccountByUserName(username);
        }

        public int TKTotalOrderByMonthAndYear(int month, int year)
        {
            return da.TKTotalOrderByMonthAndYear(month, year);
        }
        public void TKOrderByMonthAndYear(int month, int year, DataGridView dg)
        {
            dg.DataSource = da.TKOrderByMonthAndYear(month, year);
        }
    }
}
