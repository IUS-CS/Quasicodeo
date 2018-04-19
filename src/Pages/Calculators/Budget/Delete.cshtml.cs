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
    public class DeleteModel : PageModel
    {
        private readonly TooBroke.Data.CalculatorDbContext _context;

        public DeleteModel(TooBroke.Data.CalculatorDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public BudgetEntry BudgetEntry { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BudgetEntry = await _context.Budget
                .Include(b => b.Category).SingleOrDefaultAsync(m => m.ID == id);

            if (BudgetEntry == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BudgetEntry = await _context.Budget.FindAsync(id);

            if (BudgetEntry != null)
            {
                _context.Budget.Remove(BudgetEntry);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
