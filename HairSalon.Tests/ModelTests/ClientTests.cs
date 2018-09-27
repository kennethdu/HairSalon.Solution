using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;

namespace HairSalon.Tests
{
    [TestClass]
    public class ClientTests : IDisposable
    {
        public ClientTests()
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
            int count = Client.GetAllClient().Count;

            //Assert
            Assert.AreEqual(0, count);
        }

        [TestMethod]
        public void Equals_TrueForSameName_Client()
        {
            //Arrange
            Client ClientOne = new Client("Kenneth", 1, 0);
            Client ClientTwo = new Client("Kenneth", 2, 0);

            //Assert
            Assert.AreEqual(ClientOne, ClientTwo);
        }

        [TestMethod]
        public void Save_PatientsSaveToDatabase_PatientsList()
        {
            //Arrange
            Client testClient = new Client("Kenneth", 1, 0);
            testClient.Save();

            //Act
            List<Client> result = Client.GetAllClient();
            List<Client> testlist = new List<Client> { testClient };

            //Assert
            CollectionAssert.AreEqual(testlist, result);
        }

        [TestMethod]
        public void Save_AssignsIdToObject_id()
        {
            //Arrange
            Client testClient = new Client("Kenneth", 1, 0);
            testClient.Save();

            //Act
            Client savedClient = Client.GetAllClient()[0];

            int result = savedClient.GetClientId();
            int testId = testClient.GetClientId();

            //Assert 
            Assert.AreEqual(testId, result);
        }
        [TestMethod]
        public void Find_FindsClientInDatabase_Client()
        {
            //Arrange
            Client testClient = new Client("Kenneth", 1, 0);
            testClient.Save();

            //Act
            Client result = Client.Find(testClient.GetClientId());

            //Assert

            Assert.AreEqual(testClient, result);

        }
    }
}