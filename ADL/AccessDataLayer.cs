using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace ADL
{
    public class AccessDataLayer
    {

        MySqlConnection con = new MySqlConnection("server=localhost; user=root; Password=Tortuguero.2011.; Database=compuelecta; Port=3306");


        public void addOrEditClientToDB(String name, String lastName1, String lastName2, int phoneNumber1, int phoneNumber2, String email, int idParty) {

            try
            {
                con.Open();

                string storedProcedure = "AddOrEditClient";
                MySqlCommand cmd = new MySqlCommand(storedProcedure, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("_IdParty", idParty);

                cmd.Parameters.AddWithValue("_Name", idParty);

                cmd.Parameters.AddWithValue("_LastName1", lastName1);

                cmd.Parameters.AddWithValue("_LastName2", lastName2);

                cmd.Parameters.AddWithValue("_Telephone1", phoneNumber1);

                cmd.Parameters.AddWithValue("_Telephone2", phoneNumber2);

                cmd.Parameters.AddWithValue("_Email", email);

                MySqlDataReader rdr = cmd.ExecuteReader();
               

                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

           
        }

        public DataTable getClientsFromDB()
        {


            try
            {
                con.Open();

                string storedProcedure = "showClientsProcedure";
                MySqlCommand cmd = new MySqlCommand(storedProcedure, con);
                cmd.CommandType = CommandType.StoredProcedure;
                

                MySqlDataReader rdr = cmd.ExecuteReader();

                DataSet ds = new DataSet();
                DataTable dataTable = new DataTable();
              

                ds.Tables.Add(dataTable);
                ds.EnforceConstraints = false;
                dataTable.Load(rdr);

                con.Close();
                return dataTable;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new DataTable();
            }


        }


        public DataTable getOrderFromDB()
        {


            try
            {
                con.Open();

                string storedProcedure = "showOrdersProcedure";
                MySqlCommand cmd = new MySqlCommand(storedProcedure, con);
                cmd.CommandType = CommandType.StoredProcedure;


                MySqlDataReader rdr = cmd.ExecuteReader();

                DataSet ds = new DataSet();
                DataTable dataTable = new DataTable();


                ds.Tables.Add(dataTable);
                ds.EnforceConstraints = false;
                dataTable.Load(rdr);

                con.Close();
                return dataTable;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new DataTable();
            }


        }


        public DataTable serchOrdersInDB(string search)
        {


            try
            {
                con.Open();

                string storedProcedure = "searchOrderProcedure";
                MySqlCommand cmd = new MySqlCommand(storedProcedure, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@searchVar", search);


                MySqlDataReader rdr = cmd.ExecuteReader();

                DataSet ds = new DataSet();
                DataTable dataTable = new DataTable();


                ds.Tables.Add(dataTable);
                ds.EnforceConstraints = false;
                dataTable.Load(rdr);

                con.Close();
                return dataTable;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new DataTable();
            }


        }

        public void deleteOrderByIdInDB(int idOrder)
        {


            try
            {
                con.Open();

                string storedProcedure = "deleteOrderByIdProcedure";
                MySqlCommand cmd = new MySqlCommand(storedProcedure, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idVar", idOrder);


                MySqlDataReader rdr = cmd.ExecuteReader();


                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }


        }



    }
}
