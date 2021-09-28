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
    public partial class FChangePassword : Form
    {
        BUS_Account busTK;
        public FChangePassword()
        {
            InitializeComponent();
            busTK = new BUS_Account();
            txtNewPass.Text = "";
            txtNewPass.PasswordChar = '*';
        }

        private void btnChangePass_Click(object sender, EventArgs e)
        {
            txtNewPass.PasswordChar = '*';
            busTK.ChangePasswordTaiKhoan(txtNewPass.Text);
            this.Close();
        }
    }
}
