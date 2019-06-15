﻿using System;
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


        public void addOrEditClien(String name, String lastName1, String lastName2, String phoneNumber1, String phoneNumber2, String email, String id) {


            accessDataLayer.addOrEditClientToDB(name, lastName1, lastName2, int.Parse(phoneNumber1), int.Parse(phoneNumber2), email, int.Parse(id));

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
        

        public DataTable showOrderByID(string search)
        {
            return accessDataLayer.serchOrdersByID(search);
        }

        public DataTable showSearchClients(String search)
        {
            return accessDataLayer.serchClientsInDB(int.Parse(search));
        }

        public void deleteOrderById(int idOrder)
        {
            accessDataLayer.deleteOrderByIdInDB(idOrder);
        }

        public void addOrder(int orderID, String provider, String partyName, DateTime date, String linkProduct, String description, String annotation, double costPrice, double costSale)
        {

            accessDataLayer.addOrderToDB(orderID, provider, partyName, date, linkProduct, description, annotation, costPrice, costSale);

        }


        

    }
}
