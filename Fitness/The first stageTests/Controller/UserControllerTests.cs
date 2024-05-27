using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace The_first_stage.Controller.Tests
{
    [TestClass()]
    public class UserControllerTests
    {

        [TestMethod()]
        public void SetNewUserDataTest()
        {
            // Arrenge
            var userName = Guid.NewGuid().ToString();
            var birthdate = DateTime.Now.AddYears (-18);
            var weight = 90;
            var height = 190;
            var gender = "man";
            var controller = new UserController(userName);

            //Act
            controller.SetNewUserData(gender, birthdate, weight, height);
            var controller2 = new UserController(userName);


            //Assert
            Assert.AreEqual(userName, controller2.CurrentUser.Name);
            Assert.AreEqual(birthdate, controller2.CurrentUser.Name);
            Assert.AreEqual(weight, controller2.CurrentUser.Name);
            Assert.AreEqual(height, controller2.CurrentUser.Name);
            Assert.AreEqual(gender, controller2.CurrentUser.Name);
        }

        [TestMethod()]
        public void SaveTest()
        {
            // Arrenge
            var userName = Guid.NewGuid().ToString();
            // Act 
            var controller = new UserController(userName);
            // Assert
            Assert.AreEqual(userName, controller.CurrentUser.Name);
        }
    }
}