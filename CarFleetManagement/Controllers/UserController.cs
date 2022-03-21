﻿using CarFleetManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static DataLibrary.BusinessLogic.PersonProcessor;

namespace CarFleetManagement.Controllers
{
    public class UserController : Controller
    {
        // GET: UserController
        User GetUser(int id)
        {
            var item = LoadPeople().Where(x => x.Id == id).Single();
            return new User() { Id = item.Id, Name = item.Name, Surname = item.Surname, DateOfBirth = item.DateOfBirth, Email = item.Email, IsAdmin = item.IsAdmin };

        }
        public ActionResult Index()
        {
             var list = new List<User>();
             foreach (var item in LoadPeople())
                 list.Add(GetUser(item.Id));
             return View(list);
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View(GetUser(id));
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            if (ModelState.IsValid)
            {
                CreatePerson(collection["Name"], collection["Surname"], Convert.ToDateTime(collection["DateOfBirth"]), collection["Email"], collection["IsAdmin"].Contains("true"));
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(GetUser(id));
        }

        // POST: UserController/Edit/5
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

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            DeletePerson(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
