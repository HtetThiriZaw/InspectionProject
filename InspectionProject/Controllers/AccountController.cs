using InspectionProject.Helpers;
using InspectionProject.Models;
using System.Web.Mvc;

namespace InspectionProject.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {
            SessionHelper.ClearOnLogin();

            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                // Save username to session
                SessionHelper.Username = loginViewModel.Username;

                return RedirectToAction("Index", "Inspection");
            }

            // If not valid, just return view with errors
            return View();
        }
    }
}