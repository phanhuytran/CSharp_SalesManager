using System;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    public partial class FCTDH : Form
    {
        private int maDonHang;
        private BUS_CTDH busCTDH;

        public FCTDH()
        {
            InitializeComponent();
            busCTDH = new BUS_CTDH();
        }

        public FCTDH(int orderId)
        {
            InitializeComponent();
            busCTDH = new BUS_CTDH();
            maDonHang = orderId;
        }

        private void HieuChinhDonHang()
        {
            gVCTDH.Columns[0].Width = (int)(0.2 * gVCTDH.Width);
            gVCTDH.Columns[1].Width = (int)(0.3 * gVCTDH.Width);
            gVCTDH.Columns[2].Width = (int)(0.3 * gVCTDH.Width);
            gVCTDH.Columns[3].Width = (int)(0.3 * gVCTDH.Width);
            gVCTDH.Columns[4].Width = (int)(0.3 * gVCTDH.Width);
        }

        private void FCTDH_Load(object sender, EventArgs e)
        {
            txtMaDH.Text = maDonHang.ToString();
            txtMaDH.Enabled = false;
            cbTenSP.Enabled = false;
            busCTDH.HienThiCTDH(gVCTDH, maDonHang);
            HieuChinhDonHang();
            showInfoProduct(0);
        }

        private void gVCTDH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex <= gVCTDH.Rows.Count - 1)
            {
                showInfoProduct(e.RowIndex);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            FDatHang a = new FDatHang();
            a.maDH = maDonHang;
            a.ShowDialog();
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            int maDH = int.Parse(gVCTDH.CurrentRow.Cells["OrderID"].Value.ToString());
            int maSP = int.Parse(gVCTDH.CurrentRow.Cells["ProductID"].Value.ToString());
            busCTDH.XoaCTDH(maDH, maSP);
            // load lại data
            gVCTDH.Columns.Clear();
            busCTDH.HienThiCTDH(gVCTDH, maDonHang);
            HieuChinhDonHang();
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            Order_Detail d = new Order_Detail();

            d.OrderID = int.Parse(txtMaDH.Text);
            d.ProductID = int.Parse(txtMaSP.Text);
            d.Quantity = short.Parse(txtSoLuong.Text);
            d.UnitPrice = decimal.Parse(txtDonGia.Text);
            d.Discount = float.Parse(txtDiscount.Text.Replace("%", "")) / 100;

            busCTDH.SuaCTDH(d);

            gVCTDH.Columns.Clear();
            busCTDH.HienThiCTDH(gVCTDH, maDonHang);
            HieuChinhDonHang();
        }

        private void showInfoProduct(int row)
        {
            try
            {
                txtMaDH.Text = gVCTDH.Rows[row].Cells["OrderID"].Value.ToString();
                txtMaSP.Text = gVCTDH.Rows[row].Cells[1].Value.ToString();
                txtDonGia.Text = gVCTDH.Rows[row].Cells[2].Value.ToString();
                txtSoLuong.Text = gVCTDH.Rows[row].Cells[3].Value.ToString();
                busCTDH.showProductName(cbTenSP, int.Parse(txtMaSP.Text));
                try
                {
                    double discount = double.Parse(gVCTDH.Rows[row].Cells[4].Value.ToString().Trim().Replace("%", ""));
                    txtDiscount.Text = (discount * 100) + "%";
                }
                catch
                {
                }
            }
            catch
            {
            }
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //private void btRefresh_Click(object sender, EventArgs e)
        //{
        //    gVCTDH.Columns.Clear();
        //    busCTDH.HienThiCTDH(gVCTDH, maDonHang);
        //    HieuChinhDonHang();
        //}
    }
}