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
    public class PeopleControllerTest
    {
        private PeopleController controller;
        private Mock<GeneralService> mockService;

        [SetUp]
        public void Setup()
        {
            mockService = new Mock<GeneralService>();
            controller = new PeopleController(mockService.Object);
        }

        [Test]
        public void ListPeopleTest()
        {
            List<People> entitys = new List<People>();
            entitys.Add(new People { id = 1, name = "Test" });
            entitys.Add(new People { id = 2, name = "Test2" });
            mockService.Setup(p => p.ListPeople(It.IsAny<int?>())).Returns(entitys);

            var result = controller.ListPeople(1);            

            Assert.AreEqual(result.Count, 2);
            Assert.Pass();
        }

        [Test]
        public void GetPeopleById()
        {
            People entity = new People();
            entity.id = 5;
            entity.name = "Pepito";
            mockService.Setup(p => p.GetPeople(It.IsAny<int>())).Returns(entity);

            var result = controller.GetPeople(5);

            Assert.AreEqual(result.name, "Pepito");
            Assert.Pass();
        }

    }
}
