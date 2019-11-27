using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using HelpDesk.Models;

namespace HelpDesk.Pages.Repairs
{
    public class CreateModel : PageModel
    {
        private readonly HelpDesk.Models.HelpDeskContext _context;

        public CreateModel(HelpDesk.Models.HelpDeskContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ReportID"] = new SelectList(_context.Report, "ReportID", "ReportID");
            return Page();
        }

        [BindProperty]
        public Repair Repair { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Repair.Add(Repair);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
