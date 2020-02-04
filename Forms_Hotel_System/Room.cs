using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Forms_Hotel_System
{
    class Room
    {
        Connection conn = new Connection();
        // To Get a List Of Room's Type
        public DataTable roomTypeList()
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM roomscategories", conn.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            return table;
        }
        // To Get Room By Type
        public DataTable roomByType(int type)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM rooms WHERE type=@tp and free='YES' ", conn.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            command.Parameters.Add("@tp", MySqlDbType.Int32).Value = type;
            //command.Parameters.Add("@fr", MySqlDbType.Int32).Value = free;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            return table;
        }
        // To Get Room's Type by the Room Number
        public int getRoomType(int number)
        {
            MySqlCommand command = new MySqlCommand("SELECT type FROM rooms WHERE free='YES' and number=@num ", conn.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            command.Parameters.Add("@num", MySqlDbType.Int32).Value = number;
            //command.Parameters.Add("@fr", MySqlDbType.Int32).Value = free;

            adapter.SelectCommand = command;
            adapter.Fill(table);
            try
            {
                return Convert.ToInt32(table.Rows[0][0].ToString());
            } catch(IndexOutOfRangeException)
            {
                return 0;
            }
        }
        // To Get Room's Type by the Room Number Without Free YES
        public int getRoomEditType(int number)
        {
            MySqlCommand command = new MySqlCommand("SELECT type FROM rooms WHERE number=@num ", conn.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            command.Parameters.Add("@num", MySqlDbType.Int32).Value = number;
            //command.Parameters.Add("@fr", MySqlDbType.Int32).Value = free;

            adapter.SelectCommand = command;
            adapter.Fill(table);
            try
            {
                return Convert.ToInt32(table.Rows[0][0].ToString());
            }
            catch (IndexOutOfRangeException)
            {
                return 0;
            }
        }
        // Gets All Rooms
        public DataTable getRooms()
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM rooms", conn.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            DataTable table = new DataTable();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            return table;
        }
        // To Set Room Free Yes or No
        public bool setRoomFree(int number, String YesNo)
        {
            MySqlCommand command = new MySqlCommand();
            String updateQuery = "UPDATE rooms SET free=@YesNo WHERE number=@nr";
            command.CommandText = updateQuery;

            command.Parameters.Add("@nr", MySqlDbType.Int32).Value = number;
            command.Parameters.Add("@YesNo", MySqlDbType.VarChar).Value = YesNo;

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
        // To Insert Room
        public bool insertRoom(int number, int type, String phone, String free)
        {
            MySqlCommand command = new MySqlCommand();
            String insertQuery = "INSERT INTO rooms VALUES(@nr, @rt, @ph, @fr);";
            command.CommandText = insertQuery;
            command.Connection = conn.getConnection();

            command.Parameters.Add("@nr", MySqlDbType.Int32).Value = number;
            command.Parameters.Add("@rt", MySqlDbType.Int32).Value = type;
            command.Parameters.Add("@ph", MySqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@fr", MySqlDbType.VarChar).Value = free;

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
        // To Get Edit Room
        public bool editRoom(int number, int type, String phone, String free)
        {
            MySqlCommand command = new MySqlCommand();
            String updateQuery = "UPDATE rooms SET type=@tp, phone=@ph, free=@fr WHERE number=@nr";
            command.CommandText = updateQuery;

            command.Parameters.Add("@nr", MySqlDbType.Int32).Value = number;
            command.Parameters.Add("@tp", MySqlDbType.Int32).Value = type;
            command.Parameters.Add("@ph", MySqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@fr", MySqlDbType.VarChar).Value = free;

            command.Connection = conn.getConnection();

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
        // To Remove Room
        public bool removeRoom(int id)
        {
            MySqlCommand command = new MySqlCommand();
            String deleteQuery = "DELETE FROM rooms WHERE number=@id";
            command.CommandText = deleteQuery;
            command.Connection = conn.getConnection();

            command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
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
    }
}
