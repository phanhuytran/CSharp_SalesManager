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
    public partial class FDatHang : Form
    {
        BUS_DonHang busDH;
        BUS_CTDH busCTDH;
        
        public FDatHang()
        {
            InitializeComponent();
            busDH = new BUS_DonHang();
            busCTDH = new BUS_CTDH();
        }

        public int maDH;
        bool flag = false;
        DataTable dtSanPham;

        private void FDatHang_Load(object sender, System.EventArgs e)
        {
            txtMaDH.Text = maDH.ToString();
            busCTDH.LayDSSP(cbSP);
            flag = true;

            dtSanPham = new DataTable();

            dtSanPham.Columns.Add("ProductID");
            dtSanPham.Columns.Add("UnitPrice");
            dtSanPham.Columns.Add("Quantity");
            dtSanPham.Columns.Add("Discount");

            dGSP.DataSource = dtSanPham;

            dGSP.Columns[0].Width = (int)(0.3 * dGSP.Width);
            dGSP.Columns[1].Width = (int)(0.3 * dGSP.Width);
            dGSP.Columns[2].Width = (int)(0.3 * dGSP.Width);
            dGSP.Columns[3].Width = (int)(0.3 * dGSP.Width);
            HienThiThongTinSanPham("1");
        }

        void HienThiThongTinSanPham(string maSP)
        {
            int ma = int.Parse(maSP);
            ProductModel s = busCTDH.HienThiDSSP(ma);
            txtLoaiSP.Text = s.CategoryName.ToString();
            txtNhaCC.Text = s.CompanyName.ToString();
            txtDonGia.Text = s.UnitPrice.ToString();
            txtGiamGia.Text = "0%";

        }

        private void dGSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dGSP.Rows.Count - 1)
            {
                cbSP.SelectedIndex = int.Parse(dGSP.Rows[e.RowIndex].Cells["ProductID"].Value.ToString());
                numSoLuong.Text = dGSP.Rows[e.RowIndex].Cells["Quantity"].Value.ToString();
                txtGiamGia.Text = dGSP.Rows[e.RowIndex].Cells["Discount"].Value.ToString();
                txtDonGia.Text = dGSP.Rows[e.RowIndex].Cells["UnitPrice"].Value.ToString();
            }
        }

        private void cbSP_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (flag)
            {
                HienThiThongTinSanPham(cbSP.SelectedValue.ToString());
            }
        }

        private void btThem_Click(object sender, System.EventArgs e)
        {
            bool kiemtra = true;

            foreach (DataRow item in dtSanPham.Rows)
            {
                if (item[0].ToString() == cbSP.SelectedValue.ToString()) //co maSP hay ko
                {
                    kiemtra = false;
                    // tang so luong
                    item[2] = int.Parse(item[2].ToString()) + int.Parse(numSoLuong.Value.ToString());
                    break;
                }
            }

            if (kiemtra)
            {
                DataRow r = dtSanPham.NewRow();

                r[0] = cbSP.SelectedValue.ToString();
                r[1] = txtDonGia.Text;
                r[2] = numSoLuong.Value.ToString();
                r[3] = txtGiamGia.Text;

                dtSanPham.Rows.Add(r);
            }
        }

        private void btXoa_Click(object sender, System.EventArgs e)
        {
            foreach (DataGridViewCell c in dGSP.SelectedCells)
            {
                if (c.Selected)
                    dGSP.Rows.RemoveAt(c.RowIndex);
            }
        }

        private void btSua_Click(object sender, System.EventArgs e)
        {
            int dem = -1;
            foreach (DataRow item in dtSanPham.Rows)
            {
                dem++;
                if (dem == dGSP.CurrentCell.RowIndex)
                {
                    decimal discount = decimal.Parse(txtGiamGia.Text.Replace("%", "")) / 100;

                    item[1] = decimal.Parse(txtDonGia.Text) - decimal.Parse(txtDonGia.Text) * discount;
                    item[2] = int.Parse(numSoLuong.Value.ToString());
                    item[3] = discount + "%";
                    break;
                }
            }
        }

        private void btTaoDonHang_Click(object sender, EventArgs e)
        {
            if (dGSP.Rows.Count <= 1)
            {
                MessageBox.Show("Please select a product before adding an order");
            }
            else
            {
                busCTDH.ThemDanhSachCTDH(dGSP, maDH);
            }
        }

        private void btThoat_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}