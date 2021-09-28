using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    class BUS_CTDH
    {
        DAO_CTDH da;

        DAO_SanPham ds;
        public BUS_CTDH()
        {
            da = new DAO_CTDH();
            ds = new DAO_SanPham();
        }

        private DataTable InitDH()
        {
            DataTable dtCTDH = new DataTable();

            dtCTDH.Columns.Add("OrderID");
            dtCTDH.Columns.Add("ProductID");
            dtCTDH.Columns.Add("UnitPrice");
            dtCTDH.Columns.Add("Quantity");
            dtCTDH.Columns.Add("Discount");

            return dtCTDH;
        }

        // Phần xử lý sản phẩm
        public void LayDSSP(ComboBox cb)
        {
            cb.DataSource = ds.LayDSSanPham();
            cb.DisplayMember = "ProductName";
            cb.ValueMember = "ProductID";
        }

        public ProductModel HienThiDSSP(int maSP)   // Hiển thị danh sách sản phẩm theo ProductModel tự định nghĩa
        {
            var s = ds.LayThongTinSanPham(maSP);

            return s;
        }

        // Phần xử lý CTDH
        public void HienThiCTDH(DataGridView dg, int maDH)
        {
            var ds = da.HienThiCTDH(maDH);

            if (ds != null)
            {
                dg.DataSource = da.HienThiCTDH(maDH);
            }
            else
            {
                dg.DataSource = InitDH();
            }
        }

        public void ThemDanhSachCTDH(List<Order_Detail> list)
        {
            if (da.ThemDanhSachCTDH(list))
            {
                MessageBox.Show("You have successfully placed your order");
            }
            else
            {
                MessageBox.Show("You have unsuccessfully placed your order");
            }
        }

        public void SuaCTDH(Order_Detail d)
        {
            if (da.SuaCTDH(d))
            {
                MessageBox.Show("You have successfully updated your order details");
            }
            else
            {
                MessageBox.Show("Couldn't find the order details to update");
            }
        }

        public void XoaCTDH(int maDH, int maSP)
        {
            if (da.XoaCTDH(maDH, maSP))
            {
                MessageBox.Show("You have successfully deleted order details");
            }
            else
            {
                MessageBox.Show("You have unsuccessfully deleted order details");
            }
        }

        internal void ThemDanhSachCTDH(DataGridView dGSP, int maDH)
        {
            List<Order_Detail> lsOrdetail = new List<Order_Detail>();

            foreach (DataGridViewRow r in dGSP.Rows)
            {

                if (r.Cells["ProductID"].Value != null)
                {
                    Order_Detail order = new Order_Detail();
                    order.ProductID = int.Parse(r.Cells["ProductID"].Value.ToString());
                    order.OrderID = maDH;
                    try
                    {
                        order.UnitPrice = decimal.Parse(r.Cells["UnitPrice"].Value.ToString());
                        order.Quantity = short.Parse(r.Cells["Quantity"].Value.ToString());
                        order.Discount = float.Parse(r.Cells["Discount"].Value.ToString().Replace("%", ""));
                    }
                    catch
                    {
                        MessageBox.Show("Please complete and correct information");
                        return;
                    }

                    lsOrdetail.Add(order);
                }

            }
            
            if (da.ThemDanhSachCTDH(lsOrdetail))
            {
                MessageBox.Show("You have successfully created an order");
            }
            else
            {
                MessageBox.Show("You have unsuccessfully created an order");
            }
            
        }

        internal void showProductName(ComboBox cbTenSP, int productID)
        {
            Product p = ds.LayThongTinSanPham2(productID);
            if (p != null)
            {
                cbTenSP.Text = p.ProductName;
            }
        }
    }
}