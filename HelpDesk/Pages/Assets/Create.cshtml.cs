using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using HelpDesk.Models;

namespace HelpDesk.Pages.Assets
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
        ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeID", "EmployeeID");
        ViewData["ModelID"] = new SelectList(_context.Models, "ModelID", "ModelID");
        ViewData["SupplierID"] = new SelectList(_context.Supplier, "SupplierID", "SupplierID");
            return Page();
        }

        [BindProperty]
        public Asset Asset { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Asset.Add(Asset);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
