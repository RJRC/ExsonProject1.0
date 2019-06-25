using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ADL
{
    public class ClientADL
    {

        private ConectionADL conectionADL = new ConectionADL();
        private MySqlConnection conection;


        public DataTable getClientsFromDB()
        {
            try
            {
                conection = conectionADL.GetConnection();
                conection.Open();

                string storedProcedure = "showClientsProcedure";
                MySqlCommand cmd = new MySqlCommand(storedProcedure, conection);
                cmd.CommandType = CommandType.StoredProcedure;

                MySqlDataReader rdr = cmd.ExecuteReader();

                DataSet ds = new DataSet();
                DataTable dataTable = new DataTable();

                ds.Tables.Add(dataTable);
                ds.EnforceConstraints = false;
                dataTable.Load(rdr);

                conection.Close();
                return dataTable;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new DataTable();
            }
        }


        
         public DataTable searchClientsInDB(string search)
        {
            try
            {
                conection = conectionADL.GetConnection();
                conection.Open();

                string storedProcedure = "searchClientProcedure";
                MySqlCommand cmd = new MySqlCommand(storedProcedure, conection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@searchVar", search);

                MySqlDataReader rdr = cmd.ExecuteReader();

                DataSet ds = new DataSet();
                DataTable dataTable = new DataTable();

                ds.Tables.Add(dataTable);
                ds.EnforceConstraints = false;
                dataTable.Load(rdr);

                conection.Close();
                return dataTable;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new DataTable();
            }
        }

        public bool deleteClientADL(int id)
        {
            try
            {
                conection = conectionADL.GetConnection();
                conection.Open();

                MySqlCommand cmd = new MySqlCommand("deleteClientProcedure", conection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idClient", id);

                MySqlDataReader rdr = cmd.ExecuteReader();

                conection.Close();
            }
            catch (Exception ex)
            { 
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return true;
        }

        public DataTable serchClientsInDB(int search)
        {


            try
            {
                conection = conectionADL.GetConnection();
                conection.Open();

                string storedProcedure = "searchIdClientProcedure";
                MySqlCommand cmd = new MySqlCommand(storedProcedure, conection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("_idParty", search);


                MySqlDataReader rdr = cmd.ExecuteReader();

                DataSet ds = new DataSet();
                DataTable dataTable = new DataTable();


                ds.Tables.Add(dataTable);
                ds.EnforceConstraints = false;
                dataTable.Load(rdr);

                conection.Close();
                return dataTable;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new DataTable();
            }

        }

        public void addOrEditClientToDB(String name, String lastName1, String lastName2, int phoneNumber1, int phoneNumber2, String email, int idParty)
        {

            try
            {
                conection = conectionADL.GetConnection();
                conection.Open();

                string storedProcedure = "AddOrEditClient";
                MySqlCommand cmd = new MySqlCommand(storedProcedure, conection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("_IdParty", idParty);

                cmd.Parameters.AddWithValue("_Name", name);

                cmd.Parameters.AddWithValue("_LastName1", lastName1);

                cmd.Parameters.AddWithValue("_LastName2", lastName2);

                cmd.Parameters.AddWithValue("_Telephone1", phoneNumber1);

                cmd.Parameters.AddWithValue("_Telephone2", phoneNumber2);

                cmd.Parameters.AddWithValue("_Email", email);

                MySqlDataReader rdr = cmd.ExecuteReader();


                conection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }


        }



    }
}
