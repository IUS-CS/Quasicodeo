using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TooBroke.Models.CalculatorViewModels
{
    public class GoalEntries
    {
        public int ID { get; set; }
        public String ApplicationUserID { get; set; }
        public int CategoryID { get; set; }
        public String Title { get; set; }
        public int InitialAmount { get; set; }
        public int GoalAmount { get; set; }
        public int Interest { get; set; }
        public int Term { get; set; }
        public int Compound { get; set; }
        public int RecurringPayments { get; set; }
        public int PaymentFrequency { get; set; }
        public int TargetPayOff { get; set; }
        public int GeneratedPayOff { get; set; }
        public int OneTimePayment { get; set; }

        public Categories Category { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
