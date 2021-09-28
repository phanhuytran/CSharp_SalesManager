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
    public partial class FNhanVien : Form
    {
        BUS_NhanVien busNV;

        public FNhanVien()
        {
            InitializeComponent();
            busNV = new BUS_NhanVien();
        }

        private void FNhanVien_Load(object sender, EventArgs e)
        {
            busNV.LayDSNV(dGNV);

            dGNV.Columns[0].Width = (int)(0.1 * dGNV.Width);
            dGNV.Columns[1].Width = (int)(0.3 * dGNV.Width);
            dGNV.Columns[2].Width = (int)(0.3 * dGNV.Width);
            dGNV.Columns[3].Width = (int)(0.3 * dGNV.Width);
            dGNV.Columns[4].Width = (int)(0.3 * dGNV.Width);
            dGNV.Columns[5].Width = (int)(0.3 * dGNV.Width);
        }

        private void dGNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex <= dGNV.Rows.Count)
            {
                txtHoTen.Text = dGNV.Rows[e.RowIndex].Cells[1].Value.ToString() + " " + dGNV.Rows[e.RowIndex].Cells[2].Value.ToString();
                dateNgaySinh.Text = dGNV.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtDiaChi.Text = dGNV.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtSoDienThoai.Text = dGNV.Rows[e.RowIndex].Cells[5].Value.ToString();
            }
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            string[] name = txtHoTen.Text.Split(' ');
            string firstname = "";

            for (int i = 1; i < name.Length; i++)
                firstname += name[i] + " ";

            Employee nv = new Employee();
            nv.FirstName = firstname.Trim();
            nv.LastName = name[0];
            nv.BirthDate = DateTime.Parse(dateNgaySinh.Value.ToShortDateString());
            nv.HomePhone = txtSoDienThoai.Text;
            nv.Address = txtDiaChi.Text;

            busNV.ThemNhanVien(nv);
            dGNV.Columns.Clear();
            busNV.LayDSNV(dGNV);
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            busNV.XoaNhanVien(int.Parse(dGNV.Rows[dGNV.CurrentRow.Index].Cells[0].Value.ToString()));
            dGNV.Columns.Clear();
            busNV.LayDSNV(dGNV);
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            string[] name = txtHoTen.Text.Split(' ');
            string firstname = "";

            for (int i = 1; i < name.Length; i++)
                firstname += name[i] + " ";

            Employee nv = new Employee();
            nv.EmployeeID = int.Parse(dGNV.Rows[dGNV.CurrentRow.Index].Cells[0].Value.ToString());
            nv.FirstName = firstname.Trim();
            nv.LastName = name[0];
            nv.BirthDate = DateTime.Parse(dateNgaySinh.Value.ToShortDateString());
            nv.HomePhone = txtSoDienThoai.Text;
            nv.Address = txtDiaChi.Text;

            busNV.SuaNhanVien(nv);
            dGNV.Columns.Clear();
            busNV.LayDSNV(dGNV);
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
