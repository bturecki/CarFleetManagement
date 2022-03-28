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
            string sql = "select Id, Make, Model, YearOfProduction from dbo.T_Car;";
            foreach (var us in SqlDataAccess.LoadData<CarOfUser>(sql))
                returnList.Add(us);
            return returnList;
        }
    }
}
