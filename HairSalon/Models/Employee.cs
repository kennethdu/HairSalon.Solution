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
        private int GetEmployeeId()
        {
            return _employeeId;
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
        public static List<Employee> GetAllEmployee()
        {
            List<Employee> allEmployee = new List<Employee> {};
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * employee;";

            var rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
                int EmployeeId = rdr.GetInt32(0);
                string EmployeeName = rdr.GetString(1);
                Employee newEmployee = new Employee(EmployeeName, EmployeeId);
                allEmployee.Add(newEmployee);
            }

            conn.Close();
            if(conn != null)
            {
                conn.Dispose();
            }
            return allEmployee;
        }
        public static Employee Find(int id)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM employee where id = (@searchId);";

            MySqlParameter searchId = new MySqlParameter();
            searchId.ParameterName = "@searchId";
            searchId.Value = id;
            cmd.Parameters.Add(searchId);

            var rdr = cmd.ExecuteReader() as MySqlDataReader;
            int EmployeeId = 0;
            string EmployeeName = "";
            while(rdr.Read())
            {
                EmployeeId = rdr.GetInt32(0);
                EmployeeName = rdr.GetString(1);
            }
            Employee newEmployee = new Employee (EmployeeName, EmployeeId);
            
            conn.Close();
            if (conn!=null)
            {
                conn.Dispose();
            }
            return newEmployee;
        }
    }
}
