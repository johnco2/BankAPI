using BankAPI.Models;

namespace BankAPI.Repository
{
    public interface IAccountRepository
    {
        Task<IEnumerable<Account>> GetAccounts();
        Task<Account> GetAccountById(int id);
        Task<Account> InsertAccount(Account objAccount);
        bool DeleteAccount(int id);
    }
}
