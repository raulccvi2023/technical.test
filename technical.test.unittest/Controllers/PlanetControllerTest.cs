using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using technical.test.Controllers;
using technical.test.Models;
using technical.test.Services;

namespace technical.test.unittest.Controllers
{
    public class PlanetControllerTest
    {
        private PlanetController controller;
        private Mock<GeneralService> mockService;

        [SetUp]
        public void Setup()
        {
            mockService = new Mock<GeneralService>();
            controller = new PlanetController(mockService.Object);
        }

        [Test]
        public void ListPeopleTest()
        {
            List<Planet> entitys = new List<Planet>();
            entitys.Add(new Planet { id = 1, name = "Test" });
            entitys.Add(new Planet { id = 2, name = "Test2" });
            mockService.Setup(p => p.ListPlanet(It.IsAny<int?>())).Returns(entitys);

            var result = controller.ListPlanets(1);

            Assert.AreEqual(result.Count, 2);
            Assert.Pass();
        }

        [Test]
        public void GetPeopleById()
        {
            Planet entity = new Planet();
            entity.id = 5;
            entity.name = "Jupiter";
            mockService.Setup(p => p.GetPlanet(It.IsAny<int>())).Returns(entity);

            var result = controller.GetPlanets(5);

            Assert.AreEqual(result.name, "Jupiter");
            Assert.Pass();
        }

    }
}
