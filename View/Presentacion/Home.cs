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
    public partial class Home : Form
    {

        private BusinessLogicLayer bll = new BusinessLogicLayer();

        public Home()
        {
            InitializeComponent();
            loadOrderView();
        }

        public void loadOrderView()
        {

            dataGridView1.DataSource = bll.showOrders();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Eliminar")
            {

            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "Modificar")
            {

            }
        }
    }
}
