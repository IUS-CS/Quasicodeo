using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TooBroke.Models.CalculatorViewModels
{
    public class TransactionEntries
    {
        public int ID { get; set; }
        public String ApplicationUserID { get; set; }
        public String Title { get; set; }
        public int Amount { get; set; }
        //True (1) :: Debit; False (0) :: Credit
        public bool Type { get; set; }
        public Categories Category { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}
