using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace ADL
{
    public class OrderADL
    {
        private ConectionADL conectionADL = new ConectionADL();
        private MySqlConnection conection;

        public DataTable getOrderFromDB()
        {
            try
            {
                conection = conectionADL.GetConnection();
                conection.Open();

                string storedProcedure = "showOrdersProcedure";
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
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }


        }

        public DataTable serchOrdersInDB(string search)
        {
            try
            {
                conection = conectionADL.GetConnection();
                conection.Open();

                string storedProcedure = "searchOrderProcedure";
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

        public void deleteOrderByIdInDB(int idOrder)
        {
            try
            {
                conection = conectionADL.GetConnection();
                conection.Open();


                string storedProcedure = "deleteOrderByIdProcedure";
                MySqlCommand cmd = new MySqlCommand(storedProcedure, conection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idVar", idOrder);


                MySqlDataReader rdr = cmd.ExecuteReader();


                conection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public DataTable getStatusIdADL(string status)
        {
            try
            {
                conection = conectionADL.GetConnection();
                conection.Open();

                string storedProcedure = "getStatusId";
                MySqlCommand cmd = new MySqlCommand(storedProcedure, conection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@statusVar", status);


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

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }


        }

        public DataTable getProviderADL() {
            DataTable dataTable = new DataTable();
            try
            {
                conection = conectionADL.GetConnection();
                conection.Open();

                string storedProcedure = "getProviderProcedure";
                MySqlCommand cmd = new MySqlCommand(storedProcedure, conection);
                cmd.CommandType = CommandType.StoredProcedure;

                MySqlDataReader rdr = cmd.ExecuteReader();

                DataSet dataSet = new DataSet();
               
                dataSet.Tables.Add(dataTable);
                dataSet.EnforceConstraints = false;
                dataTable.Load(rdr);

                conection.Close();
            }
            catch (Exception ex)
            {

             MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            return dataTable;
        }

        public void addOrderToDB(int orderID, String provider, int status, String partyName, DateTime date, String linkProduct, String description, String annotation, double costPrice, double costSale)
        {
            try
            {
                conection = conectionADL.GetConnection();
                conection.Open();

                string storedProcedure = "addNewOrder_procedure";
                MySqlCommand cmd = new MySqlCommand(storedProcedure, conection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("OrderIDAdd", orderID);

                cmd.Parameters.AddWithValue("ProviderNameAdd", provider);

                cmd.Parameters.AddWithValue("PartyNameAdd", partyName);

                cmd.Parameters.AddWithValue("StateAdd", status);

                cmd.Parameters.AddWithValue("OrderDateAdd", date);

                cmd.Parameters.AddWithValue("OrderLinkAdd", linkProduct);

                cmd.Parameters.AddWithValue("descriptionOrderAdd", description);

                cmd.Parameters.AddWithValue("AnnotationAdd", annotation);

                cmd.Parameters.AddWithValue("CostPriceAdd", costPrice);

                cmd.Parameters.AddWithValue("CostSaleAdd", costSale);

                MySqlDataReader rdr = cmd.ExecuteReader();


                conection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        public DataTable serchOrdersByID(string orderID)
        {
            try
            {
                conection = conectionADL.GetConnection();
                conection.Open();

                string storedProcedure = "searchOrderByID";
                MySqlCommand cmd = new MySqlCommand(storedProcedure, conection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("searchOrderID", orderID);


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
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }


        public DataTable getAllState()
        {
            try
            {
                conection = conectionADL.GetConnection();
                conection.Open();

                string storedProcedure = "showAllState";
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
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }


        }


        public DataTable totalOrdersByMonth()
        {


            try
            {
                conection = conectionADL.GetConnection();
                conection.Open();

                string storedProcedure = "showOrdersByMonth";
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


        public DataTable totalsales()
        {

            try
            {
                conection = conectionADL.GetConnection();
                conection.Open();

                string storedProcedure = "totalSales_procedure";
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

        public DataTable countSalesADL()
        {
            try
            {
                conection = conectionADL.GetConnection();
                conection.Open();

                string storedProcedure = "countSales_procedure";
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
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        public DataTable costSalesADL()
        {
            try
            {
                conection = conectionADL.GetConnection();
                conection.Open();

                string storedProcedure = "costSales_procedure";
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
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }
            public DataTable getOrderFromDBWithFilter(string startDate, string finishDate, string status)
        {
            try
            {
                conection = conectionADL.GetConnection();
                conection.Open();

                string storedProcedure = "showOrderFilterProcedure";
                MySqlCommand cmd = new MySqlCommand(storedProcedure, conection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("startDate", startDate);

                cmd.Parameters.AddWithValue("finishDate", finishDate);

                cmd.Parameters.AddWithValue("statusToSearch", status);



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
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }


        }
    }

}



