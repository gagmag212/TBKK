using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HelpDesk.Models;

namespace HelpDesk.Pages.Includes
{
    public class IncludeModel : PageModel
    {
        private readonly HelpDesk.Models.HelpDeskContext _context;

        public IncludeModel(HelpDesk.Models.HelpDeskContext context)
        {
            _context = context;
        }
        public IList<Repair> Repair { get; set; }
        public IList<Report> Report { get;set; }

        public async Task OnGetAsync()
        {
            Report = await _context.Report
                .Include(r => r.Report_AssetID).ToListAsync();
            Repair = await _context.Repair
               .Include(r => r.Repair_ReportID).ToListAsync();

        }
    }
}
