﻿//using System.Web.Mvc;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

//namespace ShishaKingdom.Tests.Controllers
//{
//    using Data.Contracts;
//    using Web.Controllers;

//    [TestClass]
//    public class HomeControllerTest
//    {
//        [TestMethod]
//        public void Index()
//        {
//            // Arrange
//            HomeController controller = new HomeController(IShishaKingdomData data);

//            // Act
//            ViewResult result = controller.Index() as ViewResult;

//            // Assert
//            Assert.IsNotNull(result);
//        }

//        [TestMethod]
//        public void About()
//        {
//            // Arrange
//            HomeController controller = new HomeController(IShishaKingdomData data);

//            // Act
//            ViewResult result = controller.About() as ViewResult;

//            // Assert
//            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
//        }

//        [TestMethod]
//        public void Contact()
//        {
//            // Arrange
//            HomeController controller = new HomeController(IShishaKingdomData data);

//            // Act
//            ViewResult result = controller.Contact() as ViewResult;

//            //// Assert
//            Assert.IsNotNull(result);
//        }
//    }
//}
