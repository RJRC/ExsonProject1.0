using System;
using System.Collections.Generic;
using System.Data;
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


        public DataTable showClients() {
           return accessDataLayer.getClientsFromDB();
        }

        

        public DataTable showOrders()
        {
            return accessDataLayer.getOrderFromDB();
        }

    }
}
