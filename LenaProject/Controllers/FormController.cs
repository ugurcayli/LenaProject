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
        private static IEnumerable<Form> form;
        // GET: Form
        public ActionResult Index(int? filtered)
        {
            if (Session["userId"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            if (filtered != 1)
            {
                form = formServices.GetFormList();
            }
            return View(form);
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
        public ActionResult IndexResult(string searchString)
        {
            var forms = formServices.filter();
            if (!String.IsNullOrEmpty(searchString))
            {
                forms = forms.Where(s => s.Name.Contains(searchString));
            }

            form = forms.OrderBy(s => s.Name);

            return RedirectToAction("Index", "Form", new { filtered = 1 });
        }
    }
}