using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HelpDesk.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HelpDesk.Pages.Repairs
{
    public class IndexModel : PageModel
    {
        private readonly HelpDesk.Models.HelpDeskContext _context;

        public IndexModel(HelpDesk.Models.HelpDeskContext context)
        {
            _context = context;
        }
        public IList<Employee> Employee { get; set; }
        public IList<Repair> Repair { get;set; }

        public async Task OnGetAsync()
        {
            Repair = await _context.Repair
                .Include(r => r.Repair_ReportID).ToListAsync();

            Employee = await _context.Employee.ToListAsync();

            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeID", "EmployeeID");
        }
    }
}
