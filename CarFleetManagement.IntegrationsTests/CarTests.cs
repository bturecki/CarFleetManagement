using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetManagement.IntegrationsTests
{
    internal class CarTests
    {
        [Test]
        public void Load_Cars_ShouldNotBeNull()
        {
            var _list = DataLibrary.BusinessLogic.CarProcessor.LoadCars(true, string.Empty);
            Assert.That(_list, Is.Not.Null);
        }
        [Test]
        public void Add_Car_ShouldAddUserToDatabase()
        {
            var _guid = new Random().Next();
            var _startCnt = DataLibrary.BusinessLogic.CarProcessor.LoadCars(true, string.Empty).Count();
            DataLibrary.BusinessLogic.CarProcessor.CreateCar("Test make " + _guid, "Test model " + _guid, 2000, 5);
            var _endCnt = DataLibrary.BusinessLogic.CarProcessor.LoadCars(true, string.Empty).Count();
            DataLibrary.BusinessLogic.CarProcessor.DeleteCar(DataLibrary.BusinessLogic.CarProcessor.LoadCars(true, string.Empty).Where(x=>x.Make == "Test make " + _guid).Single().CarId);
            Assert.That(_endCnt - _startCnt, Is.EqualTo(1)); //added 1 row
        }
        [Test]
        public void Delete_Car_ShouldDeleteUserFromDatabase()
        {
            var _guid = new Random().Next();
            DataLibrary.BusinessLogic.CarProcessor.CreateCar("Test make " + _guid, "Test model " + _guid, 2000, 5);
            var _startCnt = DataLibrary.BusinessLogic.CarProcessor.LoadCars(true, string.Empty).Count();
            DataLibrary.BusinessLogic.CarProcessor.DeleteCar(DataLibrary.BusinessLogic.CarProcessor.LoadCars(true, string.Empty).Where(x=>x.Make == "Test make " + _guid).Single().CarId);
            var _endCnt = DataLibrary.BusinessLogic.CarProcessor.LoadCars(true, string.Empty).Count();
            Assert.That(_endCnt - _startCnt, Is.EqualTo(-1)); //deleted 1 row
        }
    }
}
