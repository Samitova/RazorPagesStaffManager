﻿using RazorPagesStaffManager.Models;
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
                        Name = "Mark",
                        Email = "mark@gmail.com",
                        PhotoPath = "avatar1.png",
                        Department = Department.IT
                    },
                    new Employee
                    {                        
                        Name = "Viktor",
                        Email = "viktor@gmail.com",
                        PhotoPath = "avatar2.png",
                        Department = Department.HR
                    },
                    new Employee
                    {                        
                        Name = "Oleg",
                        Email = "oleg@gmail.com",
                        PhotoPath = "avatar3.png",
                        Department = Department.Payroll
                    },
                    new Employee
                    {                       
                        Name = "Balla",
                        Email = "bella@gmail.com",
                        PhotoPath = "avatar4.png",
                        Department = Department.HR
                    },
                     new Employee
                     {                         
                         Name = "Ben",
                         Email = "ben@gmail.com",
                         PhotoPath = "avatar5.png",
                         Department = Department.IT
                     },
                     new Employee
                     {                         
                         Name = "Rob",
                         Email = "rob@gmail.com",
                         PhotoPath = null,
                         Department = Department.IT
                     }
                );
                context.SaveChanges();
            }
        }
    }
}
