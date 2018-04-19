using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TooBroke.Data;
using TooBroke.Models.CalculatorViewModels;

namespace TooBroke.Pages.Budget
{
    public class CalculatorsIndexModel : PageModel
    {
        private readonly TooBroke.Data.CalculatorDbContext _context;

        public CalculatorsIndexModel(TooBroke.Data.CalculatorDbContext context)
        {
            _context = context;
        }

        public IList<BudgetEntry> BudgetEntry { get;set; }
        public IList<TransactionEntry> TransactionEntry { get; set; }

        public async Task OnGetAsync()
        {
            BudgetEntry = await _context.Budget
                .Include(b => b.Category).ToListAsync();

            TransactionEntry = await _context.Transactions
                .Include(b => b.Category).ToListAsync();
        }
    }
}
