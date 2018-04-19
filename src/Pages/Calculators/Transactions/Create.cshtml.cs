using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TooBroke.Data;
using TooBroke.Models.CalculatorViewModels;

namespace TooBroke.Pages.Transactions
{
    public class CreateModel : PageModel
    {
        private readonly TooBroke.Data.CalculatorDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CreateModel(TooBroke.Data.CalculatorDbContext context,
                           UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult OnGet()
        {
            ViewData["Categories"] = new SelectList(_context.Categories, "ID", "Title");
            Types = ListTypes();
            return Page();
        }

        private List<SelectListItem> ListTypes()
        {
            List<SelectListItem> temp = new List<SelectListItem>
            {
                new SelectListItem{ Value = "false", Text = "Debit"},
                new SelectListItem{ Value = "true", Text = "Credit"}
            };
            return temp;
        }

        [BindProperty]
        public TransactionEntry TransactionEntry { get; set; }
        public BudgetEntry BudgetEntry { get; set; }
        public List<SelectListItem> Types { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["Categories"] = new SelectList(_context.Categories, "ID", "Title");
                //Types = ListTypes();
                return Page();
            }

            TransactionEntry.ApplicationUserID = _userManager.GetUserId(User);

            _context.Transactions.Add(TransactionEntry);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}