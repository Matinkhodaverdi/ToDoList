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
    public interface IImportantService
    {
        void AddImportant(ImportantViewModel viewModel);
        IEnumerable<Important> GetAll();
        Important GetFirstOrDefault(Expression<Func<Important, bool>> filter);
        void UpdateImportant(Important Important);
        void Remove(Important entity);

    }
}
