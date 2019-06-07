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
    public partial class Customer : Form
    {
        

        public Customer()
        {
            InitializeComponent();
            loadCustomerView();
        }

        private BusinessLogicLayer bll = new BusinessLogicLayer();

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void loadCustomerView() {

            dataGridView1.DataSource = bll.showClients();

        }
    }
}
