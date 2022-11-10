using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace RazorPagesStaffManager.Services
{
    public interface IRepository<T>
    {
        int Add(T entity);
        int AddRange(IList<T> entities);
        int Update(T entity);
        int Delete(T entity);
        T GetOne(int? id);
        IList<T> GetAll();       
    }
}
