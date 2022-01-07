using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataLibrary.DataAccess;
using DataLibrary.Models;

namespace Book_Shop.Pages.loan
{
    public class EditModel : PageModel
    {
        private readonly DataLibrary.DataAccess.BookDBContext _context;

        public EditModel(DataLibrary.DataAccess.BookDBContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["BookId"] = new SelectList(_context.Books, "BookId", "BookName");
           ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Loan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoanExists(Loan.LoanId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool LoanExists(int id)
        {
            return _context.Loans.Any(e => e.LoanId == id);
        }
    }
}
