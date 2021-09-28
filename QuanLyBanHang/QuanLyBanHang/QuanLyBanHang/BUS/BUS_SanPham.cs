using System.Windows.Forms;

namespace QuanLyBanHang
{
    class BUS_SanPham
    {
        DAO_SanPham da;
        public BUS_SanPham()
        {
            da = new DAO_SanPham();
        }

        public void LayDSLSP(ComboBox cb)
        {
            cb.DataSource = da.LayDSLSP();
            cb.DisplayMember = "CategoryName";
            cb.ValueMember = "CategoryID";
        }

        public void LayDSNCC(ComboBox cb)
        {
            cb.DataSource = da.LayDSNCC();
            cb.DisplayMember = "CompanyName";
            cb.ValueMember = "SupplierID";
        }

        public void LayDSSP(DataGridView dg)
        {
            dg.DataSource = da.LayDSSanPham();
        }

        public void ThemSP(Product p)
        {
            if (da.ThemSP(p))
            {
                MessageBox.Show("You have successfully created a product");
            }
            else
            {
                MessageBox.Show("You have unsuccessfully created a product");
            }
        }

        public void SuaSP(Product p)
        {
            if (da.SuaSP(p))
            {
                MessageBox.Show("You have successfully updated a product");
            }
            else
            {
                MessageBox.Show("You have unsuccessfully updated a product");
            }
        }

        public void XoaSP(int maSP)
        {
            if (da.XoaSP(maSP))
            {
                MessageBox.Show("You have successfully removed a product");
            }
            else
            {
                MessageBox.Show("You have unsuccessfully removed a product");
            }
        }
    }
}