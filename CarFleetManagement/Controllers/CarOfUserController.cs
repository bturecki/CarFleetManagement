using CarFleetManagement.Models;
using Microsoft.AspNetCore.Mvc;
using static DataLibrary.BusinessLogic.CarOfUserProcessor;

namespace CarFleetManagement.Controllers
{
    public class CarOfUserController : Controller
    {
        CarOfUser GetCarOfUser(int id)
        {
            var item = LoadCars().Where(x => x.CarId == id).Single();
            return new CarOfUser(item.RowId, item.UserId, item.CarId, $"{item.Name} {item.Surname}", $"{item.Make} {item.Model} {item.YearOfProduction}", 0, item.Email);
        }
        // GET: CarOfUserController
        public ActionResult Index()
        {
            var list = new List<CarOfUser>();
            foreach (var item in LoadCars())
                list.Add(GetCarOfUser(item.CarId));
            return View(list);
        }

        // GET: CarOfUserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarOfUserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CarOfUserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CarOfUserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
