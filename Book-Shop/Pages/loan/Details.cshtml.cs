using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataLibrary.DataAccess;
using DataLibrary.Models;

namespace Book_Shop.Pages.loan
{
    public class DetailsModel : PageModel
    {
        private readonly DataLibrary.DataAccess.BookDBContext _context;

        public DetailsModel(DataLibrary.DataAccess.BookDBContext context)
        {
            _context = context;
        }

        public Loan Loan { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Loan = await _context.Loans
                .Include(l => l.Book)
                .Include(l => l.Customer).FirstOrDefaultAsync(m => m.LoanId == id);

            if (Loan == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
