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

namespace TooBroke.Pages.Goals
{
    public class EditModel : PageModel
    {
        private readonly TooBroke.Data.CalculatorDbContext _context;

        public EditModel(TooBroke.Data.CalculatorDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public GoalEntry GoalEntry { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            GoalEntry = await _context.Goals
                .Include(g => g.ApplicationUser)
                .Include(g => g.Category).SingleOrDefaultAsync(m => m.ID == id);

            if (GoalEntry == null)
            {
                return NotFound();
            }
           ViewData["ApplicationUserID"] = new SelectList(_context.Set<ApplicationUser>(), "Id", "Id");
           ViewData["CategoryID"] = new SelectList(_context.Categories, "ID", "ID");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(GoalEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GoalEntryExists(GoalEntry.ID))
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

        private bool GoalEntryExists(int id)
        {
            return _context.Goals.Any(e => e.ID == id);
        }
    }
}
