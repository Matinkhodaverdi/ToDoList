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
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
