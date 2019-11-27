using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HelpDesk.Models;

namespace HelpDesk.Pages.Repairs
{
    public class ChangeStatusModel : PageModel
    {
        private readonly HelpDesk.Models.HelpDeskContext _context;

        public ChangeStatusModel(HelpDesk.Models.HelpDeskContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Report Report { get; set; }

        [BindProperty]
        public Repair Repair { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Repair = await _context.Repair
                .Include(r => r.Repair_ReportID).FirstOrDefaultAsync(m => m.RepairID == id);

            if (Repair == null)
            {
                return NotFound();
            }
           ViewData["ReportID"] = new SelectList(_context.Report, "ReportID", "ReportID");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Repair).State = EntityState.Modified;

            _context.Attach(Report).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RepairExists(Repair.RepairID))
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

        private bool RepairExists(int id)
        {
            return _context.Repair.Any(e => e.RepairID == id);
        }
    }
}
