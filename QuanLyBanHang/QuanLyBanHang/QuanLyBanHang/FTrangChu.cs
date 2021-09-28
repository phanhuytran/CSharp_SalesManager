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
    public partial class FTrangChu : Form
    {
        public FTrangChu()
        {
            InitializeComponent();
        }

        private void btQLDH_Click(object sender, EventArgs e)
        {
            new FQLDonHang().ShowDialog();
        }

        private void btQLSP_Click(object sender, EventArgs e)
        {
            new FSanPham().ShowDialog();
        }

        private void btQLNV_Click(object sender, EventArgs e)
        {
            new FNhanVien().ShowDialog();
        }

        private void btQLTK_Click(object sender, EventArgs e)
        {
            new FQLTaiKhoan().ShowDialog();
        }

        private void btLogout_Click(object sender, EventArgs e)
        {

            FDangNhap.currentAccount = new Account();
            this.Close();
        }

        private void FTrangChu_Load(object sender, EventArgs e)
        {
            tbUsername.Text = FDangNhap.currentAccount.username;
            tbNV.Text = string.Format("{0} {1}", 
                FDangNhap.currentAccount.Employee.FirstName, 
                FDangNhap.currentAccount.Employee.LastName);
            if (FDangNhap.currentAccount.role != 1)
            {
                btQLTK.Visible = false;
                btQLNV.Visible = false;
                btnThongKe.Visible = false;
            }
            else
            {
                btQLTK.Visible = true;
                btQLNV.Visible = true;
                btnThongKe.Visible = true;
            }
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            FThongKeDH f = new FThongKeDH();
            f.ShowDialog();
        }

        private void btnChages_Click(object sender, EventArgs e)
        {
            FChangePassword f = new FChangePassword();
            f.ShowDialog();
        }
    }
}
