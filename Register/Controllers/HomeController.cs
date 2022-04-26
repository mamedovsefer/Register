using Register.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace Register.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Singin()
        {
            return View();
        }

        FUNCTIONEntities db = new FUNCTIONEntities();
        [HttpPost]
        public ActionResult Register(REGISTRATION user)
        {
            try
            {
                db.REGISTRATION.Add(user);
                db.SaveChanges();
                return RedirectToAction("Singin", "Home");

            }
            catch(Exception)
            {
                return ViewBag.Message("salam");
            }


        }
        [HttpPost]
        public ActionResult Singin(REGISTRATION us)
        {
            bool result = IsValid(us.EMAIL, us.PASSWORD);
            if (result)
            {
                return RedirectToAction("Index", "Home");

            }
            else
            {
                ViewBag.Message = "Login Failed";
                return View();
            }
            return View(us);
        }

        private bool IsValid(string email, string password)
        {
            bool IsValid = false;
            var user = db.REGISTRATION.FirstOrDefault(u => u.EMAIL == email);
            if (user != null)
            {
                if (user.PASSWORD == password)
                {
                    IsValid = true;
                }

            }
            return IsValid;
        }
    }
}