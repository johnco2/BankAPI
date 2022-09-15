using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankAPI.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }
        [Required]
        public int MontodeTransaction { get; set; }
        [Required]
        public string Comentario { get; set; }
        [Required]
        public string TipoTransaccion { get; set; }
        [Required]
        public DateTime FechaTransaccion { get; set; }
        [ForeignKey("Person")]
        public int PersonId { get; set; }
    }
}
