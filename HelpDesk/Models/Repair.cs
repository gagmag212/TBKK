using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDesk.Models
{
    public class Repair
    {
        public int RepairID { get; set; }
        public DateTime Date { get; set; }

        public string Note { get; set; }

        public string Type { get; set; }

        public string Status { get; set; }

        public virtual Report Repair_ReportID { get; set; }

        public int ReportID { get; set; }

        public int Repair_EmployeeID { get; set; }
    }
}
