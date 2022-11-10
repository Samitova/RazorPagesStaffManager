using RazorPagesStaffManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace RazorPagesStaffManager.Services
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationContext context)
        {
            if (!context.Employees.Any())
            {
                context.Employees.AddRange(
                    new Employee
                    {
                        Id = 1,
                        Name = "Mark",
                        Email = "mark@gmail.com",
                        PhotoPath = "avatar1.png",
                        Department = Department.IT
                    },
                    new Employee
                    {
                        Id = 2,
                        Name = "Viktor",
                        Email = "viktor@gmail.com",
                        PhotoPath = "avatar2.png",
                        Department = Department.HR
                    },
                    new Employee
                    {
                        Id = 3,
                        Name = "Oleg",
                        Email = "oleg@gmail.com",
                        PhotoPath = "avatar3.png",
                        Department = Department.Payroll
                    },
                    new Employee
                    {
                        Id = 4,
                        Name = "Balla",
                        Email = "bella@gmail.com",
                        PhotoPath = "avatar4.png",
                        Department = Department.HR
                    },
                     new Employee
                     {
                         Id = 5,
                         Name = "Ben",
                         Email = "ben@gmail.com",
                         PhotoPath = "avatar4.png",
                         Department = Department.IT
                     },
                     new Employee
                     {
                         Id = 6,
                         Name = "Rob",
                         Email = "rob@gmail.com",
                         PhotoPath = "avatar3.png",
                         Department = Department.IT
                     }
                );
                context.SaveChanges();
            }
        }
    }
}
