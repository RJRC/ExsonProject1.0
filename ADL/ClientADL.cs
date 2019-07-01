using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ADL
{

    /// <summary>
    /// The ClientADL class 
    /// Contains all methods for the clients.
    /// </summary>
    public class ClientADL
    {

        /// <summary>
        /// Variable with the instance of ConnectionADL.
        /// </summary>
        private ConnectionADL conectionADL = new ConnectionADL();

        /// <summary>
        /// Variable with the connection of MySQL.
        /// </summary>
        private MySqlConnection conection;


        /// <summary>
        /// The getClientsFromDB method 
        /// Get the clients from the database.
        /// </summary>
        ///<return>
        /// Returns a datatable with the clients information.
        ///</return>
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

        /// <summary>
        /// The searchClientsInDB method 
        /// Search clients in the database.
        /// </summary>
        ///<return>
        /// Returns a datatable with the search clients information.
        ///</return>
        ///<param name="search">
        /// This is what the client wants to search.
        ///</param>
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


        /// <summary>
        /// The deleteClientADL method 
        /// Delete a client in the database.
        /// </summary>
        ///<return>
        /// Returns true if client is delete with success and false if don´t.
        ///</return>
        ///<param name="id">
        /// This is the id of the client to delete.
        ///</param>
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
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }


        /// <summary>
        /// The searchClientsInDB method 
        /// Search clients in the database.
        /// </summary>
        ///<return>
        /// Returns a datatable with the search client information.
        ///</return>
        ///<param name="search">
        /// This is the id of the client to search.
        ///</param>
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



        /// <summary>
        /// The addOrEditClientToDB method 
        /// Add or Edit a client in the database.
        /// </summary>
        ///<param name="name">
        /// This is the name of the client to add or edit.
        ///</param>
        ///<param name="lastName1">
        /// This is the lastName1 of the client to add or edit.
        ///</param>
        ///<param name="lastName2">
        /// This is the lastName2 of the client to add or edit.
        ///</param>
        ///<param name="phoneNumber1">
        /// This is the phoneNumber1 of the client to add or edit.
        ///</param>
        ///<param name="phoneNumber2">
        /// This is the phoneNumber2 of the client to add or edit.
        ///</param>
        ///<param name="email">
        /// This is the email of the client to add or edit.
        ///</param>
        ///<param name="idParty">
        /// This is the id of the client to add or edit.
        ///</param>
        public void addOrEditClientInDB(String name, String lastName1, String lastName2,
                                        int phoneNumber1, int phoneNumber2, String email,
                                        int idParty)
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
