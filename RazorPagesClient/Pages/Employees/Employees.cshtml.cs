using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesStaffManager.Models;
using RazorPagesStaffManager.Services.DataBase;
using System;
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
                
        public IEnumerable<Employee> Employees { get; set; }

        [BindProperty(SupportsGet=true)]
        public string SearchTerm { get; set; }    
        public void OnGet()
        {
            if (string.IsNullOrWhiteSpace(SearchTerm))
            {
                Employees = _db.EmployeesRepository.GetAll();
            }
            else
            { 
                Employees = _db.EmployeesRepository.GetAll(filter: x => x.Name.ToLower().Contains(SearchTerm.ToLower()) || x.Email.ToLower().Contains(SearchTerm.ToLower()));
            }            
        }
    }
}
