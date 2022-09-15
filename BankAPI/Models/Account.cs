using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Intrinsics.X86;

namespace BankAPI.Models
{
    public class Account
    {
        [Key]
        public int AccountId { get; set; }
        [ForeignKey("Person")]
        public int PersonId { get; set; }
        [Required]
        public int balance { get; set; }


    }
}
