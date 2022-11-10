using RazorPagesStaffManager.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RazorPagesStaffManager.Services
{
    public class DbUnitOfWork : IDisposable
    {
        private ApplicationContext _context;
        public DbUnitOfWork(ApplicationContext context)
        {
            _context = context; 
        }
        
        private BaseRepository<Employee> _employeesRepository;

        public BaseRepository<Employee> EmployeesRepository
        {
            get
            {
                if (this._employeesRepository == null)
                {
                    this._employeesRepository = new BaseRepository<Employee>(_context);
                }
                return _employeesRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
