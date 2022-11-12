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
    public class EditEmployeeModel : PageModel
    {
        private readonly DbUnitOfWork _db;
        private readonly IWebHostEnvironment _environment;        
        public EditEmployeeModel(DbUnitOfWork db, IWebHostEnvironment environment)
        {
            _db = db;
            _environment = environment;            
        }

        /*___________________________________________________________________________________*/

        [BindProperty]
        public Employee Employee { get; set; }

        [BindProperty]
        public IFormFile Photo { get; set; }
        
        //public string Message { get; set; }


        /*___________________________________________________________________________________*/
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
            if (ModelState.IsValid)
            {
                if (Photo != null)
                {
                    if (Employee.PhotoPath != null && !Employee.PhotoPath.Contains("noimage.png"))
                    {
                        string filePath = Path.Combine(_environment.WebRootPath, "images\\avatars", Employee.PhotoPath);
                        System.IO.File.Delete(filePath);
                    }
                    string uploadsFolder = Path.Combine(_environment.WebRootPath, "images\\avatars");
                    Employee.PhotoPath = ImageService.ProcessUploadedPhoto(Photo, uploadsFolder);
                }
                _db.EmployeesRepository.Update(Employee);
                try
                {
                    _db.Save();
                }
                catch (System.Exception ex)
                {
                    ModelState.AddModelError("", $"The record wasn`t updated. {ex.Message}");
                }
                TempData["SM"] = $"Employee with id: {Employee.Id} was edited successfully";

                return RedirectToPage("/Employees/Employees");
            }
            return Page();
        }              
    }
}
