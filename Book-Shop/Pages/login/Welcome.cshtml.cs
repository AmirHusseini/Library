using Book_Shop.DataAccess;
using DataLibrary.DataAccess;
using DataLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Shop.Pages
{
    public class WelcomeModel : PageModel
    {
        private readonly BookDBContext bookDBContext;
        

        public WelcomeModel(BookDBContext bookDBContext)
        {
            this.bookDBContext = bookDBContext;        
        }

        public string Username { get; set; }
        public IList<Loan> Loan { get; set; }

        public async Task OnGetAsync()
        {
            Username = HttpContext.Session.GetString("username");

            Loan = await bookDBContext.Loans.Where(x => x.Customer.Email.Equals(Username))                
                .Include(l => l.Book).ToListAsync();
        }
        
        public IActionResult OnGetLogout()
        {
            HttpContext.Session.Remove("username");
            return RedirectToPage("../Index");
        }
    }
}
