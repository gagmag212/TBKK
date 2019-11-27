using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HelpDesk.Models;

namespace HelpDesk.Pages.Departments
{
    public class IndexModel : PageModel
    {
        private readonly HelpDesk.Models.HelpDeskContext _context;

        public IndexModel(HelpDesk.Models.HelpDeskContext context)
        {
            _context = context;
        }

        public IList<Department> Department { get;set; }

        public async Task OnGetAsync()
        {
            Department = await _context.Department.ToListAsync();
        }
    }
}
