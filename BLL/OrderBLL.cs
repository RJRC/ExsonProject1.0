using System;
using System.Data;
using ADL;

namespace BLL
{
   public  class OrderBLL
    {

        public DataTable showOrders()
        {
            return new OrderADL().getOrderFromDB();
        }

        public DataTable showSearchOrders(string search)
        {
            return new OrderADL().serchOrdersInDB(search);
        }

        public void deleteOrderById(int idOrder)
        {
            new OrderADL().deleteOrderByIdInDB(idOrder);
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
