using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HelpDesk.Models;

namespace HelpDesk.Pages.Assets
{
    public class DetailsModel : PageModel
    {
        private readonly HelpDesk.Models.HelpDeskContext _context;

        public DetailsModel(HelpDesk.Models.HelpDeskContext context)
        {
            _context = context;
        }

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
            return Page();
        }
    }
}
