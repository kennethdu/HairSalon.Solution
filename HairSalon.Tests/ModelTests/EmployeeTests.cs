using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;

namespace HairSalon.Tests
{
    [TestClass]
    public class EmployeeTests : IDisposable
    {
        public EmployeeTests()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=kenneth_du_test;";
        }

        public void Dispose()
        {
            Employee.DeleteAll();
            Client.DeleteAll();
        }

        [TestMethod]
        public void GetAll_DBStartsEmpty_Empty()
        {
            //Arrange
            int count = Employee.GetAllEmployee().Count;

            //Assert
            Assert.AreEqual(0, count);
        }

        [TestMethod]
        public void Equals_TrueForSameName_Employee()
        {
            //Arrange
            Employee EmployeeOne = new Employee("Kenneth");
            Employee EmployeeTwo = new Employee("Kenneth");

            //Assert
            Assert.AreEqual(EmployeeOne, EmployeeTwo);
        }

        [TestMethod]
        public void Save_EmployeesSaveToDatabase_EmployeeList()
        {
            //Arrange
            Employee testEmployee = new Employee("Kenneth");
            testEmployee.Save();

            //Act
            List<Employee> result = Employee.GetAllEmployee();
            List<Employee> testlist = new List<Employee> { testEmployee };

            //Assert
            CollectionAssert.AreEqual(testlist, result);
        }

        [TestMethod]
        public void Save_AssignsIdToObject_id()
        {
            //Arrange
            Employee testEmployee = new Employee("Kenneth");
            testEmployee.Save();

            //Act
            Employee savedEmployee = Employee.GetAllEmployee()[0];

            int result = savedEmployee.GetEmployeeId();
            int testId = testEmployee.GetEmployeeId();

            //Assert 
            Assert.AreEqual(testId, result);
        }
        [TestMethod]
        public void Find_FindsEmployeeInDatabase_Employee()
        {
            //Arrange
            Employee testEmployee = new Employee("Kenneth");
            testEmployee.Save();

            //Act
            Employee result = Employee.Find(testEmployee.GetEmployeeId());

            //Assert

            Assert.AreEqual(testEmployee, result);

        }
    }
}