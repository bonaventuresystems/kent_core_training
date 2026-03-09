using Microsoft.VisualStudio.TestTools.UnitTesting;
using KentAPIs.Controllers;
using KentAPIs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KentAPIs.Controllers.Tests
{
    [TestClass()]
    public class EmpsControllerTests
    {
        EmpsController controller = new EmpsController();
        [TestMethod()]
        public void GetTest()
        {
            List<Emp> emps =  controller.Get().ToList();

            int expected = 1;
            int actual = emps.Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void AddTest()
        {
            int actual = controller.Add(10,20);

            int expected = 30;
            Assert.AreEqual(expected, actual);
        }
    }
}