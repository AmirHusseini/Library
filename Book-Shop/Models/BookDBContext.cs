using DataLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.DataAccess
{
    public class BookDBContext : DbContext
    {
        public BookDBContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Loan> Loans { get; set; }

    }
}
