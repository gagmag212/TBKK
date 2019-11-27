using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HelpDesk.Models;

namespace HelpDesk.Pages.Employees
{
    public class IndexModel : PageModel
    {
        private readonly HelpDesk.Models.HelpDeskContext _context;

        public IndexModel(HelpDesk.Models.HelpDeskContext context)
        {
            _context = context;
        }

        public IList<Employee> Employee { get;set; }

        public async Task OnGetAsync()
        {
            Employee = await _context.Employee
                .Include(e => e.Employee_CompanyID)
                .Include(e => e.Employee_DepartmentID)
                .Include(e => e.Employee_EmployeeTypeID)
                .Include(e => e.Employee_LocationID)
                .Include(e => e.Employee_PositionID).ToListAsync();
        }
    }
}
