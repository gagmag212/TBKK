using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HelpDesk.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HelpDesk.Pages.Reports
{
    public class IndexModel : PageModel
    {
        private readonly HelpDesk.Models.HelpDeskContext _context;

        public IndexModel(HelpDesk.Models.HelpDeskContext context)
        {
            _context = context;
        }

        public IList<Asset> Asset { get; set; }
        public IList<Report> Report { get;set; }

        public IList<Employee> Employee { get; set; }
        public async Task OnGetAsync()
        {
            Report = await _context.Report
                .Include(r => r.Report_AssetID).ToListAsync();

            Asset = await _context.Asset.ToListAsync();

            Employee = await _context.Employee.ToListAsync();

            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeID", "EmployeeID");
            ViewData["ReportID"] = new SelectList(_context.Report, "ReportID", "ReportID");
            ViewData["AssetID"] = new SelectList(_context.Asset, "AssetID", "AssetID");
        }
    }
}
