using LenaProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LenaProject.Services
{
    public class UserServices
    {

        LenaProjectDBEntities_ db = new LenaProjectDBEntities_() ;

        public User LoginService(LoginModel login)
        {
            var result = db.Users.Where(a => a.UserName == login.UserName && a.Password == login.Password).FirstOrDefault();
            return result;
        }
    }


}