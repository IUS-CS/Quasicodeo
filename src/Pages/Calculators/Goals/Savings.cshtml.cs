using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TooBroke.Pages.Calculators.Goals
{
    public class SavingsModel : PageModel
    {
        [TempData]
        public String Results { get; set; }
        [TempData]
        public double SavedPrincipal { get; set; }
        [TempData]
        public double SavedDeposit { get; set; }
        [TempData]
        public double SavedInterest { get; set; }
        [TempData]
        public double SavedTerm { get; set; }
        [TempData]
        public double SavedGoal { get; set; }

        [Required]
        [BindProperty]
        public double Principal { get; set; }
        [Required]
        [BindProperty]
        [Display(Name = "Monthly deposits")]
        public double Deposit { get; set; }
        [Required]
        [BindProperty]
        [Display(Name = "Annual Interest")]
        [Range(0.000001, 1000000)]
        public double Interest { get; set; }
        [Required]
        [BindProperty]
        [Display(Name = "Goal")]
        public int Goal { get; set; }
        [Required]
        [BindProperty]
        [Display(Name ="Finish time (years)")]
        public int Term { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            // Convert to decimal
            Interest = Interest / 100;
            // Establish monthly interest
            double r = Interest / 12;
            // Establish months paid
            double n = Term * 12;
            // Ensure Deposits aren't 0
            if (Deposit == 0) Deposit = 1;
            // Calculate Future Value
            double FV = Math.Round(Principal + (Deposit * ((Math.Pow(1 + r, n) - 1) / r)),2);

            double GeneratedTerm = Math.Round(Math.Log(Goal / Principal) / Math.Log(Deposit * ((Math.Pow(1 + r, n) - 1) / r)), 2);

            String FVString = FV.ToString("C");
            String PrincipalString = Principal.ToString("C");

            Results = String.Format("Given an initial balance of {0} and monthly deposits of {1}, the estimated future balance would be {2} in {3} years. Reaching your goal will take {4} years.", PrincipalString, Deposit, FVString, Term, GeneratedTerm);

            SavedDeposit = Deposit;
            SavedGoal = Goal;
            SavedInterest = Interest * 100;
            SavedPrincipal = Principal;
            SavedTerm = Term;

            return RedirectToPage();
        }

    }
}