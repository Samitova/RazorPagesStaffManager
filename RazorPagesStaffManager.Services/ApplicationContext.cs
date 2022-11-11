using Microsoft.EntityFrameworkCore;
using RazorPagesStaffManager.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RazorPagesStaffManager.Services
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {           
            Database.EnsureCreated();   
        }
    }
}
