using MySql.Data.MySqlClient;

namespace ADL
{
    /// <summary>
    /// The ConnectionADL class 
    /// Contains all methods to make a connection with the Database.
    /// </summary>
    class ConnectionADL
    {
        /// <summary>
        /// Variable with the user information of the database.
        /// </summary>
        private string USER = "root";

        /// <summary>
        /// Variable with the password information of the database.
        /// </summary>
        private string PASSWORD = "Tortuguero.2011.";

        /// <summary>
        /// Variable with the server information of the database.
        /// </summary>
        private string SERVER = "localhost";

        /// <summary>
        /// Variable with the port information of the database.
        /// </summary>
        private string PORT = "3306";

        /// <summary>
        /// Variable with the name of the database.
        /// </summary>
        private string DATA_BASE = "compuelecta";

        /// <summary>
        /// Variable with the connection of MySQL.
        /// </summary>
        private MySqlConnection connection;


        /// <summary>
        /// This method makes the connection with the Database.
        /// </summary>
        /// <returns>
        /// This method returns a success connection with the Database. 
        /// </returns>
        public MySqlConnection GetConnection()
        {
            string stringConection;
            stringConection = "server = " + SERVER + "; user = " + USER + "; Password = " + PASSWORD + "; Database = " + DATA_BASE + "; Port =" + PORT;
            connection = new MySqlConnection(stringConection);
            return connection;
        }
    }
}
