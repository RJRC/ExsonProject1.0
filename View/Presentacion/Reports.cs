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
        private BusinessLogicLayer bll = new BusinessLogicLayer();

        public Reports()
        {
            InitializeComponent();
            loadOrderView();
        }

        public void loadOrderView()
        {

            dataGridView1.DataSource = bll.showOrders();

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
    }
}
