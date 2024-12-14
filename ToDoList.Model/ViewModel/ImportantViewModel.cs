using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Model.ViewModel
{
    public class ImportantViewModel
    {
        [Display(Name = "کارمهم")]
        public string Name { get; set; }

        [Display(Name = "تاریخ")]
        public string Date { get; set; }

        [Display(Name = "فعال/غیرفعال")]
        public bool IsActive { get; set; }

        [Display(Name = "برگزیدگان")]
        public bool IsStar { get; set; }
    }
}
