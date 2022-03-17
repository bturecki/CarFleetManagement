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
    public class CarProcessor
    {
        public static int CreateCar(string make, string model, int yearOfProduction, int milage)
        {
            Car data = new Car() { Make = make, Model = model, YearOfProduction = yearOfProduction, Milage = milage };

            string sql = @"insert into dbo.T_Car (Make, Model, YearOfProduction) values (@Make, @Model, @YearOfProduction);";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static List<ICar> LoadCars()
        {
            var returnList = new List<ICar>();
            string sql = "select Id, Make, Model, YearOfProduction from dbo.T_Car;";
            foreach (var us in SqlDataAccess.LoadData<Car>(sql))
                returnList.Add(us);
            return returnList;
        }

        public static int DeleteCar(int id)
        {
            string sql = $"delete dbo.T_Car where id = {id};";

            return SqlDataAccess.DeleteData(sql);
        }
    }
}
