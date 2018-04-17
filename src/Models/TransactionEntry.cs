using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TooBroke.Data;

namespace TooBroke.Models.CalculatorViewModels
{
    public class TransactionEntry
    {
        public int ID { get; set; }
        public String ApplicationUserID { get; set; }
        public String Title { get; set; }
        public double Amount { get; set; }
        //True (1) :: Debit; False (0) :: Credit
        public bool Type { get; set; }
        public Category Category { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}