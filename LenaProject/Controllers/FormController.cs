using LenaProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LenaProject.Controllers
{
    public class FormController : Controller
    {
        FormServices formServices = new FormServices();

        // GET: Form
        public ActionResult Index()
        {
            if (Session["userId"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            var formList = formServices.GetFormList();
            return View(formList);
        }
        [HttpPost]
        public bool Index(Form formModel)
        {
            formModel.CreatedAt = DateTime.Now;
            formModel.CreatedBy = Int32.Parse(Session["userId"].ToString());
            formServices.SaveForm(formModel);
            return true;
        }
        public ActionResult Edit(int id)
        {
            var form = formServices.GetById(id);
            return View(form);
        }

        public ActionResult Update(Form newForm)
        {
            newForm.CreatedAt = DateTime.Now;
            newForm.CreatedBy = Int32.Parse(Session["userId"].ToString());
            var form = formServices.updateForm(newForm);
            return RedirectToAction("Index", "Form");
        }
    }
}