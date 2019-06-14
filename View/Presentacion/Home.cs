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
                String id = dataGridView1.CurrentRow.Cells[2].Value.ToString();

                string message = "Desea Eliminar la Orden Numero: " + id + "?";
                string caption = "Eliminar Orden";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question);

                // If the yes button was pressed ...
                if (result == DialogResult.Yes)
                {
                    bll.deleteOrderById(int.Parse(id));
                    loadOrderView();
                }


            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "Modificar")
            {
                String id = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                string message = "Desea modificar la Orden Numero: " + id + "?";
                string caption = "Modificar Orden";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question);

                // If the yes button was pressed ...
                if (result == DialogResult.Yes)
                {
                    Add panelOrderUpdate = new Add(id);
                    panelOrderUpdate.Show();
                    loadOrderView();
                }

            }
        }

        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            string textToSearch = txtFind.Text;

            if (!textToSearch.Equals("Buscar")) {
                dataGridView1.DataSource = bll.showSearchOrders(textToSearch);
            } 
        }

    }
}
