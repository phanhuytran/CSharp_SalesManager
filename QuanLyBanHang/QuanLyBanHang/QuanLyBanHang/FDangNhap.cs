using QuanLyBanHang.BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    public partial class FDangNhap : Form
    {
        public static Account currentAccount = new Account();
        BUS_Account busTK;
        public FDangNhap()
        {
            InitializeComponent();
            busTK = new BUS_Account();
            txbPassWord.PasswordChar = '*';
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txbUserName.Text.Trim();
            string password = txbPassWord.Text.Trim();
            bool result = busTK.CheckTaiKhoan(username, password);
            if(result)
            {
                currentAccount = busTK.GetCurrentAccount(username);
                MessageBox.Show("Login successfully");
                txbPassWord.Text = null;
                txbUserName.Text = null;
                new FTrangChu().ShowDialog();
            }  
            else
            {
                MessageBox.Show("Login failed");
            }    

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
