using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;

namespace RazorPagesStaffManager.Services.DataBase
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        private readonly DbSet<T> _table;
        private readonly ApplicationContext _context;
        public ApplicationContext Context => _context;
        public BaseRepository(ApplicationContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }

        public void Add(T entity)
        {
            _table.Add(entity);
        }
        public void AddRange(IList<T> entities)
        {
            _table.AddRange(entities);
        }

        public void Delete(int id)
        {
            T entityToDelete = _table.Find(id);
            Delete(entityToDelete);
        }
        public void Delete(T entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _table.Attach(entity);
            }
            _table.Remove(entity);
        }

        public virtual List<T> GetAll(Expression<Func<T, bool>> filter = null,
             Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
            IQueryable<T> query = _table;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public T GetOne(int? id)
        {
            return _table.Find(id);
        }

        public void Update(T entity)
        {
            _table.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

    }
}
