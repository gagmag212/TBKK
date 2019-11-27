using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HelpDesk.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HelpDesk.Pages.Repairs
{
    public class DeleteModel : PageModel
    {
        private readonly HelpDesk.Models.HelpDeskContext _context;

     

        
        public DeleteModel(HelpDesk.Models.HelpDeskContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Report Report { get; set; }

        [BindProperty]
        public Repair Repair { get; set; }


        //Get การแสดงหน้า
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            

          
           
            if (id == null)
            {
                return NotFound();
            }

            Repair = await _context.Repair
                .Include(r => r.Repair_ReportID).FirstOrDefaultAsync(m => m.RepairID == id);
            Report = await _context.Report
               .Include(r => r.Report_AssetID).FirstOrDefaultAsync(m => m.ReportID == Repair.ReportID);

            if (Repair == null)
            {
                return NotFound();
            }
            ViewData["ReportID"] = new SelectList(_context.Report, "ReportID", "ReportID");
            ViewData["AssetID"] = new SelectList(_context.Asset, "AssetID", "AssetID");
            return Page();

        }
        
       


        //POST การกดปุ่มเปลี่ยนหรือใช้งาน
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Repair = await _context.Repair.FindAsync(id);

            _context.Attach(Report).State = EntityState.Modified;

            _context.Attach(Repair).State = EntityState.Modified;


            if (Repair != null)
                {
                    _context.Repair.Remove(Repair);
                    await _context.SaveChangesAsync();
                    return RedirectToPage("./Index");
                }
                
           
               

               
                return RedirectToPage("./Index");
            }
           

           

           
        
    }
}
