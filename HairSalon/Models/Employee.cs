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
        public string GetEmployee()
        {
            return _employeeName;
        }
        public int GetEmployeeId()
        {
            return _employeeId;
        }
        public override bool Equals(System.Object otherEmployee)
        {
            if (!(otherEmployee is Employee))
            {
                return false;
            }
            else
            {
                Employee newEmployee = (Employee) otherEmployee;
                bool idEquality = this.GetEmployeeId() == newEmployee.GetEmployeeId();
                bool nameEquality = this.GetEmployee() == newEmployee.GetEmployee();
                return (idEquality && nameEquality);
            }
        }
        public override int GetHashCode()
        {
            string allHash = this.GetEmployee();
            return allHash.GetHashCode();
        }
        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO employee (employee_name) VALUES (@name);";

            MySqlParameter name = new MySqlParameter();
            name.ParameterName = "@name";
            name.Value = this.GetEmployee();
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

            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM employee;";

            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
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
            cmd.CommandText = @"SELECT * FROM employee where employee_id = (@searchId);";

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
        public List<Client> GetClient()
        {
            List<Client> allEmployeeClient = new List<Client> {};
            MySqlConnection conn = DB.Connection();
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * from client WHERE employee_id = @employee_id;";

            MySqlParameter newEmployeeId = new MySqlParameter();
            newEmployeeId.ParameterName = "@employee_id";
            newEmployeeId.Value = this.GetEmployeeId();
            cmd.Parameters.Add(newEmployeeId);

            var rdr = cmd.ExecuteReader() as MySqlDataReader;
            int clientId = 0;
            string clientName = "";
            int clientEmployeeid = 0;

            while(rdr.Read())
            {
                clientId = rdr.GetInt32(0);
                clientName = rdr.GetString(1);
                clientEmployeeid = rdr.GetInt32(2);
                Client newClient = new Client(clientName, clientId, clientEmployeeid);
                allEmployeeClient.Add(newClient);
            }
          conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allEmployeeClient;
        }
        public static void DeleteAll()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM employee;";

            cmd.ExecuteNonQuery();
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }
    }
}
