using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataLibrary.DataAccess;
using DataLibrary.Models;
using Microsoft.AspNetCore.Http;

namespace Book_Shop.Pages.login
{
    public class loginModel : PageModel
    {
        private readonly DataLibrary.DataAccess.BookDBContext _context;

        public loginModel(DataLibrary.DataAccess.BookDBContext context)
        {
            _context = context;
        }

        public IList<Loan> Loan { get;set; }
        public string Msg { get; set; }
        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string Password { get; set; }
        public void OnGet()
        {
                       
        }
        public IActionResult OnPost()
        {
            foreach (var item in _context.Customers)
            {

                if (Email.Equals(item.Email) && Password.Equals(item.Password))
                {
                    HttpContext.Session.SetString("username", Email);

                    return RedirectToPage("Welcome");
                }
                else
                {
                    Msg = "Invalid";
                   
                }
            }
            return Page();
        }
    }
}
