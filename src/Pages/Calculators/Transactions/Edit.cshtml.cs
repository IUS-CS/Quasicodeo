using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TooBroke.Data;
using TooBroke.Models.CalculatorViewModels;

namespace TooBroke.Pages.Transactions
{
    public class EditModel : PageModel
    {
        private readonly TooBroke.Data.CalculatorDbContext _context;

        public EditModel(TooBroke.Data.CalculatorDbContext context)
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
           ViewData["ApplicationUserID"] = new SelectList(_context.Set<ApplicationUser>(), "Id", "Id");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(TransactionEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransactionEntryExists(TransactionEntry.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TransactionEntryExists(int id)
        {
            return _context.Transactions.Any(e => e.ID == id);
        }
    }
}
