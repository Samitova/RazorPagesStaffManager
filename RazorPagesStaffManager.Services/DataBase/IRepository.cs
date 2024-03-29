﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace RazorPagesStaffManager.Services.DataBase
{
    public interface IRepository<T>
    {
        void Add(T entity);
        void AddRange(IList<T> entities);
        void Update(T entity);
        void Delete(T entity);
        void Delete(int id);
        T GetOne(int id);
        List<T> GetAll(Expression<Func<T, bool>> filter,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, string includeProperties);
    }
}
