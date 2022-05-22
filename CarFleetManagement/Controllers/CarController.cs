using CarFleetManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static DataLibrary.BusinessLogic.CarProcessor;

namespace CarFleetManagement.Controllers
{
    public class CarController : Controller
    {
        Car GetCar(int id)
        {
            var item = LoadCars().Where(x => x.CarId == id).Single();
            return new Car() { Id = item.CarId, Make = item.Make, Model = item.Model, Milage = item.Milage, YearOfProduction = item.YearOfProduction };
        }

        public ActionResult Index()
        {
            var list = new List<Car>();
            foreach (var item in LoadCars())
                list.Add(GetCar(item.CarId));
            return View(list);
        }

        public ActionResult Details(int id)
        {
            return View(GetCar(id));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            if (ModelState.IsValid)
            {
                CreateCar(collection["Make"], collection["Model"], Convert.ToInt32(collection["YearOfProduction"]), Convert.ToInt32(collection["Milage"]));
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            return View(GetCar(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            UpdateCar(id, collection["Make"], collection["Model"], Convert.ToInt32(collection["YearOfProduction"]), Convert.ToInt32(collection["Milage"]));
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Delete(int id)
        {
            DeleteCar(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
