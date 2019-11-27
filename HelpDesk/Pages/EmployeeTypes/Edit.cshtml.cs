using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HelpDesk.Models;

namespace HelpDesk.Pages.EmployeeTypes
{
    public class EditModel : PageModel
    {
        private readonly HelpDesk.Models.HelpDeskContext _context;

        public EditModel(HelpDesk.Models.HelpDeskContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(EmployeeType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeTypeExists(EmployeeType.EmployeeTypeID))
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

        private bool EmployeeTypeExists(int id)
        {
            return _context.EmployeeType.Any(e => e.EmployeeTypeID == id);
        }
    }
}
