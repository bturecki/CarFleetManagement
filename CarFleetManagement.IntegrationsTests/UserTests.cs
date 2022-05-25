using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetManagement.IntegrationsTests
{
    internal class UserTests
    {
        [Test]
        public void Load_Users_ShouldNotBeNull()
        {
            var _list = DataLibrary.BusinessLogic.PersonProcessor.LoadPeople();
            Assert.That(_list, Is.Not.Null);
        }
        [Test]
        public void Add_User_ShouldAddUserToDatabase()
        {
            var _guid = new Random().Next();
            var _startCnt = DataLibrary.BusinessLogic.PersonProcessor.LoadPeople().Count();
            DataLibrary.BusinessLogic.PersonProcessor.CreatePerson("Test name " + _guid, "Test surname " + _guid, DateTime.Now, "Test email " + _guid, false);
            var _endCnt = DataLibrary.BusinessLogic.PersonProcessor.LoadPeople().Count();
            DataLibrary.BusinessLogic.PersonProcessor.DeletePerson(DataLibrary.BusinessLogic.PersonProcessor.LoadPeople().Where(x=>x.Name == "Test name " + _guid).Single().UserId);
            Assert.That(_endCnt - _startCnt, Is.EqualTo(1)); //added 1 row
        }
        [Test]
        public void Delete_User_ShouldDeleteUserFromDatabase()
        {
            var _guid = new Random().Next();
            DataLibrary.BusinessLogic.PersonProcessor.CreatePerson("Test name " + _guid, "Test surname " + _guid, DateTime.Now, "Test email " + _guid, false);
            var _startCnt = DataLibrary.BusinessLogic.PersonProcessor.LoadPeople().Count();
            DataLibrary.BusinessLogic.PersonProcessor.DeletePerson(DataLibrary.BusinessLogic.PersonProcessor.LoadPeople().Where(x=>x.Name == "Test name " + _guid).Single().UserId);
            var _endCnt = DataLibrary.BusinessLogic.PersonProcessor.LoadPeople().Count();
            Assert.That(_endCnt - _startCnt, Is.EqualTo(-1)); //deleted 1 row
        }
    }
}
