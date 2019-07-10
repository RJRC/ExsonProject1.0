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
    /// <summary>
    /// The AddClient class 
    /// Contains all methods to add a client in the View Layer.
    /// </summary>
    public partial class AddClient : Form
    {


        /// <summary>
        /// Variable with the instance of ClientBLL.
        /// </summary>
        private ClientBLL clientBLL = new ClientBLL();

        /// <summary>
        /// Builder of AddClient class.
        /// </summary>
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

        /// <summary>
        /// Builder of AddClient class.
        /// </summary>
        /// <param name="id">
        /// This is the id of the client to add.
        /// </param>
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
            lbCodeText.Visible = true;
            lbTitle.Text = "Modificar Cliente";

            txtName.Text = dtcust.Rows[0]["Nombre"].ToString();
            txtLastName1.Text = dtcust.Rows[0][2].ToString();
            txtLastName2.Text = dtcust.Rows[0][3].ToString();
            txtPhone1.Text = dtcust.Rows[0]["Teléfono 1"].ToString();
            txtPhone2.Text = dtcust.Rows[0]["Teléfono 2"].ToString();
            txtMail.Text = dtcust.Rows[0]["Correo Electrónico"].ToString();

        }


        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            // Home route = new Home();
            //route.ShowDialog();
            this.Close();
        }


        /// <summary>
        /// The BtnSave_Click method 
        /// Add or Edit a client.
        /// </summary>
        private void BtnSave_Click(object sender, EventArgs e)
        {

            bool isOk=true;
            if (clientBLL.validationEmptyTxt(txtName.Text, txtLastName1.Text, txtLastName2.Text, txtPhone1.Text))
            {
                isOk = false;
                MessageBox.Show("Por favor ingrese todos los datos que se solicitan", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (txtPhone1.Text.Length < 8)
            {
                isOk = false;
                MessageBox.Show("Verificar campo obligatorio de teléfono 1", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else if (!txtPhone2.Text.Equals("") && !txtPhone2.Text.Equals("0"))
            {
                if (txtPhone2.Text.Length < 8)
                {
                    isOk = false;
                    MessageBox.Show("Verificar campo de teléfono 2, no es obligatorio, pero se esta intentando ingresar un formato incorrecto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else if (!txtMail.Text.Equals("") && !txtMail.Text.Equals("Sin Correo"))
            {
                if (!clientBLL.validationEmailFormat(txtMail.Text))
                {
                    isOk = false;
                    MessageBox.Show("El correo no es obligatorio, pero el formato es incorrecto.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
            }

            //if all validations are passed then save or modify the client
            if (isOk ){

                string id = idLbl.Text;
                string name = txtName.Text;
                string lastName = txtLastName1.Text;
                string lastName2 = txtLastName2.Text;

                string phoneNumber1 = txtPhone1.Text;
                string phoneNumber2 = txtPhone2.Text;

                string email = txtMail.Text;

                
                if (clientBLL.addOrEditClient(name, lastName, lastName2, phoneNumber1, phoneNumber2, email, id))
                {
                    this.Close();
                    if (idLbl.Text == "")
                    {
                        MessageBox.Show("Cliente agregado con éxito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Cliente modificado con éxito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
               
              
            }
        }


        /// <summary>
        /// The BtnCancel_Click method 
        /// Cancel add or edit a client.
        /// </summary>
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        /// <summary>
        /// The txtPhone1_KeyPress method 
        /// Validate the phone1.
        /// </summary>
        private void txtPhone1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        /// <summary>
        /// The txtPhone2_KeyPress method 
        /// Validate the phone2.
        /// </summary>
        private void txtPhone2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        /// <summary>
        /// The txtName_KeyPress method 
        /// Validate the name.
        /// </summary>
        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        /// <summary>
        /// The txtLastName1_KeyPress method 
        /// Validate the lastname1.
        /// </summary>
        private void txtLastName1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        /// <summary>
        /// The txtLastName2_KeyPress method 
        /// Validate the lastname2.
        /// </summary>
        private void txtLastName2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
    }
}
