using DataLibrary.DataAccess;
using DataLibrary.Models.Abstract;
using DataLibrary.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.BusinessLogic
{
    public class CarOfUserProcessor
    {
        public static List<ICarOfUser> LoadCars()
        {
            var returnList = new List<ICarOfUser>();
            string sql = "select t.id RowId, c.CarId, c.Make, c.Model,  c.YearOfProduction, u.UserId, u.Name, u.Surname, u.DateOfBirth, u.Email, u.IsAdmin from dbo.T_Car_Of_User t inner join dbo.T_Car c on t.CarId = c.CarId inner join dbo.T_User u on u.UserId = t.UserId;";
            foreach (var us in SqlDataAccess.LoadData<CarOfUser>(sql))
                returnList.Add(us);
            return returnList;
        }
    }
}
