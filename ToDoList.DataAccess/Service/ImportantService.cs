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
    public class ImportantService: IImportantService
    {
        private readonly ApplicationDbContext _db;

        public ImportantService(ApplicationDbContext db)
        {
            _db = db;
        }

        public void AddImportant(Important entity)
        {
            _db.Importants.Add(entity);
            _db.SaveChanges();
        }

        public IEnumerable<Important> GetAll()
        {
            IEnumerable<Important> query = _db.Importants;
            return query.ToList();
        }

        public Important GetFirstOrDefault(Expression<Func<Important, bool>> filter)
        {
            IQueryable<Important> query = _db.Importants;
            query = query.Where(filter);
            return query.FirstOrDefault();
        }

        public void UpdateImportant(Important Important)
        {
            _db.Importants.Update(Important);
            _db.SaveChanges();
        }

        public void Remove(Important entity)
        {
            _db.Importants.Remove(entity);
            _db.SaveChanges();
        }

       

    }
}
