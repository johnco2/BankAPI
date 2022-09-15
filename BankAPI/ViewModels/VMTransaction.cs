using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BankAPI.ViewModels
{
    public class VMTransaction
    {
        public int MontodeTransaction { get; set; }
        public string Comentario { get; set; }
        public string TipoTransaccion { get; set; }
        public DateTime FechaTransaccion { get; set; }
        public int PersonId { get; set; }

        public static Models.Transaction ToEntity(VMTransaction oVMTransaction){
            return new Models.Transaction
            {
                MontodeTransaction = oVMTransaction.MontodeTransaction,
                Comentario = oVMTransaction.Comentario,
                TipoTransaccion = oVMTransaction.TipoTransaccion,
                FechaTransaccion = oVMTransaction.FechaTransaccion,
                PersonId = oVMTransaction.PersonId
            };
        }
    }
}
