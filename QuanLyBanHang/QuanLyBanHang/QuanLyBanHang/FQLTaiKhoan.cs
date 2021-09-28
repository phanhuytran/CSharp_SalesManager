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
    public partial class FQLTaiKhoan : Form
    {
        BUS_Account busTK;
        BUS_DonHang busDH;

        public FQLTaiKhoan()
        {
            InitializeComponent();
            busTK = new BUS_Account();
            busDH = new BUS_DonHang();
        }

        private void FQLTaiKhoan_Load(object sender, EventArgs e)
        {
            busTK.LayDSRole(cbRole);
            busTK.LayDSTaiKhoan(gVTK);
            busDH.LayDSNV(cbNhanVien);

            gVTK.Columns[0].Width = (int)(0.3 * gVTK.Width);
            gVTK.Columns[1].Width = (int)(0.3 * gVTK.Width);
            gVTK.Columns[2].Width = (int)(0.3 * gVTK.Width);
            gVTK.Columns[3].Width = (int)(0.3 * gVTK.Width);
            gVTK.Columns[4].Width = (int)(0.3 * gVTK.Width);
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            Account acc = new Account();
            acc.role = int.Parse(cbRole.SelectedValue.ToString());
            acc.username = txtUsername.Text.Trim();

            busTK.XoaTaiKhoan(acc);
            gVTK.Columns.Clear();
            busTK.LayDSTaiKhoan(gVTK);
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            Account acc = new Account();
            acc.id = int.Parse(cbNhanVien.SelectedValue.ToString());
            acc.username = txtUsername.Text.Trim();
            acc.role = int.Parse(cbRole.SelectedValue.ToString());
            if (string.IsNullOrEmpty(txtPassWord.Text))
                acc.password = "0";
            else
                acc.password = txtPassWord.Text.Trim();

            busTK.ThemTaiKhoan(acc);
            gVTK.Columns.Clear();
            busTK.LayDSTaiKhoan(gVTK);
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            busTK.ResetPasswordTaiKhoan(username);
            gVTK.Columns.Clear();
            busTK.LayDSTaiKhoan(gVTK);
        }

        private void gVTK_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex <= gVTK.Rows.Count)
            {
                txtUsername.Text = gVTK.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtPassWord.Text = gVTK.Rows[e.RowIndex].Cells[3].Value.ToString();
                cbNhanVien.Text = gVTK.Rows[e.RowIndex].Cells[0].Value.ToString() + " " + gVTK.Rows[e.RowIndex].Cells[1].Value.ToString();
                cbRole.Text = gVTK.Rows[e.RowIndex].Cells[4].Value.ToString();
            }
        }
    }
}
