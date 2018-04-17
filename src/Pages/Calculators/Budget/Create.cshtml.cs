using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TooBroke.Data;
using TooBroke.Models.CalculatorViewModels;

namespace TooBroke.Pages.Budget
{
    public class CreateModel : PageModel
    {
        private readonly TooBroke.Data.CalculatorDbContext _context;

        public CreateModel(TooBroke.Data.CalculatorDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ApplicationUserID"] = new SelectList(_context.Set<ApplicationUser>(), "Id", "Id");
        ViewData["Categories"] = new SelectList(_context.Categories, "ID", "Title");
            return Page();
        }

        [BindProperty]
        public BudgetEntry BudgetEntry { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Budget.Add(BudgetEntry);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}