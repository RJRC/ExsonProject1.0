using System.Windows.Forms;
using BLL;

namespace View.Presentacion
{
    public partial class Customer : Form
    {

        //private BusinessLogicLayer bll = new BusinessLogicLayer();
        private ClientBLL clientBLL=new ClientBLL();
        public Customer()
        {
            InitializeComponent();
            loadCustomerView();
        }

        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string id = dataGridView1.Rows[e.RowIndex].Cells["Codigo Cliente"].FormattedValue.ToString();

            if (dataGridView1.Columns[e.ColumnIndex].Name == "Modificar") {
                dataGridView1.CurrentRow.Selected = true;
                MessageBox.Show("Cliente a editar: \n" + dataGridView1.Rows[e.RowIndex].Cells["Nombre"].FormattedValue.ToString());
                

                AddClient route = new AddClient(id);
                route.ShowDialog();

                loadCustomerView();

            }

            if (dataGridView1.Columns[e.ColumnIndex].Name == "Eliminar")
            {
                dataGridView1.CurrentRow.Selected = true;

                DialogResult dialogResult = MessageBox.Show("Está a punto de eliminar a " + dataGridView1.Rows[e.RowIndex].Cells["Nombre"].FormattedValue.ToString() + ".\n" +
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
                        MessageBox.Show("Ha ocurrido un problema, no se ha podido eliminar el cliente", "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                    
                }
            }
        }

        private void loadCustomerView() {
            dataGridView1.DataSource = clientBLL.showClients();
        }
    }
}
