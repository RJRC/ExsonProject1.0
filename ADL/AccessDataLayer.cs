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

        MySqlConnection con = new MySqlConnection("server=localhost; user=root; Password=root; Database=compuelecta; Port=3306");


        public void addClientToDB(String name, String lastName1, String lastName2, int phoneNumber1, int phoneNumber2, String email) {
            

            try
            {
                con.Open();

                string storedProcedure = "addClientProcedure";
                MySqlCommand cmd = new MySqlCommand(storedProcedure, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@nameVar", name);

                cmd.Parameters.AddWithValue("@lastName1Var", lastName1);

                cmd.Parameters.AddWithValue("@lastName2Var", lastName2);

                cmd.Parameters.AddWithValue("@phoneNumber1Var", phoneNumber1);

                cmd.Parameters.AddWithValue("@phoneNumber2Var", phoneNumber2);

                cmd.Parameters.AddWithValue("@emailVar", email);

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



    }
}
