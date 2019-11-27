using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HelpDesk.Models;

namespace HelpDesk.Pages.Assets
{
    public class EditModel : PageModel
    {
        private readonly HelpDesk.Models.HelpDeskContext _context;

        public EditModel(HelpDesk.Models.HelpDeskContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Asset Asset { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Asset = await _context.Asset
                .Include(a => a.Asset_EmployeeID)
                .Include(a => a.Asset_ModelID)
                .Include(a => a.Asset_SupplierID).FirstOrDefaultAsync(m => m.AssetID == id);

            if (Asset == null)
            {
                return NotFound();
            }
           ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeID", "EmployeeID");
           ViewData["ModelID"] = new SelectList(_context.Models, "ModelID", "ModelID");
           ViewData["SupplierID"] = new SelectList(_context.Supplier, "SupplierID", "SupplierID");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Asset).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssetExists(Asset.AssetID))
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

        private bool AssetExists(int id)
        {
            return _context.Asset.Any(e => e.AssetID == id);
        }
    }
}
