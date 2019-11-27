using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HelpDesk.Models;

namespace HelpDesk.Pages.Brands
{
    public class DetailsModel : PageModel
    {
        private readonly HelpDesk.Models.HelpDeskContext _context;

        public DetailsModel(HelpDesk.Models.HelpDeskContext context)
        {
            _context = context;
        }

        public Brand Brand { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Brand = await _context.Brand.FirstOrDefaultAsync(m => m.BrandID == id);

            if (Brand == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
