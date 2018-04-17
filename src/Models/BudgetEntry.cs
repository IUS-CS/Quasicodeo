using System;
using System.ComponentModel.DataAnnotations;
using TooBroke.Data;

namespace TooBroke.Models.CalculatorViewModels
{
    public class BudgetEntry
    {
        public int ID { get; set; }
        public String ApplicationUserID { get; set; }
        public int CategoryID { get; set; }
        public String Title { get; set; }
        public double Amount { get; set; }
        [Display(Name = "Current Balance")]
        public double CurrentBalance { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        public Category Category { get; set; }
    }
}
