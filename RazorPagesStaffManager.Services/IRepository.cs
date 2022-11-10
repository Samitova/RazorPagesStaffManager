using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace RazorPagesStaffManager.Services
{
    public interface IRepository<T>
    {
        void Add(T entity);
        void AddRange(IList<T> entities);
        void Update(T entity);
        void Delete(T entity);
        T GetOne(int? id);
        IList<T> GetAll();       
    }
}
