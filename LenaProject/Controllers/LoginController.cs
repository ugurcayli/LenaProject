using LenaProject.Models;
using LenaProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LenaProject.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            if (Session["userId"] != null)
            {
                return RedirectToAction("Index", "Form");
            }
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Index(LoginModel model)
        {
            UserServices userServices = new UserServices();
            var user = userServices.LoginService(model);
            Session["userId"] = user.Id;
            if (user != null)
            {
                return RedirectToAction("Index", "Form");
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.RemoveAll();
            return RedirectToAction("Index", "Login");
        }
    }
}