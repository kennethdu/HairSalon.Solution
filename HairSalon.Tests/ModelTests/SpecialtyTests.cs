using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;

namespace HairSalon.Tests
{
    [TestClass]
    public class SpecialtyTests : IDisposable
    {
        public SpecialtyTests()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=kenneth_du_test;";
        }
        public void Dispose()
        {
            Employee.DeleteAll();
            Client.DeleteAll();
            Specialty.DeleteAll();
        }

        [TestMethod]
        public void GetAll_DBStartsEmpty_Empty()
        {
            //Arrange
            int count = Specialty.GetAll().Count;

            //Assert
            Assert.AreEqual(0, count);
        }

        [TestMethod]
        public void Equals_TrueForSameName_Specialty()
        {
            //Arrange
            Specialty SpecialtyOne = new Specialty("Fade", 0);
            Specialty SpecialtyTwo = new Specialty("Fade", 0);

            //Assert
            Assert.AreEqual(SpecialtyOne, SpecialtyTwo);
        }

        [TestMethod]
        public void Save_PatientsSaveToDatabase_PatientsList()
        {
            //Arrange
            Specialty testSpecialty = new Specialty("Fade", 0);
            testSpecialty.Save();

            //Act
            List<Specialty> result = Specialty.GetAll();
            List<Specialty> testlist = new List<Specialty> { testSpecialty };

            //Assert
            CollectionAssert.AreEqual(testlist, result);
        }

        [TestMethod]
        public void Save_AssignsIdToObject_id()
        {
            //Arrange
            Specialty testSpecialty = new Specialty("Fade", 0);
            testSpecialty.Save();

            //Act
            Specialty savedSpecialty = Specialty.GetAll()[0];

            int result = savedSpecialty.GetId();
            int testId = testSpecialty.GetId();

            //Assert 
            Assert.AreEqual(testId, result);
        }
        [TestMethod]
        public void Find_FindsSpecialtyInDatabase_Specialty()
        {
            //Arrange
            Specialty testSpecialty = new Specialty("Fade", 0);
            testSpecialty.Save();

            //Act
            Specialty result = Specialty.Find(testSpecialty.GetId());

            //Assert

            Assert.AreEqual(testSpecialty, result);

        }
    }
}