using System;
using System.Collections.Generic;
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
            return new OrderADL().getOrdersFromDB();
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
        public void addOrder(string orderID, String provider, String partyName, DateTime date, String linkProduct, String description, String annotation, double costPrice, double costSale, string status)
        {
            OrderADL orderADL = new OrderADL();
            int intStatus = 0;
            if (status.Equals(""))
            {
                intStatus = 1;
            }
            else
            {  

                intStatus = convertStatusToInt(status);

            }

            orderADL.addOrderToDB(orderID, provider, intStatus, partyName, date, linkProduct, description, annotation, costPrice, costSale);

        }

        /// <summary>
        /// The convertStatusToInt method
        /// Convert a status into a number.
        /// </summary>
        /// <param name="status">
        /// This is the status to convert.
        /// </param>
        /// <returns>
        /// Number with status information.
        /// </returns>
        public int convertStatusToInt(string status) {
            int variable = 1;
            switch (status) {
                case "En Tránsito":
                    variable = 1;
                    break;
                case "Pendiente de Entrega":
                    variable = 2;
                    break;
                case "Entregada":
                    variable = 3;
                    break;
            }
            return variable;
        }

        /// <summary>
        /// The getStatusValuesWithoutTotal method 
        /// Get the status from the ReportsADL class.
        /// </summary>
        ///<return>
        /// Returns a list with the status information.
        ///</return>
        public List<string> getStatusValuesWithoutTotal()
        {

            return new OrderADL().getStatusValuesFromDBWithOutTotal();
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
        public void deleteOrderById(string idOrder)
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

        /// <summary>
        /// The checkOrderNumber method 
        /// Check if a orderNumber is in the database .
        /// </summary>
        ///<param name="orderNumber">
        /// This is the orderNumber to check.
        ///</param>
        public bool checkOrderNumber(string orderNumber)
        {
            DataTable dt = new OrderADL().getOrdersFromDB();
            try
            {
                foreach (DataRow dr in dt.Rows)
                {
                    string name = dr["N. Orden"].ToString();
                    if (name.Equals(orderNumber)) {
                        return true;
                    } 
                }
                return false;
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

    }
}
