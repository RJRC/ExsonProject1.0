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

        public void addOrder(int orderID, String provider, String partyName, DateTime date, String linkProduct, String description, String annotation, double costPrice, double costSale,string status)
        {
            OrderADL orderADL = new OrderADL();
            int intStatus=0;
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

            orderADL.addOrderToDB(orderID, provider, intStatus ,partyName, date, linkProduct, description, annotation, costPrice, costSale);

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

                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        public DataTable countSalesBLL()
        {
            return new OrderADL().countSalesADL();

        }

        public DataTable costSalesBLL()
        {
            return new OrderADL().costSalesADL();

        }

        public DataTable getOrderWithFilter(DateTime startDate, DateTime finishDate, string status)
        {

            string newStartDate = startDate.Year + "-" + startDate.Month + "-" + startDate.Day;
            string newFinishDate = finishDate.Year + "-" + finishDate.Month + "-" + finishDate.Day;

            return new OrderADL().getOrderFromDBWithFilter(newStartDate, newFinishDate, status);
        }



    }
}
