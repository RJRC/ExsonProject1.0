using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADL
{
   public class OrderADL
    {
        private ConectionADL conectionADL = new ConectionADL();
        private MySqlConnection conection;

        public DataTable getOrderFromDB()
        {
            try
            {
                conection = conectionADL.GetConnection();
                conection.Open();

                string storedProcedure = "showOrdersProcedure";
                MySqlCommand cmd = new MySqlCommand(storedProcedure, conection);
                cmd.CommandType = CommandType.StoredProcedure;


                MySqlDataReader rdr = cmd.ExecuteReader();

                DataSet ds = new DataSet();
                DataTable dataTable = new DataTable();


                ds.Tables.Add(dataTable);
                ds.EnforceConstraints = false;
                dataTable.Load(rdr);

                conection.Close();
                return dataTable;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new DataTable();
            }


        }

        public DataTable serchOrdersInDB(string search)
        {
            try
            {
                conection = conectionADL.GetConnection();
                conection.Open();

                string storedProcedure = "searchOrderProcedure";
                MySqlCommand cmd = new MySqlCommand(storedProcedure, conection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@searchVar", search);


                MySqlDataReader rdr = cmd.ExecuteReader();

                DataSet ds = new DataSet();
                DataTable dataTable = new DataTable();


                ds.Tables.Add(dataTable);
                ds.EnforceConstraints = false;
                dataTable.Load(rdr);

                conection.Close();
                return dataTable;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new DataTable();
            }
        }

        public void deleteOrderByIdInDB(int idOrder)
        {
            try
            {
                conection = conectionADL.GetConnection();
                conection.Open();


                string storedProcedure = "deleteOrderByIdProcedure";
                MySqlCommand cmd = new MySqlCommand(storedProcedure, conection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idVar", idOrder);


                MySqlDataReader rdr = cmd.ExecuteReader();


                conection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
