using System.Windows.Forms;
using BLL;

namespace View.Presentacion
{
    public partial class Customer : Form
    {

        private BusinessLogicLayer bll = new BusinessLogicLayer();
private ClientBLL clientBLL=new ClientBLL();
        public Customer()
        {
            InitializeComponent();
            loadCustomerView();
        }

        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Modificar") {
                dataGridView1.CurrentRow.Selected = true;
                MessageBox.Show("Cliente a editar: \n" + dataGridView1.Rows[e.RowIndex].Cells["Nombre"].FormattedValue.ToString());
                string id = dataGridView1.Rows[e.RowIndex].Cells["Codigo Cliente"].FormattedValue.ToString();

                AddClient route = new AddClient(id);
                route.ShowDialog();

            }
        }

        public void loadCustomerView() {

            dataGridView1.DataSource = bll.showClients();

        }
    }
}
