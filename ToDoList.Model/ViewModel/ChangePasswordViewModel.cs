using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Model.ViewModel
{
    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "وارد کردن ایمیل اجباری است")]
        [EmailAddress]
        [Display(Name = "ایمیل")]
        public string Email { get; set; }

        [Required(ErrorMessage = "وارد کردن رمزعبور اجباری است")]
        [StringLength(40, MinimumLength = 8, ErrorMessage = "مقدار {0} نباید بیش تر از {1} کاراکتر باشد")]
        [DataType(DataType.Password)]
        [Compare("ConfirmNewPassword", ErrorMessage = "تکرار رمزعبور با رمزعبور مطابقت ندارد.")]
        [Display(Name = "رمز عبور جدید")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "وارد کردن تکرار رمزعبور اجباری است")]
        [DataType(DataType.Password)]
        [Display(Name ="تکرار رمزعبور جدید")]
        public string ConfirmNewPassword { get; set; }
    }
}
