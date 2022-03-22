using CarFleetManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarFleetManagement.Controllers
{
    public class CarOfUserController : Controller
    {
        // GET: CarOfUserController
        public ActionResult Index()
        {
            return View(new List<CarOfUser>());
        }

        // GET: CarOfUserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
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

        // GET: CarOfUserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CarOfUserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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
