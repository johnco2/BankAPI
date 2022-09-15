using BankAPI.Models;

namespace BankAPI.Repository
{
    public interface ITransactionRepository
    {
        Task<IEnumerable<Transaction>> GetTransactions();
        Task<Transaction> GetTransactionById(int id);
        //Task<Transaction> DiscountTransaction(int id);
        Task<Transaction> InsertTransaction (int id, Transaction objTransaction);
        Task<Transaction> UpdateTransaction (Transaction objTransaction);
        bool DeleteTransaction (int id);
    }
}
