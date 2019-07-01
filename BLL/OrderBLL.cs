using System;
using System.Data;
using System.Windows.Forms;
using ADL;

namespace BLL
{

    /// <summary>
    /// The OrderBLL class 
    /// Contains all methods for the orders in the Business Logic Layer.
    /// </summary>
    public class OrderBLL
    {

        /// <summary>
        /// The showOrders method 
        /// Show the orders information.
        /// </summary>
        ///<return>
        /// Returns a datatable with the orders information.
        ///</return>
        public DataTable showOrders()
        {
            return new OrderADL().getOrderFromDB();
        }

        /// <summary>
        /// The showOrderByID method 
        /// Show the orders information by an ID.
        /// </summary>
        ///<return>
        /// Returns a datatable with the orders information.
        ///</return>
        ///<param name="orderID">
        /// This is the id of the client to search.
        ///</param>
        public DataTable showOrderByID(string orderID)
        {
            return new OrderADL().searchOrdersByID(orderID);
        }

        /// <summary>
        /// The addOrder method 
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
        public void addOrder(int orderID, String provider, String partyName, DateTime date, String linkProduct, String description, String annotation, double costPrice, double costSale, string status)
        {
            OrderADL orderADL = new OrderADL();
            int intStatus = 0;
            if (status.Equals(""))
            {
                intStatus = 1;
            }
            else
            {
                DataTable dataTableId = orderADL.getStatusIdADL(status);

                DataRow dataRow = dataTableId.Rows[0];

                // intStatus = orderADL.getStatusIdADL(status);   
            }

            orderADL.addOrderToDB(orderID, provider, intStatus, partyName, date, linkProduct, description, annotation, costPrice, costSale);

        }


        /// <summary>
        /// The showSearchOrders method 
        /// Show the search orders in the database.
        /// </summary>
        ///<return>
        /// Returns a datatable with the search orders information.
        ///</return>
        ///<param name="search">
        /// This is what the client wants to search.
        ///</param>
        public DataTable showSearchOrders(string search)
        {
            return new OrderADL().serchOrdersInDB(search);
        }


        /// <summary>
        /// The deleteOrderById method 
        /// Delete an order in the database.
        /// </summary>
        ///<param name="idOrder">
        /// This is the id of the order to delete.
        ///</param>
        public void deleteOrderById(int idOrder)
        {
            new OrderADL().deleteOrderByIdInDB(idOrder);
        }


        /// <summary>
        /// The getProviderBLL method 
        /// Get provider from the database.
        /// </summary>
        ///<return>
        /// Returns a datatable with the providers information.
        ///</return>
        private DataTable getProviderBLL()
        {
            DataTable providers = new DataTable();

            try
            {
                providers = new OrderADL().getProviderADL();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return providers;
        }


        /// <summary>
        /// The fillProviderComboBox method 
        /// Fill a comboBox with the provider information.
        /// </summary>
        ///<param name="comboBox">
        /// This is the comboBox to be fill.
        ///</param>
        public void fillProviderComboBox(ComboBox comboBox)
        {
            DataTable dt = getProviderBLL(); ;
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    comboBox.Items.Add(dt.Rows[i][1].ToString());
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// The showAllState method 
        /// Show the states from the database.
        /// </summary>
        ///<return>
        /// Returns a datatable with the states information.
        ///</return>
        public DataTable showAllState()
        {
            return new OrderADL().getAllState();
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
            return new OrderADL().totalOrdersByMonth();
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
            return new OrderADL().totalsales();
        }


        /// <summary>
        /// The getOrderWithFilter method 
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
        public DataTable getOrderWithFilter(DateTime startDate, DateTime finishDate, string status)
        {

            string newStartDate = startDate.Year + "-" + startDate.Month + "-" + startDate.Day;
            string newFinishDate = finishDate.Year + "-" + finishDate.Month + "-" + finishDate.Day;
            if (status.Equals("Todos"))
            {

                return new OrderADL().getOrderFromDBWithFilterWithOutStatus(newStartDate, newFinishDate);
            }
            else
            {
                return new OrderADL().getOrderFromDBWithFilter(newStartDate, newFinishDate, status);
            }
        }

        /// <summary>
        /// The showOrdersGeneral method 
        /// Show the general orders from the database.
        /// </summary>
        ///<return>
        /// Returns a datatable with the orders information.
        ///</return>
        public DataTable showOrdersGeneral()
        {
            return new OrderADL().getOrderGeneralReports();
        }


        /// <summary>
        /// The fillStatusComboBox method 
        /// Fill a comboBox with the status information.
        /// </summary>
        ///<param name="comboBox">
        /// This is the comboBox to be fill.
        ///</param>
        public void fillStatusComboBox(ComboBox comboBox)
        {
            DataTable dt = showAllState(); ;
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    comboBox.Items.Add(dt.Rows[i][1].ToString());
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// The countSalesBLL method 
        /// Count the sales.
        /// </summary>
        public DataTable countSalesBLL()
        {
            return new OrderADL().countSalesADL();

        }

        /// <summary>
        /// The costSalesBLL method 
        /// Cost of the sales.
        /// </summary>
        public DataTable costSalesBLL()
        {
            return new OrderADL().costSalesADL();

        }

    }
}
