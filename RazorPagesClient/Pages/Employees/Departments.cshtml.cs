using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
        public void OnGet()
        {
        }
    }
}
