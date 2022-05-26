using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetManagement.IntegrationsTests
{
    internal class CarOfUserTests
    {
        [Test]
        public void Load_CarsOfUsers_ShouldNotBeNull()
        {
            var _list = DataLibrary.BusinessLogic.CarOfUserProcessor.LoadCars();
            Assert.That(_list, Is.Not.Null);
        }
        [Test]
        public void Add_Wrong_WrongCarOfUser_ShouldThrowException()
        {
            Assert.Throws<SqlException>(() => DataLibrary.BusinessLogic.CarOfUserProcessor.CreateCarOfUser(-1, -1));
        }
    }
}
