﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using HelpDesk.Models;

namespace HelpDesk.Pages.Reports
{
    public class CreateModel : PageModel
    {
        private readonly HelpDesk.Models.HelpDeskContext _context;

        [BindProperty]
        public Asset Asset { get; set; }
        public CreateModel(HelpDesk.Models.HelpDeskContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["AssetID"] = new SelectList(_context.Asset, "AssetID", "AssetName");
            return Page();
        }

        [BindProperty]
        public Report Report { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
           
            DateTime date = DateTime.Now;
            Report.Date = new DateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second); 
            _context.Report.Add(Report);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
