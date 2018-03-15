using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TooBroke.Models.CalculatorViewModels
{
    public class BudgetEntries
    {
        public int ID { get; set; }
        public String ApplicationUserID { get; set; }
        public int CategoriesID { get; set; }
        public String Title { get; set; }
        public int Amount { get; set; }
        public int CurrentBalance { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        public Categories Category { get; set; }
    }
}
