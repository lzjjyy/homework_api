using homework_api.modules.login.daos;
using homework_api.modules.login.daos.impl;
using homework_api.modules.login.models.DTO;
using homework_api.modules.login.services;

using mdland_utils_lib.Config;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace homework_api.test.profile
{
    [TestFixture]
    public class OperationServiceTest
    {

        [SetUp]
        public void Setup()
        {
            Startup.AppName = "Test";
            ConfigFunction.InitByFilePath("appsettings.Development.json");
        }

        [TearDown]
        public void Close() {}

        [Test]
        public void Test1()
        {

        }

        [Test]
        public void TestXF()
        {
            TPercy MyCar = new TPercy(new TLocation('E', 'B', 10));
            MyCar.Move('F');
            Assert.IsTrue(MyCar.Location.X == 'C');
            //string a = "A";
            //string b = "A";
            //Assert.IsTrue(a == b);
        }

        [Test]
        public void TestXB()
        {
            TPercy MyCar = new TPercy(new TLocation('E', 'B', 10));
            MyCar.Move('B');
            Assert.IsTrue(MyCar.Location.X == 'A');
            //string a = "A";
            //string b = "A";
            //Assert.IsTrue(a == b);
        }

        [Test]
        public void TestL()
        {
            TPercy MyCar = new TPercy(new TLocation('E', 'B', 10));
            MyCar.Move('L');
            MyCar.Move('L');
            MyCar.Move('L');
            MyCar.Move('L');
            Assert.IsTrue(MyCar.Location.Face == 'E');
            //string a = "A";
            //string b = "A";
            //Assert.IsTrue(a == b);
        }
        [Test]
        public void TestR()
        {
            TPercy MyCar = new TPercy(new TLocation('E', 'B', 10));
            MyCar.Move('R');
            MyCar.Move('R');
            MyCar.Move('R');
            MyCar.Move('R');
            Assert.IsTrue(MyCar.Location.Face == 'E');
            //string a = "A";
            //string b = "A";
            //Assert.IsTrue(a == b);
        }

        [Test]
        public void TestYF()
        {
            TPercy MyCar = new TPercy(new TLocation('E', 'B', 10));
            MyCar.Move('R');
            MyCar.Move('F');
            Assert.IsTrue(MyCar.Location.Y==11);
            //string a = "A";
            //string b = "A";
            //Assert.IsTrue(a == b);
        }
        [Test]
        public void TestYB()
        {
            TPercy MyCar = new TPercy(new TLocation('E', 'B', 10));
            MyCar.Move('R');
            MyCar.Move('B');
            Assert.IsTrue(MyCar.Location.Y == 9);
            //string a = "A";
            //string b = "A";
            //Assert.IsTrue(a == b);
        }
    }


}