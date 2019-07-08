using System;
using System.Windows.Forms;
using BLL;

namespace View.Presentacion
{
    /// <summary>
    /// The Home class 
    /// Contains all methods for the home in the View Layer.
    /// </summary>
    public partial class Home : Form
    {

        /// <summary>
        /// Variable with the instance of OrderBLL.
        /// </summary>
        private OrderBLL bll = new OrderBLL();

        /// <summary>
        /// Builder of Home class.
        /// </summary>
        public Home()
        {
            InitializeComponent();
            loadOrderView();
            txtFind.MaxLength = 30;
        }



        /// <summary>
        /// The loadOrderView method 
        /// Load the dataGridView1 with orders information.
        /// </summary>
        public void loadOrderView()
        {

            dataGridView1.DataSource = bll.showOrders();

        }

        /// <summary>
        /// The dataGridView1_CellContentClick method 
        /// Delete and Modify an order by id.
        /// </summary>
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
                    panelOrderUpdate.ShowDialog();
                    loadOrderView();
                }

            }
        }

        /// <summary>
        /// The txtFind_TextChanged method 
        /// Search orders.
        /// </summary>
        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            string textToSearch = txtFind.Text;

            if (!textToSearch.Equals("Buscar")) {
                dataGridView1.DataSource = bll.showSearchOrders(textToSearch);
            } 
        }

        /// <summary>
        /// The panel2_Paint method 
        /// 
        /// </summary>
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
