using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace Forms_Hotel_System
{
    class Client
    {
        Connection conn = new Connection();

        // custom columns names
        const String ID = "Identity";
        const String FIRST_NAME = "First Name";
        const String LAST_NAME = "Last Name";
        const String PHONE = "Phone";
        const String COUNTRY = "Country";

        // CRUD commands
        const String SELECT_CLIENTS = "SELECT Id as '" + ID + "', firstname as '" + FIRST_NAME + "', lastname as '" + LAST_NAME + "', phone as '" + PHONE + "', country as '" + COUNTRY + "' FROM clients";
        const String INSERT_CLIENT = "INSERT INTO clients (firstname, lastname, phone, country) VALUES (@fn, @ln, @ph, @cnt);";
        const String UPDATE_CLIENT = "UPDATE clients SET firstname=@fn, lastname=@ln, phone=@ph, country=@cnt WHERE Id=@id";
        const String DELETE_CLIENT = "DELETE FROM clients WHERE Id=@id";

        // To Insert Client
        public bool insertClient(String fname, String lname, String phone, String country)
        {
            MySqlCommand command = new MySqlCommand();
            String insertQuery = INSERT_CLIENT;
            command.CommandText = insertQuery;
            command.Connection = conn.getConnection();

            command.Parameters.Add("@fn", MySqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@ln", MySqlDbType.VarChar).Value = lname;
            command.Parameters.Add("@ph", MySqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@cnt", MySqlDbType.VarChar).Value = country;

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
        // To Get Clients' List
        public DataTable getClients()
        {
            MySqlCommand command = new MySqlCommand(SELECT_CLIENTS, conn.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            DataTable table = new DataTable();

            adapter.SelectCommand = command;
            adapter.Fill(table);
            return table;
        }
        // To Edit Client
        public bool editClient(int id, String fname, String lname, String phone, String country)
        {
            MySqlCommand command = new MySqlCommand();
            String updateQuery = UPDATE_CLIENT;
            command.CommandText = updateQuery;
            command.Connection = conn.getConnection();

            command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            command.Parameters.Add("@fn", MySqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@ln", MySqlDbType.VarChar).Value = lname;
            command.Parameters.Add("@ph", MySqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@cnt", MySqlDbType.VarChar).Value = country;

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
        // To Delete Client
        public bool removeClient(int id)
        {
            MySqlCommand command = new MySqlCommand();
            String deleteQuery = DELETE_CLIENT;
            command.CommandText = deleteQuery;
            command.Connection = conn.getConnection();

            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;

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
/*
 *             //MySqlCommand command = new MySqlCommand("SELECT * FROM clients", conn.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM clients", conn.getConnection());
            DataSet DS = new DataSet();
            adapter.Fill(DS);

            //DataTable table = new DataTable();

            //adapter.SelectCommand = command;
            //adapter.Fill(table);
            //return new DataTable();
            return DS;
 */
