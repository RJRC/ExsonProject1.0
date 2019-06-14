using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace ADL
{
    public class ClientADL
    {

        private ConectionADL conectionADL = new ConectionADL();
        private MySqlConnection conection;

        public Boolean deleteClientADL(int id)
        {
            try
            {
               conection= conectionADL.GetConnection();
               conection.Open();

                MySqlCommand cmd = new MySqlCommand("deleteClientProcedure", conection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idClient", id);

                MySqlDataReader rdr = cmd.ExecuteReader();

                conection.Close();

                return true;
            }
            catch (Exception ex)
            {
                ex.ToString();
                return false;
            }
            
        }
    }
}
