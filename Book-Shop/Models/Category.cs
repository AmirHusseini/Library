using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public class Category
    {
        public Category()
        {
            Books = new HashSet<Book>();
        }
        [Key]
        public int CategoryId { get; set; }
        [Required]
        [DisplayName("Category")]
#nullable enable
        public string? CategoryName { get; set; }

        public ICollection<Book> Books { get; set; }

    }
}
