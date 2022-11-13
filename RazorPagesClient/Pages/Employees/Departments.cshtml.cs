using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesStaffManager.Models;
using RazorPagesStaffManager.Services.DataBase;

namespace RazorPagesClient.Pages.Employees
{
    public class DepartmentsModel : PageModel
    {
        private readonly DbUnitOfWork _db;
        public DepartmentsModel(DbUnitOfWork db)
        {
            _db = db;
        }

        [BindProperty (SupportsGet =true)]
        public Employee Employee { get; set; }

        public void OnGet()
        {

        }
    }
}
