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
    /// <summary>
    /// The DashBoard class 
    /// Contains all methods for the dashBoard in the View Layer.
    /// </summary>
    public partial class DashBoard : Form
    {

        /// <summary>
        /// Variable with the instance of OrderBLL.
        /// </summary>
        private OrderBLL bll = new OrderBLL();

        /// <summary>
        /// Variable with the instance of ReportsBLL.
        /// </summary>
        private ReportsBLL rll = new ReportsBLL();


        /// <summary>
        /// Builder of DashBoard class.
        /// </summary>
        public DashBoard()
        {
            InitializeComponent();
            methodGenerateGraphic();
            generateLbTotalSales();
            countSales();
            generateLbCostTotal();
            showFirstOrderDate();
            methodGenerateGraphicComparativeCostSale();
        }

        /// <summary>
        /// The methodGenerateGraphic method 
        /// Generates a graphic with the sales information.
        /// </summary>
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


        /// <summary>
        /// The methodGenerateGraphicComparativeCostSale method
        /// Generates graphics of cost and sales
        /// </summary>
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

        /// <summary>
        /// The generateLbTotalSales method 
        /// Generates a label with the total of the sales.
        /// </summary>
        private void generateLbTotalSales()
        {
            DataTable dataTableOrder = new DataTable();
            dataTableOrder = bll.totalsales();
            DataRow dataRow = dataTableOrder.Rows[0];
            lb_showTotalSales.Text += dataRow["TotalVentas"].ToString();
        }

        /// <summary>
        /// The generateLbCostTotal method 
        /// Generates a label with the cost of the orders.
        /// </summary>
        private void generateLbCostTotal()
        {
            DataTable dataTableOrder = new DataTable();
            dataTableOrder = bll.costSalesBLL();
            DataRow dataRow = dataTableOrder.Rows[0];
            lb_showTotalCost.Text += dataRow["costOrders"].ToString();
        }

        /// <summary>
        /// The countSales method 
        /// Generates a label with the count of the orders.
        /// </summary>
        private void countSales() {

            DataTable dataTableOrder = new DataTable();
            dataTableOrder = bll.countSalesBLL();
            DataRow dataRow = dataTableOrder.Rows[0];
            lb_showCountSales.Text += dataRow["countOrders"].ToString();
        }


        /// <summary>
        /// The showFirstOrderDate method 
        /// show in a label with the date of the oldest order in the DB
        /// </summary>
        private void showFirstOrderDate()
        {
            lb_startDate.Text += bll.firstOrderADL();
        }
    }
}
