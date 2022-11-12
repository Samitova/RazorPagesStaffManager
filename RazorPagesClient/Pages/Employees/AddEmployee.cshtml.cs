using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesStaffManager.Models;
using RazorPagesStaffManager.Services.DataBase;
using RazorPagesStaffManager.Services.FileServices;
using System;
using System.IO;

namespace RazorPagesClient.Pages.Employees
{
    public class AddEmployeeModel : PageModel
    {


        private readonly DbUnitOfWork _db;
        private readonly IWebHostEnvironment _environment;
        public AddEmployeeModel(DbUnitOfWork db, IWebHostEnvironment environment)
        {
            _db = db;
            _environment = environment;
        }

        /*___________________________________________________________________________________*/

        [BindProperty]
        public Employee Employee { get; set; }

        [BindProperty]
        public IFormFile Photo { get; set; }
        public string Message { get; set; }

        /*___________________________________________________________________________________*/
        public void OnGet()
        {
            
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if (Photo != null)
                {
                    string uploadsFolder = Path.Combine(_environment.WebRootPath, "images\\avatars");
                    Employee.PhotoPath = ImageService.ProcessUploadedPhoto(Photo, uploadsFolder);
                }
                
                try
                {
                   _db.EmployeesRepository.Add(Employee);
                }
                catch (System.Exception ex)
                {
                    ModelState.AddModelError("", $"The record wasn`t updated. {ex.Message}");
                }
                TempData["SM"] = $"Employee with id: {Employee.Id} was added successfully";

                return RedirectToPage("/Employees/Employees");
            }
            return Page();
        }     
    }
}
