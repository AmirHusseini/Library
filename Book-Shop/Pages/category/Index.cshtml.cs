using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataLibrary.DataAccess;
using DataLibrary.Models;

namespace Book_Shop.Pages.category
{
    public class IndexModel : PageModel
    {
        private readonly DataLibrary.DataAccess.BookDBContext _context;

        public IndexModel(DataLibrary.DataAccess.BookDBContext context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; }

        public async Task OnGetAsync()
        {
            Category = await _context.Categories.ToListAsync();
        }
    }
}
