using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TooBroke.Data;
using TooBroke.Models.CalculatorViewModels;

namespace TooBroke.Pages.Transactions
{
    public class DeleteModel : PageModel
    {
        private readonly TooBroke.Data.CalculatorDbContext _context;

        public DeleteModel(TooBroke.Data.CalculatorDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TransactionEntry TransactionEntry { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TransactionEntry = await _context.Transactions
                .Include(t => t.ApplicationUser).SingleOrDefaultAsync(m => m.ID == id);

            if (TransactionEntry == null)
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

            TransactionEntry = await _context.Transactions.FindAsync(id);

            if (TransactionEntry != null)
            {
                _context.Transactions.Remove(TransactionEntry);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
