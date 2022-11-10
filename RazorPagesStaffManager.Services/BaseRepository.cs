using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;

namespace RazorPagesStaffManager.Services
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        private readonly DbSet<T> _table;
        private readonly ApplicationContext _context;
        public ApplicationContext Context => _context;
        public BaseRepository(ApplicationContext context)
        {
            _context = context;
            _table = _context.Set<T>() ;
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

        public IList<T> GetAll()
        {
            return _table.ToList();
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
