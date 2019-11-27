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
    public class DetailsModel : PageModel
    {
        private readonly HelpDesk.Models.HelpDeskContext _context;

       

        
        public DetailsModel(HelpDesk.Models.HelpDeskContext context)
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
           
            Report = await _context.Report
                .Include(r => r.Report_AssetID).FirstOrDefaultAsync(m => m.ReportID == id);
            

           
            if (Report == null)
            {
                return NotFound();
            }
            ViewData["ReportID"] = new SelectList(_context.Report, "ReportID", "ReportID");
            ViewData["AssetID"] = new SelectList(_context.Asset, "AssetID", "AssetID");
            return Page();
        }



        
       

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
           
          

            _context.Repair.Add(Repair);

            _context.Attach(Report).State = EntityState.Modified;

           
            
            await _context.SaveChangesAsync();

            return RedirectToPage("./../Repairs/Index");
        }
    }
}
