using DataLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Book_Shop.DataAccess
{
    public interface iLibrary <T>
    {
        IEnumerable<Book> GetAll();
        T GetById(int id);
    }
}
