using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Forms_Hotel_System
{
    class Reservation
    {
        Connection conn = new Connection();

        // To Get a Client's List
        public DataTable roomClientList()
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM clients", conn.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            return table;
        }
        // To Get list of Room's Type
        public DataTable roomTypeList()
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM roomscategories", conn.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            return table;
        }
        // To Get Reservation's list
        public DataTable gettAllReserv()
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM reservations", conn.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            return table;
         }
        // To Insert Reservation
        public bool insertReserv(int roomNumber, int clientId, DateTime dateIn, DateTime dateOut)
        {
            MySqlCommand command = new MySqlCommand();
            String addReserv = "INSERT INTO reservations( roomNumber, clientId, dateIn, dateOut) VALUES( @rmNr, @ctId, @dIn, @dOut )";
            command.CommandText = addReserv;
            command.Connection = conn.getConnection();

            command.Parameters.Add("@rmNr", MySqlDbType.Int32).Value = roomNumber;
            command.Parameters.Add("@ctId", MySqlDbType.Int32).Value = clientId;
            command.Parameters.Add("@dIn", MySqlDbType.DateTime).Value = dateIn;
            command.Parameters.Add("@dOut", MySqlDbType.DateTime).Value = dateOut;

            conn.openConnection();

            if(command.ExecuteNonQuery() == 1)
            {
                conn.closeConnection();
                return true;
            }
            else
            {
                conn.closeConnection();
                return false;
            }
        }
        // To Edit Reservation
        public bool editReserv(int reservId, int roomNumber, int clientId, DateTime dateIn, DateTime dateOut)
        {
            MySqlCommand command = new MySqlCommand();
            String updateQuery = "UPDATE reservations SET roomNumber=@rmNr, clientId=@ctId, dateIn=@dIn, dateOut=@dOut WHERE reservId=@rvId";
            command.CommandText = updateQuery;

            command.Parameters.Add("@rvId", MySqlDbType.Int32).Value = reservId;
            command.Parameters.Add("@rmNr", MySqlDbType.Int32).Value = roomNumber;
            command.Parameters.Add("@ctId", MySqlDbType.Int32).Value = clientId;
            command.Parameters.Add("@dIn", MySqlDbType.DateTime).Value = dateIn;
            command.Parameters.Add("@dOut", MySqlDbType.DateTime).Value = dateOut;

            command.Connection = conn.getConnection();

            conn.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                conn.closeConnection();
                return true;
            }
            else
            {
                conn.closeConnection();
                return false;
            }
        }
        // To Remove Room
        public bool removeRoom(int id)
        {
            MySqlCommand command = new MySqlCommand();
            String deleteQuery = "DELETE FROM reservations WHERE reservId=@id";
            command.CommandText = deleteQuery;
            command.Connection = conn.getConnection();

            command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            conn.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                conn.closeConnection();
                return true;
            }
            else
            {
                conn.closeConnection();
                return false;
            }
        }
    }
}
