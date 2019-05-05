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
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Index(LoginModel model)
        {
            UserServices userServices = new UserServices();
            if (userServices.LoginService(model))
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}