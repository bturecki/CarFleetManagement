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
        public static int CreateCarOfUser(int carId, int userId)
        {
            CarOfUser data = new CarOfUser() { CarId = carId, UserId = userId};

            string sql = @"insert into dbo.T_Car_Of_user (UserId, CarId) values (@UserId, @CarId);";

            return SqlDataAccess.SaveData(sql, data);
        }
        public static List<ICarOfUser> LoadCars()
        {
            var returnList = new List<ICarOfUser>();
            string sql = "select t.id RowId, c.CarId, c.Make, c.Model, c.YearOfProduction, u.UserId, u.Name, u.Surname, u.DateOfBirth, u.Email, u.IsAdmin, max(m.milage) Milage from dbo.T_Car_Of_User t inner join dbo.T_Car c on t.CarId = c.CarId inner join dbo.T_User u on u.UserId = t.UserId left join dbo.T_Car_Milage_Logs m on t.CarId = m.CarId group by t.id, c.CarId, c.Make, c.Model, c.YearOfProduction, u.UserId, u.Name, u.Surname, u.DateOfBirth, u.Email, u.IsAdmin;";
            foreach (var us in SqlDataAccess.LoadData<CarOfUser>(sql))
                returnList.Add(us);
            return returnList;
        }
        public static int DeleteCarOfUser(int id)
        {
            string sql = $"delete dbo.T_Car_Of_user where Id = {id};";

            return SqlDataAccess.DeleteData(sql);
        }
    }
}
