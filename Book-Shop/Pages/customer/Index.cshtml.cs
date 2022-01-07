using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataLibrary.Models;
using System;
using System.Linq;

namespace Book_Shop.Pages.customer
{
    public class IndexModel : PageModel
    {
        private readonly DataLibrary.DataAccess.BookDBContext _context;

        public IndexModel(DataLibrary.DataAccess.BookDBContext context)
        {
            _context = context;
        }

        public IList<Customer> Customer { get;set; }
        public string CurrentFilter { get; set; }
        public string NameSort { get; set; }

        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            CurrentFilter = searchString;

            var c = from s in _context.Customers
                    select s;

            switch (sortOrder)
            {
                case "name_desc":
                   c = c.OrderByDescending(s => s.CustomerName);
                    break;
                default:
                    c = c.OrderBy(s => s.CustomerName);
                    break;
            }
            if (!String.IsNullOrEmpty(searchString))
            {
                c = c.Where(s => s.CustomerName.Contains(searchString));
            }
            Customer = await c.ToListAsync();
        }
    }
}
