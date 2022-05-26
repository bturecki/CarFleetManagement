using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using static DataLibrary.BusinessLogic.PersonProcessor;

namespace CarFleetManagement
{
    public class MyBaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ViewBag.IsAdmin = LoadPeople().Where(x => x.Email == User.Identity.Name).SingleOrDefault()?.IsAdmin;
            ViewBag.Email = LoadPeople().Where(x => x.Email == User.Identity.Name).SingleOrDefault()?.Email;
            ViewBag.IsUserActive = LoadPeople().Where(x => x.Email == User.Identity.Name).SingleOrDefault() != default;
            base.OnActionExecuting(filterContext);
        }
    }
}
