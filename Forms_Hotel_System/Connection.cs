using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace Forms_Hotel_System
{
    class Connection
    {
        private MySqlConnection connection = new MySqlConnection("server=localhost;port=3307;userid=root;password=root;database=hotel");
         //MySqlConnection conn = null;
         public MySqlConnection getConnection()
        {
            return connection;
        }
        //Open connection
        public void openConnection()
        {
            if(connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
        }
        //Close connection
        public void closeConnection()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }
}
