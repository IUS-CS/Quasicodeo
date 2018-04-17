using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TooBroke.Models.CalculatorViewModels;

namespace TooBroke.Data
{
    public class CalculatorDbContext : DbContext
    {
        public CalculatorDbContext(DbContextOptions<CalculatorDbContext> options)
        : base(options)
        {
        }

        public DbSet<BudgetEntry> Budget { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<GoalEntry> Goals { get; set; }
        public DbSet<TransactionEntry> Transactions { get; set; }
    }
}
