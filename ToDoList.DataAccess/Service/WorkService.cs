using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ToDoList.DataAccess.Data;
using ToDoList.DataAccess.Interface;
using ToDoList.Model.Models;
using ToDoList.Model.ViewModel;
using ToDoList.Utility;

namespace ToDoList.DataAccess.Service
{
    public class WorkService : IWorkService
    {
        private readonly ApplicationDbContext _db;

        public WorkService(ApplicationDbContext db)
        {
            _db = db;
        }

      
        public void AddWork(WorkViewModel viewModel)
        {
            Work work = new Work()
            {
                Date = DateTimeGenerator.GetShamsiDate(),
                IsActive = false,
                Name = viewModel.Name,
                Id = CodeGenerators.GetId()
            };
            _db.Works.Add(work);
            _db.SaveChanges();
        }

        public IEnumerable<Work> GetAll()
        {
           IEnumerable<Work> query = _db.Works;
            return query.OrderBy(x=> x.Date).ToList();
        }

        public Work GetFirstOrDefault(Expression<Func<Work, bool>> filter)
        {
           IQueryable<Work> query = _db.Works;
            query = query.Where(filter);
            return query.FirstOrDefault();
        }

        public void UpdateWork(Work work)
        {
            _db.Works.Update(work);
            _db.SaveChanges();
        }

        public void Remove(Work entity)
        {
           _db.Works.Remove(entity);
            _db.SaveChanges();
        }

      
      
    }
}
