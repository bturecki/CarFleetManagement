using CarFleetManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static DataLibrary.BusinessLogic.PersonProcessor;

namespace CarFleetManagement.Controllers
{
    public class UserController : Controller
    {
        User GetUser(int id)
        {
            var item = LoadPeople().Where(x => x.UserId == id).Single();
            return new User() { Id = item.UserId, Name = item.Name, Surname = item.Surname, DateOfBirth = item.DateOfBirth, Email = item.Email, IsAdmin = item.IsAdmin };

        }
        public ActionResult Index()
        {
             var list = new List<User>();
             foreach (var item in LoadPeople())
                 list.Add(GetUser(item.UserId));
             return View(list);
        }

        public ActionResult Details(int id)
        {
            return View(GetUser(id));
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
                CreatePerson(collection["Name"], collection["Surname"], Convert.ToDateTime(collection["DateOfBirth"]), collection["Email"], collection["IsAdmin"].Contains("true"));
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            return View(GetUser(id));
        }

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

        public ActionResult Delete(int id)
        {
            DeletePerson(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
