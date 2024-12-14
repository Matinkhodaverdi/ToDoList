using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Model.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="وارد کردن ایمیل اجباری است")]
        [EmailAddress]
        [Display(Name = "ایمیل")]
        public string  Email { get; set; }

        [Required(ErrorMessage = "وارد کردن رمزعبور اجباری است")]
        [DataType(DataType.Password)]
        [Display(Name = "رمز عبور")]
        public string  Password { get; set; }

        [Display(Name = "مرا به خاطر بسپار?")]
        public bool RememberMe { get; set; }
    }
}
