using MySql.Data.MySqlClient;
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


namespace View
{
    public partial class AddClient : Form
    {


        //private BusinessLogicLayer businessLogicLayer = new BusinessLogicLayer();
        private ClientBLL clientBLL = new ClientBLL();

        public AddClient()
        {
            InitializeComponent();
        }

        public AddClient(string id)
        {

            DataTable dtcust = clientBLL.showSearchClients(id);

            InitializeComponent();
            

            idLbl.Text = id;
            txtName.Text = dtcust.Rows[0]["Nombre"].ToString();
            // txtLastName1.Text = dtcust.Rows[0]["Primer Apellido"].ToString();
            //txtLastName2.Text = dtcust.Rows[0]["Segundo Apellido"].ToString();

            txtLastName1.Text = dtcust.Rows[0][2].ToString();
            txtLastName2.Text = dtcust.Rows[0][3].ToString();
            txtPhone1.Text = dtcust.Rows[0]["Teléfono 1"].ToString();
            txtPhone2.Text = dtcust.Rows[0]["Teléfono 2"].ToString();
            txtMail.Text = dtcust.Rows[0]["Correo Electrónico"].ToString();
             
            
        }

       

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
           // Home route = new Home();
            //route.ShowDialog();
            this.Close();
        }

      

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }


        private void Label6_Click(object sender, EventArgs e)
        {

        }

        private void LbOrderNum_Click(object sender, EventArgs e)
        {

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {

            string id = idLbl.Text;
            string name = txtName.Text;
            string lastName = txtLastName1.Text;
            string lastName2 = txtLastName2.Text;

            string phoneNumber1 = txtPhone1.Text;
            string phoneNumber2 = txtPhone2.Text;

            string email = txtMail.Text;

            clientBLL.addOrEditClient(name, lastName, lastName2, phoneNumber1, phoneNumber2, email,id);

            this.Close();

            //Save Data Client

        }

        

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddClient_Load(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
