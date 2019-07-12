using System;
using System.Windows.Forms;
using BLL;

namespace View.Presentacion
{
    /// <summary>
    /// The Customer class 
    /// Contains all methods for the Customer in the View Layer.
    /// </summary>
    public partial class Customer : Form
    {

        /// <summary>
        /// Variable with the instance of ClientBLL.
        /// </summary>
        private ClientBLL clientBLL=new ClientBLL();


        /// <summary>
        /// Builder of Customer class.
        /// </summary>
        public Customer()
        {
            InitializeComponent();
            txtFind.MaxLength = 30;
            loadCustomerView();
        }

        /// <summary>
        /// The loadCustomerView method 
        /// Load the dgvClients with customers information.
        /// </summary>
        private void loadCustomerView() {
            dgvClients.DataSource = clientBLL.showClients();
            //dgvClients.DataSource = clientBLL2.totalCostsYear();
        }


        /// <summary>
        /// The DgvClients_CellContentClick method 
        /// Delete and Modify a customer by id.
        /// </summary>
        private void DgvClients_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
                string id = dgvClients.Rows[e.RowIndex].Cells["Código"].FormattedValue.ToString();

                if (dgvClients.Columns[e.ColumnIndex].Name == "Edit")
                {
                    dgvClients.CurrentRow.Selected = true;

                    AddClient route = new AddClient(id);
                    route.ShowDialog();

                    loadCustomerView();

                }

                if (dgvClients.Columns[e.ColumnIndex].Name == "Delete")
                {
                    dgvClients.CurrentRow.Selected = true;

                    DialogResult dialogResult = MessageBox.Show("Está a punto de eliminar a " + dgvClients.Rows[e.RowIndex].Cells["Nombre"].FormattedValue.ToString() + ".\n" +
                        "¿Está seguro de que quiere continuar?", "¿Eliminar Cliente?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dialogResult == DialogResult.Yes)
                    {
                        if (clientBLL.deleteClientBLL(id))
                        {
                            loadCustomerView();
                            MessageBox.Show("Eliminado con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Ha ocurrido un problema, no se ha podido eliminar el cliente\nNo se puede eliminar un cliente asignado a una orden", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }

                }
            
        }

        /// <summary>
        /// The txtFind_TextChanged method 
        /// Search customers.
        /// </summary>
        private void txtFind_TextChanged(object sender, System.EventArgs e)
        {
            string textToSearch = txtFind.Text;

            if (!textToSearch.Equals("Buscar"))
            {
                dgvClients.DataSource = clientBLL.searchClients(textToSearch);
            }
        }

    }
}
