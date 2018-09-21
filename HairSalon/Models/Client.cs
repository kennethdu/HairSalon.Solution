using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using HairSalon;

namespace HairSalon.Models
{
    public class Client
    {
        private string _clientName;
        private int _clientId;
        private int _employeeId;
        public Client(string newClient, int EmployeeId, int ClientId = 0)
        {
            _clientName = newClient;
            _employeeId = EmployeeId;
            _clientId = ClientId;
        }
        public string GetClient()
        {
            return _clientName;
        }
        public int GetClientId()
        {
            return _clientId;
        }
        public int GetEmployeeId()
        {
            return _employeeId;
        }
        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO client (name) VALUES (@name);";

            MySqlParameter name = new MySqlParameter();
            name.ParameterName = "@name";
            name.Value = this._clientName;
            cmd.Parameters.Add(name);

            cmd.ExecuteNonQuery();
            _clientId = (int)cmd.LastInsertedId;

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }
        public static List<Client> GetAllClient()
        {
            List<Client> allClients = new List<Client> {};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM client;";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

            while(rdr.Read())
            {
                int clientId = rdr.GetInt32(0);
                string clientName = rdr.GetString(1);
                int employeeId = rdr.GetInt32(2);
                Client newClient = new Client(clientName, employeeId, clientId);
                allClients.Add(newClient);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allClients;
        }

    }
}
