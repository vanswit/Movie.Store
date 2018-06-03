using MovieStore.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieStore.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Authenticate(string message = "")
        {
            return View(message);
        }

        [HttpPost]
        public ActionResult Authenticate(string username, string password)
        {
            CustomMembership membership = new CustomMembership();
            var IsLogonValid = membership.ValidateUser(username, password);

            if (IsLogonValid)
            {
                return RedirectToAction("Index", "Movie");
            }
            else return View("Authenticate", (object)"Login failed");
        }
    }
}