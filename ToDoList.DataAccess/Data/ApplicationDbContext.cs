using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Model.Models;

namespace ToDoList.DataAccess.Data
{
    public class ApplicationDbContext :IdentityDbContext<Users>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base(options) 
        {
                
        }

        public DbSet<Work> Works { get; set; }
        public DbSet<Important> Importants { get; set; }
     
    }
}
