using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HelpDesk.Models;

namespace HelpDesk.Pages.EmployeeTypes
{
    public class DeleteModel : PageModel
    {
        private readonly HelpDesk.Models.HelpDeskContext _context;

        public DeleteModel(HelpDesk.Models.HelpDeskContext context)
        {
            _context = context;
        }

        [BindProperty]
        public EmployeeType EmployeeType { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            EmployeeType = await _context.EmployeeType.FirstOrDefaultAsync(m => m.EmployeeTypeID == id);

            if (EmployeeType == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            EmployeeType = await _context.EmployeeType.FindAsync(id);

            if (EmployeeType != null)
            {
                _context.EmployeeType.Remove(EmployeeType);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
