using CarFleetManagement.Models;
using Microsoft.AspNetCore.Mvc;
using static DataLibrary.BusinessLogic.CarOfUserProcessor;

namespace CarFleetManagement.Controllers
{
    public class CarOfUserController : MyBaseController
    {
        CarOfUser GetCarOfUser(int id)
        {
            var item = LoadCars().Where(x => x.CarId == id).Single();
            return new CarOfUser(item.RowId, item.UserId, item.CarId, $"{item.Name} {item.Surname}", $"{item.Make} {item.Model} {item.YearOfProduction}", item.Milage, item.Email);
        }

        public ActionResult Index()
        {
            var list = new List<CarOfUser>();
            foreach (var item in LoadCars())
                list.Add(GetCarOfUser(item.CarId));
            return View(list);
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
                CreateCarOfUser(Convert.ToInt32(collection["CarId"]), Convert.ToInt32(collection["UserId"]));
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            DeleteCarOfUser(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
