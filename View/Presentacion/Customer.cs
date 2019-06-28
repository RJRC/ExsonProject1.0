using System.Windows.Forms;
using BLL;

namespace View.Presentacion
{
    public partial class Customer : Form
    {

        private ClientBLL clientBLL=new ClientBLL();
        public Customer()
        {
            InitializeComponent();
            txtFind.MaxLength = 30;
            loadCustomerView();
        }

        private void loadCustomerView() {
            dgvClients.DataSource = clientBLL.showClients();
        }

        private void DgvClients_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string id = dgvClients.Rows[e.RowIndex].Cells["Codigo Cliente"].FormattedValue.ToString();

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
                        MessageBox.Show("Eliminado con éxito", "Éxito", MessageBoxButtons.OK);
                    }
                    else
                    {
                        MessageBox.Show("Ha ocurrido un problema, no se ha podido eliminar el cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
        }

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
