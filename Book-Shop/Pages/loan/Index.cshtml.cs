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
    public class IndexModel : PageModel
    {
        private readonly DataLibrary.DataAccess.BookDBContext _context;

        public IndexModel(DataLibrary.DataAccess.BookDBContext context)
        {
            _context = context;
        }

        public IList<Loan> Loan { get;set; }
        public string CurrentFilter { get; set; }
        public string DateSort { get; set; }
        public string NameSort { get; set; }
        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";

            CurrentFilter = searchString;

            var c = from s in _context.Loans.Include(l => l.Book).Include(l => l.Customer)
                    select s;

            switch (sortOrder)
            {
                case "name_desc":
                    c = c.OrderByDescending(s => s.Customer.CustomerName);
                    break;
                case "Date":
                    c = c.OrderBy(s => s.LoanDate);
                    break;
                case "date_desc":
                    c = c.OrderByDescending(s => s.LoanDate);
                    break;
                default:
                    c = c.OrderBy(s => s.Customer.CustomerName);
                    break;
            }
            if (!String.IsNullOrEmpty(searchString))
            {
                c = c.Where(s => s.Customer.CustomerName.Contains(searchString));
            }
            Loan = await c
                .Include(l => l.Book)
                .Include(l => l.Customer).ToListAsync();
        }
    }
}
