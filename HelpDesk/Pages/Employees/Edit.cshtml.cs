using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HelpDesk.Models;

namespace HelpDesk.Pages.Employees
{
    public class EditModel : PageModel
    {
        private readonly HelpDesk.Models.HelpDeskContext _context;

        public EditModel(HelpDesk.Models.HelpDeskContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Employee Employee { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Employee = await _context.Employee
                .Include(e => e.Employee_CompanyID)
                .Include(e => e.Employee_DepartmentID)
                .Include(e => e.Employee_EmployeeTypeID)
                .Include(e => e.Employee_LocationID)
                .Include(e => e.Employee_PositionID).FirstOrDefaultAsync(m => m.EmployeeID == id);

            if (Employee == null)
            {
                return NotFound();
            }
           ViewData["CompanyID"] = new SelectList(_context.Company, "CompanyID", "CompanyID");
           ViewData["DepartmentID"] = new SelectList(_context.Department, "DepartmentID", "DepartmentID");
           ViewData["EmployeeTypeID"] = new SelectList(_context.EmployeeType, "EmployeeTypeID", "EmployeeTypeID");
           ViewData["LocationID"] = new SelectList(_context.Location, "LocationID", "LocationID");
           ViewData["PositionID"] = new SelectList(_context.Set<Position>(), "PositionID", "PositionID");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(Employee.EmployeeID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employee.Any(e => e.EmployeeID == id);
        }
    }
}
