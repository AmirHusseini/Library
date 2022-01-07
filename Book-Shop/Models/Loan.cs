using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public class Loan
    {
        [Key]
        public int LoanId { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Date of Loan")]
        public DateTime? LoanDate { get; set; }
        [Required]
        [DisplayName("Customer Name")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;
        [Required]
        [DisplayName("Book Title")]
        public int BookId { get; set; }

        public Book Book { get; set; } = null!;
    }
}
