using CarFleetManagement.Models;
using DataLibrary.Models.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static DataLibrary.BusinessLogic.CarProcessor;

namespace CarFleetManagement.Controllers
{
    public class CarController : MyBaseController
    {
        Car GetCar(int id)
        {
            ICar item = (LoadCars(ViewBag.IsAdmin, ViewBag.Email) as List<ICar>).Where(x => x.CarId == id).Single();
            return new Car() { Id = item.CarId, Make = item.Make, Model = item.Model, Milage = item.Milage, YearOfProduction = item.YearOfProduction };
        }

        public ActionResult Index()
        {
            var list = new List<Car>();
            foreach (ICar item in LoadCars(ViewBag.IsAdmin, ViewBag.Email))
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
