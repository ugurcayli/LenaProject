using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LenaProject.Services
{
    public class FormServices
    {
        LenaProjectDBEntities_ db = new LenaProjectDBEntities_();
        public IEnumerable<Form> GetFormList()
        {
            var result = db.Forms.ToList();
            return result;
        }

        public void SaveForm(Form form)
        {
            db.Forms.Add(form);
            db.SaveChanges();
        }

        public Form GetById(int id)
        {
            var form = db.Forms.Where(a => a.Id == id).FirstOrDefault();
            return form;
        }

        public Form updateForm(Form form)
        {
            var currentForm = db.Forms.Where(a => a.Id == form.Id).FirstOrDefault();
            if (currentForm != null)
            {
                currentForm.Name = form.Name;
                currentForm.Description = form.Description;
                currentForm.CreatedAt = form.CreatedAt;
                currentForm.CreatedBy = form.CreatedBy;
                db.SaveChanges();
            }
            return currentForm;
        }

        public IEnumerable<Form> filter()
        {
            var result = db.Forms.ToList();
            return result;
        }

    }
}