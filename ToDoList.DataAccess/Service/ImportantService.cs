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
    public class ImportantService : IImportantService
    {
        private readonly ApplicationDbContext _db;

        public ImportantService(ApplicationDbContext db)
        {
            _db = db;
        }


        public void AddImportant(ImportantViewModel viewModel)
        {
            Important important = new Important()
            {
                Date = DateTimeGenerator.GetShamsiDate(),
                IsActive = false,
                Name = viewModel.Name,
                Id = CodeGenerators.GetId()
            };
            _db.Importants.Add(important);
            _db.SaveChanges();
        }

        public IEnumerable<Important> GetAll()
        {
            IEnumerable<Important> query = _db.Importants;
            return query.OrderBy(x => x.Date).ToList();
        }

        public Important GetFirstOrDefault(Expression<Func<Important, bool>> filter)
        {
            IQueryable<Important> query = _db.Importants;
            query = query.Where(filter);
            return query.FirstOrDefault();
        }

        public void UpdateImportant(Important important)
        {
            _db.Importants.Update(important);
            _db.SaveChanges();
        }

        public void Remove(Important entity)
        {
            _db.Importants.Remove(entity);
            _db.SaveChanges();
        }



    }
}
