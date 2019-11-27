using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDesk.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Birthday { get; set; }
       
        public string Email { get; set; }
        public string Line { get; set; }
        public string Call { get; set; }
        public string Addr { get; set; }
        public string Image { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }

        public virtual Company Employee_CompanyID { get; set; }

        public int CompanyID { get; set; }
        public virtual Department Employee_DepartmentID { get; set; }

        public int DepartmentID { get; set; }
        public virtual Location Employee_LocationID { get; set; }

        public int LocationID { get; set; }
        public virtual EmployeeType Employee_EmployeeTypeID { get; set; }

        public int EmployeeTypeID { get; set; }
        public virtual Position Employee_PositionID { get; set; }

        public int PositionID { get; set; }
    }
}
