using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IndexCard;
using IndexCard.Controllers;
using Rhino.Mocks;
using IndexCard.Entities;
using IndexCard.Models;

namespace IndexCard.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {

        private IIndexCardRepo mokIndexCardRepo;

        [TestInitialize]
        public void TestInitialize()
        {
            mokIndexCardRepo = MockRepository.GenerateStub<IIndexCardRepo>();
        }


        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Spiel() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetQuestionAnswer()
        {
            var requiredKvp = new QnA()
            {
                Question = "TestQuestion",
                Answer = "TestAnswer"
            };

            // Arrange
            mokIndexCardRepo.Stub(m => m.GetQuestionAnswer()).Return(new KeyValuePair<string, string>(requiredKvp.Question, requiredKvp.Answer));

            var controller = new QnAsController(mokIndexCardRepo);
            ViewResult result = controller.IndexCardDisplay();
            var model = result.Model as QnA;

            Assert.AreEqual(requiredKvp.Question, model.Question);
            Assert.AreEqual(requiredKvp.Answer, model.Answer);
        }

    }
}
