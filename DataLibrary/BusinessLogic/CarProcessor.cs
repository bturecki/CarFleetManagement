using DataLibrary.DataAccess;
using DataLibrary.Models.Abstract;
using DataLibrary.Models.Entities;

namespace DataLibrary.BusinessLogic
{
    public class CarProcessor
    {
        public static int CreateCar(string make, string model, int yearOfProduction, int milage)
        {
            Car data = new Car() { Make = make, Model = model, YearOfProduction = yearOfProduction, Milage = milage };

            string sql = @"insert into dbo.T_Car (Make, Model, YearOfProduction) values (@Make, @Model, @YearOfProduction);";

            var res = SqlDataAccess.SaveData(sql, data);

            var insertedCar = LoadCars().Select(x => x.CarId).Max();

            InsertCarMilage(insertedCar, milage);

            return res;
        }
        public static int UpdateCar(int id, string make, string model, int yearOfProduction, int milage)
        {
            char br = Convert.ToChar("'");
            string sql = $"update dbo.T_Car set make = {br + make + br}, model = {br + model + br}, YearOfProduction = {yearOfProduction} where CarId = {id};";

            var updRes = SqlDataAccess.UpdateData(sql);

            var car = LoadCars().Where(x => x.CarId == id && x.Milage < milage).SingleOrDefault();

            if (car != default)
                InsertCarMilage(id, milage);

            return updRes;
        }
        private static int InsertCarMilage(int carId, int milage)
        {
            Car data = new Car() { CarId = carId, Milage = milage, IDate = DateTime.Now };

            string sql = @"insert into dbo.T_Car_Milage_Logs (CarId, milage) values (@CarId, @Milage);";

            return SqlDataAccess.SaveData(sql, data);
        }
        public static List<ICar> LoadCars()
        {
            var returnList = new List<ICar>();
            string sql = "select t.CarId, t.Make, t.Model, t.YearOfProduction, max(m.milage) Milage from dbo.T_Car t left join dbo.T_Car_Milage_Logs m on t.CarId = m.CarId group by t.CarId, t.Make, t.Model, t.YearOfProduction;";
            foreach (var us in SqlDataAccess.LoadData<Car>(sql))
                returnList.Add(us);
            return returnList;
        }

        public static int DeleteCar(int id)
        {
            string sql = $"delete dbo.T_Car where CarId = {id};";

            return SqlDataAccess.DeleteData(sql);
        }
    }
}
