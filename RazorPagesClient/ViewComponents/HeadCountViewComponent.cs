using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using RazorPagesStaffManager.Models;
using RazorPagesStaffManager.Services.DataBase;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace RazorPagesClient.ViewComponents
{
    public class HeadCountViewComponent: ViewComponent
    {
        private readonly DbUnitOfWork _db;
        public HeadCountViewComponent(DbUnitOfWork db)
        {
            _db = db;            
        }

        public IViewComponentResult Invoke(Department? department = null)
        {
            IEnumerable<Employee> employees = _db.EmployeesRepository.GetAll();

            if (department.HasValue)
            {
                employees = employees.Where(x => x.Department == department.Value);
            }

            IEnumerable<DepartmentHeadCount> departmentCount = employees.GroupBy(x => x.Department)
                .Select(x => new DepartmentHeadCount { Department = x.Key.Value, Count = x.Count() }).ToList();

            return View(departmentCount);
        }
    }
}
