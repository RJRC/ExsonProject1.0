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

    /// <summary>
    /// The Reports class 
    /// Contains all methods for the reports in the View Layer.
    /// </summary>
    public partial class Reports : Form
    {
        /// <summary>
        /// Variable with the instance of OrderBLL.
        /// </summary>
        private OrderBLL orderBll = new OrderBLL();

        /// <summary>
        /// Variable with the instance of ReportsBLL.
        /// </summary>
        private ReportsBLL reportsBll = new ReportsBLL();

        /// <summary>
        /// Builder of Reports class.
        /// </summary>
        public Reports()
        {
            InitializeComponent();
            loadOrderView();
            showFirstOrderDate();

        }

        /// <summary>
        /// The loadOrderView method 
        /// Load the dataGridView1 with orders information
        /// and load the comboStatus with status information.
        /// </summary>
        public void loadOrderView()
        {

            dataGridView1.DataSource = orderBll.showOrdersGeneral();
            comboStatus.DataSource = reportsBll.getStatusValues();
        }


        /// <summary>
        /// The button1_Click method 
        /// Search and filter orders by date and status.
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            DateTime startSearch = dateSince.Value.Date;
            DateTime finishSearch = dtUntil.Value.Date;
            string status = comboStatus.SelectedValue.ToString();
            dataGridView1.DataSource = orderBll.getOrderWithFilter(startSearch, finishSearch, status);
           MessageBox.Show("Filtro: \n" + "Fecha de inicio: " + startSearch.ToShortDateString() + "\nFecha de Fin: " + finishSearch.ToShortDateString() + "\nEstado: " + status, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        /// <summary>
        /// The btnDownload_Click method 
        /// Makes an excel report with orders information.
        /// </summary>
        private void btnDownload_Click(object sender, EventArgs e)
        {
            if (reportsBll.downloadReport(this.dataGridView1))
            {
                MessageBox.Show("Se realizo la exportación con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }


        /// <summary>
        /// The button2_Click method 
        /// Show all orders.
        /// </summary>
        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = orderBll.showOrdersReports();
        }

        /// <summary>
        /// The showFirstOrderDate method 
        /// show in a label with the date of the oldest order in the DB
        /// </summary>
        private void showFirstOrderDate()
        {
            lb_startDate.Text += orderBll.firstOrderADL();
        }
    }
}
