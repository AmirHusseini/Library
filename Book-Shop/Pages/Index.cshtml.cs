using Book_Shop.DataAccess;
using DataLibrary.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections;
using System.Collections.Generic;

namespace Book_Shop.Pages
{

    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly iLibrary<Book> iLibrary;
        public IEnumerable<Book> books { get; set; }

        public IndexModel(ILogger<IndexModel> logger,iLibrary<Book> library )
        {
            _logger = logger;
            iLibrary = library;
            
        }

        public void OnGet()
        {
            books = iLibrary.GetAll();
        }
        
    }
}

