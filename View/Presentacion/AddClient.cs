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

namespace View
{
    public partial class AddClient : Form
    {
        //Cadena de conexion a la base de datos
         String connectionString = @"server=localhost; port=3306; user id=root; password=Tortuguero.2011.; database=compuelecta;";
        
         MySqlConnection connection;

        int idParty = 0;


        public AddClient()
        {
            InitializeComponent();
            //Inizializar conexion
            connection = new MySqlConnection(connectionString);
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
            //Save Data Client

            //Abrir conexion
            connection.Open();
            //Seleccionar Stored y conexion
            MySqlCommand mySqlCom = new MySqlCommand("AddOrEditClient",connection);
            //Definir que se va a usar el stored
            mySqlCom.CommandType = CommandType.StoredProcedure;
            //Parametros recibe el stored procedure
            mySqlCom.Parameters.AddWithValue("_IdParty",idParty);
            mySqlCom.Parameters.AddWithValue("_Name", txtName.Text.Trim());
            mySqlCom.Parameters.AddWithValue("_LastName1", txtLastName1.Text.Trim());
            mySqlCom.Parameters.AddWithValue("_LastName2", txtLastName2.Text.Trim());
            mySqlCom.Parameters.AddWithValue("_Telephone1", Int32.Parse(txtPhone1.Text.Trim()));
            mySqlCom.Parameters.AddWithValue("_Telephone2", Int32.Parse(txtPhone2.Text.Trim()));
            mySqlCom.Parameters.AddWithValue("_Email", txtMail.Text.Trim());
            mySqlCom.ExecuteNonQuery();
            //Mensaje de completado
            MessageBox.Show("Cliente Guardado");
            this.Close();

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
