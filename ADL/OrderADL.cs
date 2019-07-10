using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace ADL
{
    /// <summary>
    /// The OrderADL class 
    /// Contains all methods for the orders.
    /// </summary>
    public class OrderADL
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
        /// The getOrderFromDB method 
        /// Get the orders from the database.
        /// </summary>
        ///<return>
        /// Returns a datatable with the orders information.
        ///</return>
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
                Console.WriteLine(ex.ToString());
                return new DataTable();
            }


        }


        /// <summary>
        /// The serchOrdersInDB method 
        /// Search orders in the database.
        /// </summary>
        ///<return>
        /// Returns a datatable with the search orders information.
        ///</return>
        ///<param name="search">
        /// This is what the client wants to search.
        ///</param>
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


        /// <summary>
        /// The deleteOrderByIdInDB method 
        /// Delete an order in the database.
        /// </summary>
        ///<param name="id">
        /// This is the id of the order to delete.
        ///</param>
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


        /// <summary>
        /// The addOrderToDB method 
        /// Add an order in the database.
        /// </summary>
        ///<param name="orderID">
        /// This is the id of the order to add.
        ///</param>
        ///<param name="provider">
        /// This is the provider of the order to add.
        ///</param>
        ///<param name="partyName">
        /// This is the client name of the order to add.
        ///</param>
        ///<param name="date">
        /// This is the date of the order to add.
        ///</param>
        ///<param name="linkProduct">
        /// This is the linkq of the order to add.
        ///</param>
        ///<param name="description">
        /// This is the description of the order to add.
        ///</param>
        ///<param name="annotation">
        /// This is the annotation of the order to add.
        ///</param>
        ///<param name="costPrice">
        /// This is the cost of price of the order to add.
        ///</param>
        ///<param name="costSale">
        /// This is the cost of sale of the order to add.
        ///</param>
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

        /// <summary>
        /// The getProviderADL method 
        /// Get provider from the database.
        /// </summary>
        ///<return>
        /// Returns a datatable with the providers information.
        ///</return>
        public DataTable getProviderADL()
        {
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

                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dataTable;
        }


        /// <summary>
        /// The searchOrdersByID method 
        /// Search orders in the database.
        /// </summary>
        ///<return>
        /// Returns a datatable with the search orders information.
        ///</return>
        ///<param name="orderID">
        ///     This is the id of the client to search.
        ///</param>
        public DataTable searchOrdersByID(string orderID)
        {


            try
            {
                conection = conectionADL.GetConnection();
                conection.Open();

                string storedProcedure = "searchOrderByID";
                MySqlCommand cmd = new MySqlCommand(storedProcedure, conection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@searchOrderID", orderID);


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
        /// The getAllState method 
        /// Get the states from the database.
        /// </summary>
        ///<return>
        /// Returns a datatable with the states information.
        ///</return>
        public DataTable getAllState()
        {


            try
            {
                conection = conectionADL.GetConnection();
                conection.Open();

                string storedProcedure = "showStatusProcedure";
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
        /// The totalOrdersByMonth method 
        /// Get the total orders by Month from the database.
        /// </summary>
        ///<return>
        /// Returns a datatable with the Orders information.
        ///</return>
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


        /// <summary>
        /// The totalsales method 
        /// Get the total of sales from the database.
        /// </summary>
        ///<return>
        /// Returns a datatable with the total of sales information.
        ///</return>
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


        /// <summary>
        /// The getOrderFromDBWithFilter method 
        /// Get the orders from the database.
        /// </summary>
        ///<return>
        /// Returns a datatable with the orders information.
        ///</return>
        ///<param name="startDate">
        /// This is the start date to search.
        ///</param>
        ///<param name="finishDate">
        /// This is the finish date to search.
        ///</param>
        ///<param name="status">
        /// This is the status of order to search.
        ///</param>
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
                Console.WriteLine(ex.ToString());
                return new DataTable();
            }


        }

        /// <summary>
        /// The getOrderFromDBWithFilter method 
        /// Get the orders from the database.
        /// </summary>
        ///<return>
        /// Returns a datatable with the orders information.
        ///</return>
        ///<param name="startDate">
        /// This is the start date to search.
        ///</param>
        ///<param name="finishDate">
        /// This is the finish date to search.
        ///</param>
        public DataTable getOrderFromDBWithFilterWithOutStatus(string startDate, string finishDate)
        {
            try
            {
                conection = conectionADL.GetConnection();
                conection.Open();

                string storedProcedure = "showOrderFilterProcedureWithOutStatus";
                MySqlCommand cmd = new MySqlCommand(storedProcedure, conection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("startDate", startDate);

                cmd.Parameters.AddWithValue("finishDate", finishDate);



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
        /// The getStatusIdADL method 
        /// Get the status from the database.
        /// </summary>
        ///<return>
        /// Returns a datatable with the status information.
        ///</return>
        /// <param name="status">
        /// Status of the order.
        /// </param>
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


        /// <summary>
        /// The countSalesADL method 
        /// Count the sales from the database.
        /// </summary>
        ///<return>
        /// Returns a datatable with the sales information.
        ///</return>
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

        /// <summary>
        /// The costSalesADL method 
        /// Cost of the sales from the database.
        /// </summary>
        ///<return>
        /// Returns a datatable with the sales information.
        ///</return>
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

        /// <summary>
        /// the method firstOrderADL
        /// get the date of the first order in the DB
        /// </summary>
        /// <returns>
        /// returns a dataTable with the date of the oldest order in the DB
        /// </returns>
        public DataTable firstOrderADL()
        {
            try {
                conection = conectionADL.GetConnection();
                conection.Open();

                string storedProcedure = "firstOrderProcedure";
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
            
        }

        /// <summary>
        /// The getOrderGeneralReports method 
        /// Get the general orders from the database.
        /// </summary>
        ///<return>
        /// Returns a datatable with the general orders information.
        ///</return>
        public DataTable getOrderGeneralReports()
        {
            try
            {
                conection = conectionADL.GetConnection();
                conection.Open();

                string storedProcedure = "showGeneraOrdersProcedure";
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



    }

}

