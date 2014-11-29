using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcAppFindResource;
using MvcAppFindResource.Controllers;
using MvcAppFindResource.Models;

namespace MvcAppFindResource.Tests.Controllers
{
    [TestClass]
    public class ValuesControllerTest
    {
        [TestMethod]
        public void Get()
        {
            // Arrange
            ValuesController controller = new ValuesController();

            // Act
            var result = controller.Get();

            // Assert
            Assert.IsNotNull(result);
            //Assert.AreEqual(2, result.Count());
            //Assert.AreEqual("value1", result.ElementAt(0));
            //Assert.AreEqual("value2", result.ElementAt(1));
        }

        [TestMethod]
        public void GetById()
        {
            // Arrange
            var controller = new ValuesController();

            // Act
            var result = controller.Get("123456789");

            // Assert
            Assert.AreEqual(result.Id, 1);
        }
        /*
        [TestMethod]
        public void Post()
        {
            // Arrange
            ValuesController controller = new ValuesController();

            // Act
            controller.Post("value");

            // Assert
        }
        */
        [TestMethod]
        public void Insert()
        {
            // Arrange
            var controller = new ValuesController();

            // Act
            position pos = new position();
            pos.keyName = "123456780";
            pos.Lat = decimal.Parse("48.5121372");
            pos.Lng = decimal.Parse("-80.165364");
            pos.dateStamp = DateTime.Now;
            var result = controller.Insert(pos);

            // Assert
            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void Put()
        {
            // Arrange
            ValuesController controller = new ValuesController();

            // Act
            controller.Put(5, "value");

            // Assert
        }

        [TestMethod]
        public void Delete()
        {
            // Arrange
            ValuesController controller = new ValuesController();

            // Act
            controller.Delete(5);

            // Assert
        }
    }
}
