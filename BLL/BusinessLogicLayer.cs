using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADL;


namespace BLL
{
    public class BusinessLogicLayer
    {

        private AccessDataLayer accessDataLayer = new AccessDataLayer();


        public void addClient(String name, String lastName1, String lastName2, String phoneNumber1, String phoneNumber2, String email) {

            accessDataLayer.addClientToDB(name, lastName1, lastName2, int.Parse(phoneNumber1), int.Parse(phoneNumber2), email);

        }

        public void addOrder(int orderID, String provider, String partyName, DateTime date, String linkProduct, String description, String annotation, double costPrice, double costSale)
        {

            accessDataLayer.addOrderToDB(orderID, provider, partyName, date, linkProduct, description, annotation, costPrice, costSale);

        }




    }
}
