using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LenaProject.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Lütfen Kullanıcı adını giriniz")]
        [Display(Name ="Kullanıcı Adı")    ]
        public string UserName { get; set; }

        [Required(ErrorMessage ="Lütfen şifrenizi giriniz")]
        [Display(Name ="Şifre")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}