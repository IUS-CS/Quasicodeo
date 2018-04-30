using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TooBroke.Data;
using TooBroke.Models.CalculatorViewModels;

namespace TooBroke.Pages.Goals
{
    public class IndexModel : PageModel
    {
        private readonly TooBroke.Data.CalculatorDbContext _context;

        public IndexModel(TooBroke.Data.CalculatorDbContext context)
        {
            _context = context;
        }
    }
}
