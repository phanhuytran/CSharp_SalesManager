using System;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    class BUS_DonHang
    {
        DAO_DonHang da;
        public BUS_DonHang()
        {
            da = new DAO_DonHang();
        }

        // Phần xử lý khách hàng
        public void LayDSKH(ComboBox cb)
        {
            cb.DisplayMember = "CompanyName";
            cb.ValueMember = "CustomerID";
            cb.DataSource = da.LayDSKH();
        }

        // Phần xử lý nhân viên
        public void LayDSNV(ComboBox cb)
        {
            cb.DisplayMember = "LastName";
            cb.ValueMember = "EmployeeID";
            cb.DataSource = da.LayDSNV();
        }

        // Phần xử lý đơn hàng
        public void LayDSDH(DataGridView dg)
        {
            dg.DataSource = da.LayDSDH();
        }

        public void ThemDH(Order d)
        {
            try
            {
                da.ThemDH(d);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void SuaDH(Order donHang)
        {
            if (da.SuaDH(donHang))
            {
                MessageBox.Show("You have successfully updated your order");
            }
            else
            {
                MessageBox.Show("Couldn't find an order to update");
            }
        }

        public void XoaDH(int maDH)
        {
            if (da.XoaDH(maDH))
            {
                MessageBox.Show("You have successfully removed your order");
            }
            else
            {
                MessageBox.Show("Couldn't find an order to removed");
            }
        }
    }
}