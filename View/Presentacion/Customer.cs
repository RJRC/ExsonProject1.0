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
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Modificar") {
                dataGridView1.CurrentRow.Selected = true;
                MessageBox.Show("Cliente a editar: \n" + dataGridView1.Rows[e.RowIndex].Cells["Nombre"].FormattedValue.ToString());
                String id = dataGridView1.Rows[e.RowIndex].Cells["Codigo Cliente"].FormattedValue.ToString();

                AddClient route = new AddClient(id);
                route.ShowDialog();
            }

            dataGridView1.Update();
            dataGridView1.Refresh();
            this.Refresh();
        }

        public void loadCustomerView() {

            dataGridView1.DataSource = bll.showClients();


        }
    }
}
