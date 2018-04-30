using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TooBroke.Pages.Calculators.Goals
{
    public class LoansModel : PageModel
    {
        [TempData]
        public String Results { get; set; }
        [TempData]
        public double SavedPrincipal { get; set; }
        [TempData]
        public double SavedPayment { get; set; }
        [TempData]
        public double SavedInterest { get; set; }
        [TempData]
        public double SavedTerm { get; set; }

        [Required]
        [BindProperty]
        public double Principal { get; set; }
        [Required]
        [BindProperty]
        [Display(Name = "Monthly payment")]
        public double Payment { get; set; }
        [Required]
        [BindProperty]
        [Display(Name = "Annual Interest")]
        [Range(0.000001,1000000)]
        public double Interest { get; set; }
        [Required]
        [BindProperty]
        [Display(Name = "Goal payoff (years)")]
        public int Term { get; set; }

        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            double GeneratedTerm = 0;

            // Convert to decimal
            Interest = Interest / 100;
            // Establish monthly interest
            double r = Interest / 12;
            // Establish months paid
            double n = Term * 12;

            double InterestPaid = Principal * r * n;

            double TotalPaid = Principal + InterestPaid;

            double TempValue = Principal;

            // Calculate cost based on current payments
            while (TempValue > 0)
            {
                // Amortization
                TempValue = (TempValue * (1 + r)) - Payment;
                // Increment monthly
                GeneratedTerm = GeneratedTerm + 1;
            }

            // Calculate payments needed to meet goal
            double GeneratedPayment = Principal * ((r * Math.Pow(1 + r, n)) / (Math.Pow(1 + r, n) - 1));

            double GeneratedSavings = (Principal + (Principal * (Interest / 12) * GeneratedTerm)) - TotalPaid;

            // Bring it back to years
            GeneratedTerm = Math.Round(GeneratedTerm / 12, 2);

            String TotalPaidString = TotalPaid.ToString("C");
            String TotalSavedString = GeneratedSavings.ToString("C");
            String GeneratedPaymentString = GeneratedPayment.ToString("C");
    
            Results = String.Format("Based on your current payments, you are expected to payoff your loan in {0} years with a total loan cost of {1}. In order to meet your goal of {2} years, we suggest adjusting your monthly payments to {3} which would save {4} over the course of the loan.", GeneratedTerm, TotalPaidString, Term, GeneratedPaymentString, TotalSavedString);
            SavedInterest = Interest * 100;
            SavedPayment = Payment;
            SavedPrincipal = Principal;
            SavedTerm = Term;


            return RedirectToPage();
        }
    }
}