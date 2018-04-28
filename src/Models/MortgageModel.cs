using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.ComponentModel.DataAnnotations;
using TooBroke.Data;

namespace TooBroke.Models.CalculatorViewModels
{
    public class MortgageModel : PageModel
    {
        public int ID { get; set; }
        public String ApplicationUserID { get; set; }
        public int CategoryID { get; set; }
        public String Title { get; set; }
        [Display(Name = "Initial Amount")]
        public double InitialAmount { get; set; }
        [Display(Name = "Goal Amount")]
        public double GoalAmount { get; set; }
        public double Interest { get; set; }
        public int Term { get; set; }
        public int Compound { get; set; }
        [Display(Name = "Recurring Payments")]
        public double RecurringPayments { get; set; }
        [Display(Name = "Payment Frequency")]
        public int PaymentFrequency { get; set; }
        [Display(Name = "Target Payoff")]
        public int TargetPayOff { get; set; }
        [Display(Name = "Generated Payoff")]
        public int GeneratedPayOff { get; set; }
        [Display(Name = "One-Time Payment")]
        public double OneTimePayment { get; set; }

        public Category Category { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}