using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Model.Models
{
    public class Tasks
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name ="مقدار")]
        public string Content { get; set; }


        [Display(Name = "انجام شده")]
        public bool Done {  get; set; }
    }
}
