﻿using CarFleetManagement.Models;
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
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            DeleteCarOfUser(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
