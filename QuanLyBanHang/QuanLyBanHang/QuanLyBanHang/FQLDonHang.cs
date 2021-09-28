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
    public partial class FQLDonHang : Form
    {
        BUS_DonHang busDH;
        public FQLDonHang()
        {
            InitializeComponent();
            busDH = new BUS_DonHang();
        }
        
        private void FQLDonHang_Load(object sender, EventArgs e)
        {
            CapNhatDonHang();

            busDH.LayDSKH(cbKhachHang);
            busDH.LayDSNV(cbNhanVien);
        }

        private void CapNhatDonHang()
        {
            busDH.LayDSDH(gVDH);
            gVDH.Columns[0].Width = (int)(0.2 * gVDH.Width);
            gVDH.Columns[1].Width = (int)(0.3 * gVDH.Width);
            gVDH.Columns[2].Width = (int)(0.4 * gVDH.Width);
            gVDH.Columns[3].Width = (int)(0.3 * gVDH.Width);
        }

        private void gVDH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex <= gVDH.Rows.Count - 1)
            {
                txtMaDH.Enabled = false;
                txtMaDH.Text = gVDH.Rows[e.RowIndex].Cells["OrderID"].Value.ToString();
                dtpNgayDH.Text = gVDH.Rows[e.RowIndex].Cells[1].Value.ToString();
                cbNhanVien.Text = gVDH.Rows[e.RowIndex].Cells[3].Value.ToString();
                cbKhachHang.Text = gVDH.Rows[e.RowIndex].Cells[2].Value.ToString();
            }
        }

        private void gVDH_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                FCTDH fCTDH = new FCTDH(int.Parse(gVDH.CurrentRow.Cells["OrderID"].Value.ToString()));
                fCTDH.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Invalid order id");
            }
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            Order d = new Order();

            d.OrderDate = dtpNgayDH.Value;
            d.CustomerID = cbKhachHang.SelectedValue.ToString();
            d.EmployeeID = int.Parse(cbNhanVien.SelectedValue.ToString());

            busDH.ThemDH(d);

            gVDH.Columns.Clear();
            CapNhatDonHang();
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            if (txtMaDH.Text != "")
            {
                busDH.XoaDH(int.Parse(txtMaDH.Text));
                gVDH.Columns.Clear();
                CapNhatDonHang();
            }
            else
            {
                MessageBox.Show("You have not selected the order to delete");
            }
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            Order d = new Order();

            d.OrderID = int.Parse(txtMaDH.Text);
            d.OrderDate = dtpNgayDH.Value;
            d.CustomerID = cbKhachHang.SelectedValue.ToString();
            d.EmployeeID = int.Parse(cbNhanVien.SelectedValue.ToString());

            busDH.SuaDH(d);

            gVDH.Columns.Clear();
            CapNhatDonHang();
        }

        private void Them_CTDH_Click(object sender, EventArgs e)
        {
            FDatHang f = new FDatHang();
            f.maDH = int.Parse(gVDH.CurrentRow.Cells[0].Value.ToString());
            f.ShowDialog();
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}