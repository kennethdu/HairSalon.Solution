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
        }

    }
}
