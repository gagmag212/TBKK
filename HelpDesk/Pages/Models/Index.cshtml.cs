using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HelpDesk.Models;

namespace HelpDesk.Pages.Models
{
    public class IndexModel : PageModel
    {
        private readonly HelpDesk.Models.HelpDeskContext _context;

        public IndexModel(HelpDesk.Models.HelpDeskContext context)
        {
            _context = context;
        }

        public IList<Model> Model { get;set; }

        public async Task OnGetAsync()
        {
            Model = await _context.Models
                .Include(m => m.Model_BrandID)
                .Include(m => m.Model_CategoryID).ToListAsync();
        }
    }
}
