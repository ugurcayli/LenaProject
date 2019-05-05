using LenaProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LenaProject.Services
{
    public class UserServices
    {

        LenaProjectDBEntities db = new LenaProjectDBEntities() ;

        public bool LoginService(LoginModel login)
        {
            var result = db.Users.Where(a => a.UserName == login.UserName && a.Password == login.Password).FirstOrDefault();
            if (result!=null)
            {
                return true;
            }
            return false;
        }
    }


}