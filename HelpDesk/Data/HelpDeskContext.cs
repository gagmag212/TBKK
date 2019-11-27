using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HelpDesk.Models;

namespace HelpDesk.Models
{
    public class HelpDeskContext : DbContext
    {
        public HelpDeskContext (DbContextOptions<HelpDeskContext> options)
            : base(options)
        {
        }
        public DbSet<HelpDesk.Models.Category> Category { get; set; }
        public DbSet<HelpDesk.Models.Supplier> Supplier { get; set; }
        public DbSet<HelpDesk.Models.Model> Models { get; set; }
        public DbSet<HelpDesk.Models.Location> Location { get; set; }
        public DbSet<HelpDesk.Models.Company> Company { get; set; }
        public DbSet<HelpDesk.Models.Asset> Asset { get; set; }
        public DbSet<HelpDesk.Models.Brand> Brand { get; set; }
        public DbSet<HelpDesk.Models.Department> Department { get; set; }
        public DbSet<HelpDesk.Models.EmployeeType> EmployeeType { get; set; }

        public DbSet<HelpDesk.Models.Employee> Employee { get; set; }
        public DbSet<HelpDesk.Models.Report> Report { get; set; }

        public DbSet<HelpDesk.Models.Repair> Repair { get; set; }

        public DbSet<HelpDesk.Models.Position> Position { get; set; }
    }
}
