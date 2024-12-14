using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Model.Models;

namespace ToDoList.DataAccess.Interface
{
    public interface ITasksService
    {
         void AddTasks(Tasks entity);
         IEnumerable<Tasks> GetAll();
        Tasks GetFirstOrDefault(Expression<Func<Tasks,bool>>filter);
        void RemoveTasks(Tasks entity);
        void UpdateTasks(Tasks tasks);
    }
}
