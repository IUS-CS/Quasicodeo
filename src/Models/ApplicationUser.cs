using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using TooBroke.Models.CalculatorViewModels;

namespace TooBroke.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public ICollection<BudgetEntries> Budget { get; set; }
        public ICollection<GoalEntries> Goals { get; set; }
        public ICollection<TransactionEntries> Transactions { get; set; }
    }
}
