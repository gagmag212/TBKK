using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDesk.Models
{
    public class EmployeeForUs
    {
        public int EmployeeForUsID { get; set; }

        public virtual Employee Employee { get; set; }

        public int EmployeeID { get; set; }
    }
}
