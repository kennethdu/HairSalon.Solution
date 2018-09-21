using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using HairSalon;

namespace HairSalon.Models
{
    public class Employee
    {
        private string _employeeName;
        private int _employeeId;
        public Employee(string EmployeeName, int EmployeeId = 0)
        {
            _employeeName = EmployeeName;
            _employeeId = EmployeeId;
        }
        private string GetEmployee()
        {
            return _employeeName;
        }
        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO employee (name) VALUES (@name);";

            MySqlParameter name = new MySqlParameter();
            name.ParameterName = "@name";
            name.Value = this._employeeName;
            cmd.Parameters.Add(name);

            cmd.ExecuteNonQuery();
            _employeeId = (int)cmd.LastInsertedId;

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }


    }
}
