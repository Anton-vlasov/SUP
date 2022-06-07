using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using SUP.Validator;
using SUP.Validator.Models;

namespace ValidatorUnitTests
{
    [TestClass]
    public class ValidatorUnitTests
    {
        [TestMethod]
        public void Validator_ValidateProject_Empty_Failed()
        {
            //arrange
            String name = "";
            String description = "";
            Boolean assertResult = false;

            //act
            Result result = Validator.ValidateProject(name, description);

            //assert
            Assert.AreEqual(assertResult, result.IsSuccess);
        }

        [TestMethod]
        public void Validator_ValidateProject_NoEmpty_Success()
        {
            //arrange
            String name = "ТЭП70БС";
            String description = "Программа дисплейного модуля";
            Boolean assertResult = true;

            //act
            Result result = Validator.ValidateProject(name, description);

            //assert
            Assert.AreEqual(assertResult, result.IsSuccess);
        }

        [TestMethod]
        public void Validator_ValidateEmployee_Empty_Failed()
        {
            //arrange
            String firstName = "";
            String lastName = "";
            Object type = null;
            Boolean assertResult = false;

            //act
            Result result = Validator.ValidateEmployee(firstName, lastName, type);

            //assert
            Assert.AreEqual(assertResult, result.IsSuccess);
        }

        [TestMethod]
        public void Validator_ValidateEmployee_NotEmpty_Success()
        {
            //arrange
            String firstName = "Антон";
            String lastName = "Власов";
            Object type = new Object();
            Boolean assertResult = true;

            //act
            Result result = Validator.ValidateEmployee(firstName, lastName, type);

            //assert
            Assert.AreEqual(assertResult, result.IsSuccess);
        }
        
        [TestMethod]
        public void Validator_ValidateVacation_Empty_Failed()
        {
            //arrange
            Guid employeeId = Guid.Empty;
            DateTime? dateStart = null;
            DateTime? dateEnd = null;
            Boolean assertResult = false;

            //act
            Result result = Validator.ValidateVacation(employeeId, dateStart, dateEnd);

            //assert
            Assert.AreEqual(assertResult, result.IsSuccess);
        }

        [TestMethod]
        public void Validator_ValidateVacation_NoEmpty_Success()
        {
            //arrange
            Guid employeeId = Guid.NewGuid();
            DateTime dateStart = DateTime.Now;
            DateTime dateEnd = DateTime.Now;
            Boolean assertResult = true;

            //act
            Result result = Validator.ValidateVacation(employeeId, dateStart, dateEnd);

            //assert
            Assert.AreEqual(assertResult, result.IsSuccess);
        }
    }
}
