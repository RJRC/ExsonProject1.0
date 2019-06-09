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


        public void addOrEditClien(String name, String lastName1, String lastName2, String phoneNumber1, String phoneNumber2, String email/*, String id*/) {

            int idParty = 0;

          /*  if (!id.Equals("0") && !id.Equals(""))
            {
                idParty = 0;
            }
            else {
                idParty = Int32.Parse(id);
            }*/

            accessDataLayer.addOrEditClientToDB(name, lastName1, lastName2, int.Parse(phoneNumber1), int.Parse(phoneNumber2), email, idParty);

        }


        public DataTable showClients() {
           return accessDataLayer.getClientsFromDB();
        }

        
        
        public DataTable showOrders()
        {
            return accessDataLayer.getOrderFromDB();
        }

        public DataTable showSearchOrders(string search)
        {
            return accessDataLayer.serchOrdersInDB(search);
        }

        public void deleteOrderById(int idOrder)
        {
            accessDataLayer.deleteOrderByIdInDB(idOrder);
        }


        

    }
}
