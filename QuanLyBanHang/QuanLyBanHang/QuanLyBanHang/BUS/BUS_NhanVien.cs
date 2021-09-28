using System.Windows.Forms;

namespace QuanLyBanHang
{
    class BUS_NhanVien
    {
        DAO_NhanVien da;
        public BUS_NhanVien()
        {
            da = new DAO_NhanVien();
        }

        public void LayDSNV(DataGridView dg)
        {
            dg.DataSource = da.LayDSNV();
        }

        public void ThemNhanVien(Employee e)
        {
            if (da.ThemNhanVien(e))
            {
                MessageBox.Show("You have successfully created an employee");
            }
            else
            {
                MessageBox.Show("You have unsuccessfully created an employee");
            }
        }

        public void SuaNhanVien(Employee e)
        {
            if (da.SuaNhanVien(e))
            {
                MessageBox.Show("You have successfully updated an employee");
            }
            else
            {
                MessageBox.Show("You have unsuccessfully updated an employee");
            }
        }

        public void XoaNhanVien(int maNV)
        {
            if (da.XoaNhanVien(maNV))
            {
                MessageBox.Show("You have successfully removed an employee");
            }
            else
            {
                MessageBox.Show("You have unsuccessfully removed an employee");
            }
        }
    }
}