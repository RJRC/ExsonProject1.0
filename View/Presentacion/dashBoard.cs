using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using BLL;

namespace View.Presentacion
{
    public partial class dashBoard : Form
    {

        private OrderBLL bll = new OrderBLL();
        private ReportsBLL rll = new ReportsBLL();

        public dashBoard()
        {
            InitializeComponent();
            methodGenerateGraphic();
            generateLbTotalSales();
            countSales();
            generateLbCostTotal();
            methodGenerateGraphicCosts();
            methodGenerateGraphicComparativeCostSale();
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

        public void methodGenerateGraphicCosts()
        {

            DataTable dataTableOrder = new DataTable();
            dataTableOrder = rll.totalCostsYear();

            chartCosts.Series["Costos"].XValueMember = "Año";
            chartCosts.Series["Costos"].YValueMembers = "TotalCosto";
            chartCosts.DataSource = dataTableOrder;
            chartCosts.DataBind();
            chartCosts.Visible = true;

        }

        public void methodGenerateGraphicComparativeCostSale()
        {

            DataTable dataTableOrder = new DataTable();
            dataTableOrder = rll.showComparativeCostsAndSalesMonth();

            chartComparativeCostsSales.Series["Costos"].XValueMember = "Mes";
            chartComparativeCostsSales.Series["Costos"].YValueMembers = "TotalCosto";
            chartComparativeCostsSales.Series["Ventas"].YValueMembers = "TotalVenta";
            chartComparativeCostsSales.DataSource = dataTableOrder;
            chartComparativeCostsSales.DataBind();
            chartComparativeCostsSales.Visible = true;

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

        private void countSales()
        {
            DataTable dataTableOrder = new DataTable();
            dataTableOrder = bll.countSalesBLL();
            DataRow dataRow = dataTableOrder.Rows[0];
            lb_showCountSales.Text += dataRow["countOrders"].ToString();
        }



        private void chart3_Click(object sender, EventArgs e)
        {

        }
    }
}
