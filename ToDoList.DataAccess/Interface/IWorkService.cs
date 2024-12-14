using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Model.Models;
using ToDoList.Model.ViewModel;

namespace ToDoList.DataAccess.Interface
{
    public interface IWorkService
    {
       
        void AddWork(Work entity);
        IEnumerable<Work> GetAll();
        Work GetFirstOrDefault(Expression<Func<Work, bool>> filter);
        void UpdateWork(Work work);
        void Remove(Work entity);
        
       
    }
}
