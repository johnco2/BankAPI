using System.ComponentModel.DataAnnotations;

namespace BankAPI.Models
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string UserEmail { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Cedula { get; set; }

        public ICollection<Transaction> Transactions { get; set; }
        public ICollection<Account> Accounts { get; set; }
    }
}
