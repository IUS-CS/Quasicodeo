using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TooBroke.Data;
using TooBroke.Models.CalculatorViewModels;

namespace TooBroke.Pages.Goals
{
    public class DeleteModel : PageModel
    {
        private readonly TooBroke.Data.CalculatorDbContext _context;

        public DeleteModel(TooBroke.Data.CalculatorDbContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            GoalEntry = await _context.Goals.FindAsync(id);

            if (GoalEntry != null)
            {
                _context.Goals.Remove(GoalEntry);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
