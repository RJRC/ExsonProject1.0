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
    public partial class Reports : Form
    {
        private OrderBLL orderBll = new OrderBLL();
        private ReportsBLL reportsBll = new ReportsBLL();

        public Reports()
        {
            InitializeComponent();
            loadOrderView();

        }

        public void loadOrderView()
        {

            dataGridView1.DataSource = orderBll.showOrdersGeneral();
            comboStatus.DataSource = reportsBll.getStatusValues();
        }

        private void Reports_Load(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void DtOrderDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void TxtCompany_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void TxtOrderNum_TextChanged(object sender, EventArgs e)
        {

        }

        private void LbOrderNum_Click(object sender, EventArgs e)
        {

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime startSearch = dateSince.Value.Date;
            DateTime finishSearch = dtUntil.Value.Date;
            string status = comboStatus.SelectedValue.ToString();

            //dataGridView1.DataSource = null;
            dataGridView1.DataSource = orderBll.getOrderWithFilter(startSearch, finishSearch, status);

            //

           MessageBox.Show("Filtro: \n" + "Fecha de inicio: " + startSearch.ToShortDateString() + "\nFecha de Fin: " + finishSearch.ToShortDateString() + "\nEstado: " + status, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            if (reportsBll.downloadReport10(this.dataGridView1))
            {
                MessageBox.Show("Se realizo la exportación con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = orderBll.showOrders();
        }
    }
}
