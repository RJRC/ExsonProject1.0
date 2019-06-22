using System;
using System.Data;
using System.Windows.Forms;
using ADL;

namespace BLL
{
   public  class OrderBLL
    {

        public DataTable showOrders()
        {
            return new OrderADL().getOrderFromDB();
        }

        public DataTable showOrderByID(string search)
        {
            return new OrderADL().serchOrdersByID(search);
        }

        public void addOrder(int orderID, String provider, String partyName, DateTime date, String linkProduct, String description, String annotation, double costPrice, double costSale)
        {

            new OrderADL().addOrderToDB(orderID, provider, partyName, date, linkProduct, description, annotation, costPrice, costSale);

        }

        public DataTable showSearchOrders(string search)
        {
            return new OrderADL().serchOrdersInDB(search);
        }

        public void deleteOrderById(int idOrder)
        {
            new OrderADL().deleteOrderByIdInDB(idOrder);
        }

        private DataTable getProviderBLL() {
            DataTable providers = new DataTable();

            try
            {
              providers= new OrderADL().getProviderADL();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return providers;
        }

        public void fillProviderComboBox(ComboBox comboBox) {
            DataTable dt = getProviderBLL(); ;
            try
            {
               for (int i=0; i<dt.Rows.Count;i++)
                {
                    comboBox.Items.Add(dt.Rows[i][1].ToString());
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void addOrder(int orderID, String provider, String partyName, DateTime date, String linkProduct, String description, String annotation, double costPrice, double costSale)
        {

            new OrderADL().addOrderToDB(orderID, provider, partyName, date, linkProduct, description, annotation, costPrice, costSale);

        }

        public void addOrder(int orderID, String provider, int state, String partyName, DateTime date, String linkProduct, String description, String annotation, double costPrice, double costSale)
        {

            new OrderADL().addOrderToDB(orderID, provider, state, partyName, date, linkProduct, description, annotation, costPrice, costSale);

        }

        public DataTable showOrderByID(string orderID)
        {

            return new OrderADL().serchOrdersByID(orderID);

        }

        public DataTable showAllState()
        {
            return new OrderADL().getAllState();
        }

        public DataTable totalOrdersByMonth()
        {
            return new OrderADL().totalOrdersByMonth();
        }

        public DataTable totalsales()
        {
            return new OrderADL().totalsales();
        }


        
    }
}
