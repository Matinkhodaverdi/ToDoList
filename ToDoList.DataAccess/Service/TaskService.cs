using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ToDoList.DataAccess.Data;
using ToDoList.DataAccess.Interface;
using ToDoList.Model.Models;

namespace ToDoList.DataAccess.Service
{
    public class TasksService:ITasksService
    {
        private readonly ApplicationDbContext _db;

        public TasksService(ApplicationDbContext db)
        {
            _db = db;
        }

        public void AddTasks(Tasks entity)
        {
            _db.Taskes.Add(entity);
            _db.SaveChanges();
        }

        public IEnumerable<Tasks> GetAll()
        {
            IEnumerable<Tasks> query = _db.Taskes;
            return query.ToList();
        }

        public Tasks GetFirstOrDefault(Expression<Func<Tasks, bool>> filter)
        {
            IQueryable<Tasks> query = _db.Taskes;   
            query = query.Where(filter);
            return query.FirstOrDefault();
        }

        public void RemoveTasks(Tasks entity)
        {
           _db.Taskes.Remove(entity);
            _db.SaveChanges();
        }

        public void UpdateTasks(Tasks tasks)
        {
            _db.Taskes.Update(tasks);
            _db.SaveChanges();  
        }
    }
}
