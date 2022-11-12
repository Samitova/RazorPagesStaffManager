using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesStaffManager.Models;
using RazorPagesStaffManager.Services.DataBase;
using System.Collections;
using System.Collections.Generic;

namespace RazorPagesClient.Pages.Employees
{
    public class EmployeesModel : PageModel
    {
        private readonly DbUnitOfWork _db;        
        public EmployeesModel(DbUnitOfWork db)
        {
            _db = db;
        }


        public IList<Employee> Employees { get; set; }
        public void OnGet()
        {
            Employees = _db.EmployeesRepository.GetAll();
        }
    }
}
