using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace ADL
{
    public class AccessDataLayer
    {

        MySqlConnection con = new MySqlConnection("server=localhost; user=root; Password=Kenny-n919; Database=compuelecta; Port=3306");


        public void addClientToDB(String name, String lastName1, String lastName2, int phoneNumber1, int phoneNumber2, String email) {
            

            try
            {
                con.Open();

                string storedProcedure = "addClientProcedure";
                MySqlCommand cmd = new MySqlCommand(storedProcedure, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@nameVar", name);

                cmd.Parameters.AddWithValue("@lastName1Var", lastName1);

                cmd.Parameters.AddWithValue("@lastName2Var", lastName2);

                cmd.Parameters.AddWithValue("@phoneNumber1Var", phoneNumber1);

                cmd.Parameters.AddWithValue("@phoneNumber2Var", phoneNumber2);

                cmd.Parameters.AddWithValue("@emailVar", email);

                MySqlDataReader rdr = cmd.ExecuteReader();
               

                con.Close();
            }
            catch (Exception ex)
            {
                
                Console.WriteLine("Este es el error: " + ex.ToString());
            }

           
        }


        public void addOrderToDB(int orderID, String provider, String partyName, DateTime date, String linkProduct, String description, String annotation, double costPrice, double costSale)
        {


            try
            {
                con.Open();

                string storedProcedure = "addNewOrder_procedure";
                MySqlCommand cmd = new MySqlCommand(storedProcedure, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("OrderIDAdd", orderID);

                cmd.Parameters.AddWithValue("ProviderNameAdd", provider);

                cmd.Parameters.AddWithValue("PartyNameAdd", partyName);

                cmd.Parameters.AddWithValue("OrderDateAdd", date);

                cmd.Parameters.AddWithValue("OrderLinkAdd", linkProduct);

                cmd.Parameters.AddWithValue("descriptionOrderAdd", description);

                cmd.Parameters.AddWithValue("AnnotationAdd", annotation);

                cmd.Parameters.AddWithValue("CostPriceAdd", costPrice);

                cmd.Parameters.AddWithValue("CostSaleAdd", costSale);

                MySqlDataReader rdr = cmd.ExecuteReader();


                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("El mega error: " + ex.ToString());
            }


        }



    }
}
