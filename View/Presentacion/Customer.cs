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
            bool b;
            b= clientBLL.deleteClientBLL(17);
            MessageBox.Show(b+"", b+"", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        public void loadCustomerView() {

            dataGridView1.DataSource = bll.showClients();

        }
    }
}
