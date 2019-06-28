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
            txtName.MaxLength = 20;
            txtLastName1.MaxLength = 20;
            txtLastName2.MaxLength = 20;
            txtPhone1.MaxLength = 8;
            txtPhone2.MaxLength = 8;
            txtMail.MaxLength = 50;
        }

        public AddClient(string id)
        {

            DataTable dtcust = clientBLL.showSearchClients(id);

            InitializeComponent();
            txtName.MaxLength = 20;
            txtLastName1.MaxLength = 20;
            txtLastName2.MaxLength = 20;
            txtPhone1.MaxLength = 8;
            txtPhone2.MaxLength = 8;
            txtMail.MaxLength = 50;

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


            if (clientBLL.validationEmptyTxt(txtName.Text, txtLastName1.Text, txtLastName2.Text, txtPhone1.Text))
            {
                MessageBox.Show("Por favor ingrese todos los datos que se solicitan", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {

                string id = idLbl.Text;
                string name = txtName.Text;
                string lastName = txtLastName1.Text;
                string lastName2 = txtLastName2.Text;

                string phoneNumber1 = txtPhone1.Text;
                string phoneNumber2 = txtPhone2.Text;

                string email = txtMail.Text;

                clientBLL.addOrEditClient(name, lastName, lastName2, phoneNumber1, phoneNumber2, email, id);

                this.Close();

                if (!clientBLL.validationEmailFormat(email))
                    MessageBox.Show("El formato del correo era dudoso", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                MessageBox.Show("Cliente agregado con exito", "Información" , MessageBoxButtons.OK, MessageBoxIcon.Information);
            }



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

        private void txtPhone1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtPhone2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
    }
}
