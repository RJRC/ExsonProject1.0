using MySql.Data.MySqlClient;

namespace ADL
{
    class ConectionADL
    {
        private string USER="root";
        //cesar
        private string PASSWORD= "Kenny-n919";
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
