using BankAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BankAPI.Repository
{
    public class AccountRepository : IAccountRepository
    {
        readonly ApiDbContext _apiDbContext;

        public AccountRepository(ApiDbContext context)
        {
            _apiDbContext = context ?? throw new ArgumentNullException(nameof(context));
        }

        public bool DeleteAccount(int id)
        {
            bool result = false;
            var account = _apiDbContext.Accounts.Find(id);
            if(result != null)
            {
                _apiDbContext.Entry(account).State = EntityState.Deleted;
                _apiDbContext.SaveChanges();
                result=true;
            }
            else
            {
                result = false;
            }
            return result;
        }

        public async Task<Account> GetAccountById(int id)
        {
            return await _apiDbContext.Accounts.FindAsync(id);
        }

        public async Task<IEnumerable<Account>> GetAccounts()
        {
            return await _apiDbContext.Accounts.ToListAsync();
        }

        public async Task<Account> InsertAccount(Account objAccount)
        {
            _apiDbContext.Accounts.Add(objAccount);
            await _apiDbContext.SaveChangesAsync();
            return objAccount;
        }
    }
}
