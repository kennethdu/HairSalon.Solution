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

    }
}
