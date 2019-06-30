using MySql.Data.MySqlClient;

namespace ADL
{
    class ConectionADL
    {
        private string USER="root";
      
        private string PASSWORD= "Tortuguero.2011.";
        private string SERVER= "localhost";
        private string PORT = "3306";
        private string DATA_BASE = "compuelecta";
        
        private MySqlConnection conection;

        public MySqlConnection GetConnection()
        {
            string stringConection;
            stringConection = "server = " + SERVER + "; user = " + USER + "; Password = " + PASSWORD + "; Database = "+DATA_BASE+"; Port =" + PORT;
            conection = new MySqlConnection(stringConection);
            return conection;
        }
    }
}
