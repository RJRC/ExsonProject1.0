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

        MySqlConnection con = new MySqlConnection("server=localhost; user=root; Password=Kenny-n919; Database=compuelecta; Port=3306");


        public void addOrEditClientToDB(String name, String lastName1, String lastName2, int phoneNumber1, int phoneNumber2, String email, int idParty) {

            try
            {
                con.Open();

                string storedProcedure = "AddOrEditClient";
                MySqlCommand cmd = new MySqlCommand(storedProcedure, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("_IdParty", idParty);

                cmd.Parameters.AddWithValue("_Name", name);

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

        public DataTable serchClientsInDB(int search)
        {


            try
            {
                con.Open();

                string storedProcedure = "searchIdClientProcedure";
                MySqlCommand cmd = new MySqlCommand(storedProcedure, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("_idParty", search);


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


        public DataTable serchOrdersByID(string orderID)
        {


            try
            {
                con.Open();

                string storedProcedure = "searchOrderByID";
                MySqlCommand cmd = new MySqlCommand(storedProcedure, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@searchOrderID", orderID);


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
                
                Console.WriteLine("Este es el error: " + ex.ToString());
            }

           
        }


        public void addOrderToDB(int orderID, String provider, String partyName, DateTime date, String linkProduct, String description, String annotation, double costPrice, double costSale)
        {


            try
            {
                con.Open();

                string storedProcedure = "addNewOrder_procedure";
                MySqlCommand cmd = new MySqlCommand(storedProcedure, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("OrderIDAdd", orderID);

                cmd.Parameters.AddWithValue("ProviderNameAdd", provider);

                cmd.Parameters.AddWithValue("PartyNameAdd", partyName);

                cmd.Parameters.AddWithValue("OrderDateAdd", date);

                cmd.Parameters.AddWithValue("OrderLinkAdd", linkProduct);

                cmd.Parameters.AddWithValue("descriptionOrderAdd", description);

                cmd.Parameters.AddWithValue("AnnotationAdd", annotation);

                cmd.Parameters.AddWithValue("CostPriceAdd", costPrice);

                cmd.Parameters.AddWithValue("CostSaleAdd", costSale);

                MySqlDataReader rdr = cmd.ExecuteReader();


                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("El mega error: " + ex.ToString());
            }


        }



        



    }
}
