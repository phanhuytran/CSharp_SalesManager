using System;
using System.Collections.Generic;
using System.Linq;

namespace QuanLyBanHang
{
    class DAO_CTDH
    {
        NWDataContext db;
        public DAO_CTDH()
        {
            db = new NWDataContext();
        }

        public dynamic HienThiCTDH(int maDH)
        {
            return db.Order_Details.Where(s => s.OrderID == maDH)
                .Select(s => new
                {
                    s.OrderID,
                    s.ProductID,
                    s.UnitPrice,
                    s.Quantity,
                    s.Discount
                });
        }

        public bool ThemDanhSachCTDH(List<Order_Detail> ds)
        {
            bool tinhTrang = true;
            try
            {
                ds.ForEach(i => {

                    try
                    {
                        Order_Detail odCurrent = db.Order_Details.First(o => o.OrderID == i.OrderID && o.ProductID == i.ProductID);
                        odCurrent.Quantity += i.Quantity;

                    }
                    catch
                    {
                        db.Order_Details.InsertOnSubmit(i);
                    }
                    db.SubmitChanges();

                });

                tinhTrang = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                tinhTrang = false;
            }

            return tinhTrang;
        }

        public bool SuaCTDH(Order_Detail d)
        {
            bool tinhTrang = false;
            try
            {
                Order_Detail ct = db.Order_Details.First(s => s.OrderID == d.OrderID && s.ProductID == d.ProductID);

                ct.Quantity = d.Quantity;
                ct.UnitPrice = d.UnitPrice;
                ct.Discount = d.Discount;

                db.SubmitChanges();
                tinhTrang = true;
            }
            catch (Exception)
            {
                tinhTrang = false;
            }
            return tinhTrang;
        }

        public bool XoaCTDH(int maDH, int maSP)
        {
            bool tinhTrang = true;
            try
            {
                // Xoa chi tiet don hang co OrderID = maDH va ProductID = maSP
                Order_Detail d = db.Order_Details.Single(s => s.OrderID == maDH && s.ProductID == maSP);
                db.Order_Details.DeleteOnSubmit(d);
                db.SubmitChanges();

                tinhTrang = true;
            }
            catch (Exception)
            {

                tinhTrang = false;
            }
            return tinhTrang;
        }
    }
}