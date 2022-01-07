using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataLibrary.DataAccess;
using DataLibrary.Models;

namespace Book_Shop.Pages.book
{
    public class IndexModel : PageModel
    {
        private readonly DataLibrary.DataAccess.BookDBContext _context;

        public IndexModel(DataLibrary.DataAccess.BookDBContext context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; }
        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string autho { get; set; }
        public string CurrentFilter { get; set; }
        public string catsort { get; set; }
        public async Task OnGetAsync(string sortOrder, string searchString)
        {
           
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";
            catsort = String.IsNullOrEmpty(sortOrder) ? "cats" : "";
            autho = String.IsNullOrEmpty(sortOrder) ? "auth" : "";
            CurrentFilter = searchString;

            var b = from s in _context.Books.Include(l => l.Category)
                                             select s;

            switch (sortOrder)
            {
                case "name_desc":
                    b = b.OrderByDescending(s => s.BookName);
                    break;
                case "Date":
                    b = b.OrderBy(s => s.PublishedDate);
                    break;
                case "date_desc":
                    b = b.OrderByDescending(s => s.PublishedDate);
                    break;
                case "auth":
                    b = b.OrderByDescending(s => s.AuthorName);
                    break;
                case "cats":
                    b = b.OrderByDescending(s => s.Category);
                    break;
                default:
                    b = b.OrderBy(s => s.BookId);
                    break;
            }
            if (!String.IsNullOrEmpty(searchString))
            {
                b = b.Where(s => s.BookName.Contains(searchString)
                                       || s.AuthorName.Contains(searchString));
            }
            Book = await b.Include(c => c.Category).AsNoTracking().ToListAsync();
        }
        
    }
}
