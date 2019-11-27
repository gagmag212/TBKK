using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDesk.Models
{
    public class Supplier
    {
        public int SupplierID { get; set; }
        public string SupplierName { get; set; }
        public string ContactName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string URL { get; set; }
        public string Note { get; set; }
        public string Image { get; set; }

    }
}
