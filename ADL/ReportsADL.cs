using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADL
{
    public class ReportsADL
    {

        private ConectionADL conectionADL = new ConectionADL();
        private MySqlConnection conection;

        public List<string> getStatusValuesFromDB() {

            try
            {
                conection = conectionADL.GetConnection();
                conection.Open();

                string storedProcedure = "showStatusProcedure";
                MySqlCommand cmd = new MySqlCommand(storedProcedure, conection);
                cmd.CommandType = CommandType.StoredProcedure;


                MySqlDataReader rdr = cmd.ExecuteReader();

                DataSet ds = new DataSet();
                DataTable dataTable = new DataTable();


                ds.Tables.Add(dataTable);
                ds.EnforceConstraints = false;
                dataTable.Load(rdr);

                List<string> listOfStatusValues = new List<string>();

                foreach (DataRow row in dataTable.Rows) {

                    listOfStatusValues.Add(row["Estatus"].ToString());

                }

                conection.Close();
                return listOfStatusValues;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new List<string>();
            }

        }


        public DataTable totalCostsYear()
        {


            try
            {
                conection = conectionADL.GetConnection();
                conection.Open();

                string storedProcedure = "totalCosts_procedure";
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



    }


}
