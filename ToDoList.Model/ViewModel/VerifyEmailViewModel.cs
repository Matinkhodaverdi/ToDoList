using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Model.ViewModel
{
    public class VerifyEmailViewModel
    {
        [Required(ErrorMessage = "وارد کردن ایمیل اجباری است")]
        [EmailAddress]
        [Display(Name = "ایمیل")]
        public string Email { get; set; }
    }
}
