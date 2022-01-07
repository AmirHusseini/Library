using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public class Customer
    {
        public Customer()
        {
            Loans = new HashSet<Loan>();
        }
        [Key]
        public int CustomerId { get; set; }
        [Required]
        [DisplayName("Name")]
#nullable enable
        public string? CustomerName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Email")]
        public string? Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Password")]
        public string? Password { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [DisplayName("Tel")]
        public int? Tel { get; set; }
        [Required]
        [DisplayName("Address")]
        public string? Address { get; set; }
        public ICollection<Loan> Loans { get; set; }
    }
}
