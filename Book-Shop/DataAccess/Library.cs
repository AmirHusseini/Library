using DataLibrary.DataAccess;
using DataLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Book_Shop.DataAccess
{
    public class Library : iLibrary <Book>
    {
        private BookDBContext DBContextid { get; set; }
        public Library(BookDBContext dBContext)
        {
            DBContextid = dBContext;
        }

        public IEnumerable<Book> GetAll()
        {
            return DBContextid.Books;
                
        }

        public Book GetById(int id)
        {
            var book = DBContextid.Books.Find(id);
            return book;
        }
    }
}
