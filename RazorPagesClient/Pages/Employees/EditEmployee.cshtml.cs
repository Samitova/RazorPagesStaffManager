using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesStaffManager.Models;
using RazorPagesStaffManager.Services;
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

        public Employee Employee { get; set; }

        [BindProperty]
        public IFormFile Photo { get; set; }

        [BindProperty]
        public bool Notify { get; set; }

        public string Message { get; set; }


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

        public IActionResult OnPost(Employee employee)
        {
            if (Photo != null)
            {
                if (employee.PhotoPath != null) 
                {
                    string filePath = Path.Combine(_environment.WebRootPath, "images\\avatars", employee.PhotoPath);
                    System.IO.File.Delete(filePath);
                }
                employee.PhotoPath = ProcessUploadedPhoto();
            }
            _db.EmployeesRepository.Update(employee);
            try
            {
                _db.Save();
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError("", $"The record wasn`t updated. {ex.Message}");
            }
            TempData["SM"] = $"Employee with id: {employee.Id} has been edited successful";
            
            return RedirectToPage("/Employees/Employees");  
        }

        public void OnPostUpdateNotificationPreferances(int id)
        {
            if (Notify == true)
            {
                Message = "Thank you for turning on e-mail notification";
            }
            else
            {
                Message = "You have turned off e-mail notifications";
            }

            Employee = _db.EmployeesRepository.GetOne(id);
        }

        private string ProcessUploadedPhoto()
        {
            string unicPhotoName = null;
            if (Photo != null)
            {
                string uploadsFolder = Path.Combine(_environment.WebRootPath, "images\\avatars");
                unicPhotoName = Guid.NewGuid().ToString() + "_" + Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, unicPhotoName);

                using (var fs = new FileStream(filePath, FileMode.Create))
                {
                    Photo.CopyTo(fs);
                }
            }
            return unicPhotoName;
        }
    }
}
