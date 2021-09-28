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
    public partial class FThongKeDH : Form
    {
        BUS_Account busTK;

        public FThongKeDH()
        {
            InitializeComponent();
            busTK = new BUS_Account();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            int month = int.Parse(numThang.Value.ToString());
            int year = int.Parse(numNam.Value.ToString());
            int total = busTK.TKTotalOrderByMonthAndYear(month, year);
            txtTotalOrder.Text = total.ToString();

        }

        private void btnGetOrders_Click(object sender, EventArgs e)
        {
            int month = int.Parse(numThang.Value.ToString());
            int year = int.Parse(numNam.Value.ToString());

            busTK.TKOrderByMonthAndYear(month, year, gVThongKe);


            gVThongKe.Columns[0].Width = (int)(0.22 * gVThongKe.Width);
            gVThongKe.Columns[1].Width = (int)(0.22 * gVThongKe.Width);
            gVThongKe.Columns[2].Width = (int)(0.22 * gVThongKe.Width);
            gVThongKe.Columns[3].Width = (int)(0.22 * gVThongKe.Width);
        }
    }
}
