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
        public Client(string newClient, int EmployeeId, int _clientId = 0)
        {
            _clientName = newClient;
            _employeeId = EmployeeId;
        }
        public int GetClientId()
        {
            return _clientId;
        }
        

    }
}
