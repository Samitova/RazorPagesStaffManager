using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesStaffManager.Models;
using RazorPagesStaffManager.Services.DataBase;
using System.IO;
using System.Xml.Linq;

namespace RazorPagesClient.Pages.Employees
{
    public class DeleteEmployeeModel : PageModel
    {

        private readonly DbUnitOfWork _db;
        private readonly IWebHostEnvironment _environment;
        public DeleteEmployeeModel(DbUnitOfWork db, IWebHostEnvironment environment)
        {
            _db = db;
            _environment = environment;
        }

        /*-----------------------------------------------------------------------------------*/
        [BindProperty]
        public Employee Employee { get; set; }

        /*-----------------------------------------------------------------------------------*/


        public IActionResult OnGet(int id)
        {
            Employee = _db.EmployeesRepository.GetOne(id);

            if (Employee == null)
            {
                return RedirectToPage("/NotFound");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            string filePath = Path.Combine(_environment.WebRootPath, "images\\avatars", Employee.PhotoPath);
            try
            {  
                _db.EmployeesRepository.Delete(Employee.Id);                
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return Page();
            }
            try
            {
                if (!Employee.PhotoPath.Contains("noimage.png"))
                {
                    System.IO.File.Delete(filePath);
                }
            }
            catch (IOException ex)
            {
                ModelState.AddModelError("", ex.Message);
                RedirectToPage("/Employees/Employees");
            }           

            return RedirectToPage("/Employees/Employees");
        }
    }
}
