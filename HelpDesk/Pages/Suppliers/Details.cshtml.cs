using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HelpDesk.Models;

namespace HelpDesk.Pages.Suppliers
{
    public class DetailsModel : PageModel
    {
        private readonly HelpDesk.Models.HelpDeskContext _context;

        public DetailsModel(HelpDesk.Models.HelpDeskContext context)
        {
            _context = context;
        }

        public Supplier Supplier { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Supplier = await _context.Supplier.FirstOrDefaultAsync(m => m.SupplierID == id);

            if (Supplier == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
