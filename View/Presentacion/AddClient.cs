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
        public AddClient()
        {
            InitializeComponent();
        }

        private BusinessLogicLayer businessLogicLayer = new BusinessLogicLayer();

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
            string name = txtName.Text;
            string lastName = txtLastName1.Text;
            string lastName2 = txtLastName2.Text;

            string phoneNumber1 = txtPhone1.Text;
            string phoneNumber2 = txtPhone2.Text;

            string email = txtMail.Text;

            businessLogicLayer.addClient(name, lastName, lastName2, phoneNumber1, phoneNumber2, email);

            this.Close();

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
