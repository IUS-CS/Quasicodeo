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

namespace TooBroke.Pages.Budget
{
    public class EditModel : PageModel
    {
        private readonly TooBroke.Data.CalculatorDbContext _context;

        public EditModel(TooBroke.Data.CalculatorDbContext context)
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
                .Include(b => b.ApplicationUser)
                .Include(b => b.Category).SingleOrDefaultAsync(m => m.ID == id);

            if (BudgetEntry == null)
            {
                return NotFound();
            }
           ViewData["ApplicationUserID"] = new SelectList(_context.Set<ApplicationUser>(), "Id", "Id");
           ViewData["CategoriesID"] = new SelectList(_context.Categories, "ID", "ID");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(BudgetEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BudgetEntryExists(BudgetEntry.ID))
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

        private bool BudgetEntryExists(int id)
        {
            return _context.Budget.Any(e => e.ID == id);
        }
    }
}
