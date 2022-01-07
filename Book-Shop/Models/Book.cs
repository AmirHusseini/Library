using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLibrary.Models
{
    public class Book
    {
        public Book()
        {
            Loans = new HashSet<Loan>();
        }
        [Key]
        public int BookId { get; set; }
        [Required]
        [DisplayName("Title")]
        public string BookName { get; set; } = null!;
        [DisplayName("Date Published")]
        [DataType(DataType.Date)]
        public DateTime PublishedDate { get; set; }
        [Required]
        [DisplayName("Author")]
        public string AuthorName { get; set; } = null!;
        [Required]
        [DisplayName("Available")]        
        public bool IsAvailable { get; set; }
        [Column(TypeName = "varchar(MAX)")]
        public string Imageurl { get; set; }
        [Required]
        [DisplayName("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;
        public ICollection<Loan> Loans { get; set; }
    }
}
