using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesStaffManager.Models;
using RazorPagesStaffManager.Services;
using System.Collections.Generic;

namespace RazorPagesClient.Pages.Employees
{
    public class EmployeeDetailsModel : PageModel
    {
        private readonly DbUnitOfWork _db;
        public EmployeeDetailsModel(DbUnitOfWork db)
        {
            _db = db;
        }

        public Employee Employee { get; set; }
        public IActionResult OnGet(int id)
        {
            Employee = _db.EmployeesRepository.GetOne(id);

            if (Employee == null)
            {
                return RedirectToPage("/NotFound");
            }
            return Page();
            
        }
    }
}
