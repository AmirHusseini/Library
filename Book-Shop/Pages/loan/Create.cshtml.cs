using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataLibrary.DataAccess;
using DataLibrary.Models;

namespace Book_Shop.Pages.loan
{
    public class CreateModel : PageModel
    {
        private readonly DataLibrary.DataAccess.BookDBContext _context;
        public List<Book> AvaBooks { get; set;} = new List<Book>();
        public List<Book> books { get; set;}
        public CreateModel(DataLibrary.DataAccess.BookDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            books = _context.Books.ToList();
            foreach (var item in books)
            {

                if (item.IsAvailable == true)
                {
                    AvaBooks.Add(item);
                }
            }
            ViewData["BookId"] = new SelectList(AvaBooks, "BookId", "BookName");
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerName");
            return Page();
        }

        [BindProperty]
        public Loan Loan { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Loan.Book = _context.Books.Find(Loan.BookId);
            Loan.Book.IsAvailable = false;
            

            _context.Loans.Add(Loan);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
