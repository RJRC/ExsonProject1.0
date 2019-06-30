using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace View.Presentacion
{
    public partial class dashBoard : Form
    {

        private OrderBLL bll = new OrderBLL();
        public dashBoard()
        {
            InitializeComponent();
            methodGenerateGraphic();
            generateLbTotalSales();
            countSales();
            generateLbCostTotal();
        }


        public void methodGenerateGraphic()
        {
            DataTable dataTableOrder = new DataTable();
            dataTableOrder = bll.totalOrdersByMonth();

            chart_salesPerMonth.Series["Total ventas"].XValueMember = "Mes";
            chart_salesPerMonth.Series["Total ventas"].YValueMembers = "TotalOrdenes";

            chart_salesPerMonth.DataSource = dataTableOrder;
            chart_salesPerMonth.DataBind();
            chart_salesPerMonth.Visible = true;
        }

        private void generateLbTotalSales()
        {
            DataTable dataTableOrder = new DataTable();
            dataTableOrder = bll.totalsales();
            DataRow dataRow = dataTableOrder.Rows[0];
            lb_showTotalSales.Text += dataRow["TotalVentas"].ToString();
        }

        private void generateLbCostTotal()
        {
            DataTable dataTableOrder = new DataTable();
            dataTableOrder = bll.costSalesBLL();
            DataRow dataRow = dataTableOrder.Rows[0];
            lb_showTotalCost.Text += dataRow["costOrders"].ToString();
        }

        private void countSales() {
            DataTable dataTableOrder = new DataTable();
            dataTableOrder = bll.countSalesBLL();
            DataRow dataRow = dataTableOrder.Rows[0];
            lb_showCountSales.Text += dataRow["countOrders"].ToString();
        }
    }
}
