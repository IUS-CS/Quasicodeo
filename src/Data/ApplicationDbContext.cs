using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TooBroke.Models;
using TooBroke.Models.CalculatorViewModels;

namespace TooBroke.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<BudgetEntries> Budget { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<GoalEntries> Goals { get; set; }
        public DbSet<TransactionEntries> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<TooBroke.Models.ApplicationUser> ApplicationUser { get; set; }
    }
}
