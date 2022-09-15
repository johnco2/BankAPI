using BankAPI.Controllers;
using BankAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace BankAPI.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly ApiDbContext _apiDbContext;

        public TransactionRepository(ApiDbContext context)
        {
            _apiDbContext = context ?? throw new ArgumentNullException(nameof(context));
        }

        //public async Task<Transaction> DiscountTransaction(int id)
        //{
        //    int result = 0;
        //    bool retorno = false;
        //    var transaction = _apiDbContext.Transactions.Find(id);
        //    var account = _apiDbContext.Accounts.Find(id);
        //    if(account != null)
        //    {
        //        result = account.balance - transaction.MontodeTransaction;
        //        account.balance = result;
        //        _apiDbContext.Entry(account).State = EntityState.Modified;
        //        await _apiDbContext.SaveChangesAsync();
        //        retorno = true;
        //    }
        //    else
        //    {
        //        retorno = false;
        //    }
        //    return transaction;
        //}

        public bool DeleteTransaction(int id)
        {
            bool result = false;
            var transaction = _apiDbContext.Transactions.Find(id);
            if (transaction != null)
            {
                _apiDbContext.Entry(transaction).State = EntityState.Deleted;
                _apiDbContext.SaveChanges();
                result = true;

            }
            else
            {
                result = false;
            }
            return result;

        }

        public async Task<Transaction> GetTransactionById(int id)
        {
            return await _apiDbContext.Transactions.FindAsync(id);
        }

        public async Task<IEnumerable<Transaction>> GetTransactions()
        {
            return await _apiDbContext.Transactions.ToListAsync();
        }

        public async Task<Transaction> InsertTransaction(int id, Transaction objTransaction)
        {
            //_apiDbContext.Transactions.Add(objTransaction);
            //await _apiDbContext.SaveChangesAsync();
            //return objTransaction;
            int result = 0;
            bool retorno = false;
            //var transaction = _apiDbContext.Transactions.Find(id);
            var account = _apiDbContext.Accounts.Find(id);
            if(account != null)
            {
                result = account.balance - objTransaction.MontodeTransaction;
                account.balance = result;
                _apiDbContext.Entry(account).State = EntityState.Modified;
                _apiDbContext.Transactions.Add(objTransaction);
                await _apiDbContext.SaveChangesAsync();
                retorno = true;
            }
            else
            {
                retorno = false;
            }
            return objTransaction;
        }

        public async Task<Transaction> UpdateTransaction(Transaction objTransaction)
        {
            _apiDbContext.Entry(objTransaction).State = EntityState.Modified;
            await _apiDbContext.SaveChangesAsync();
            return objTransaction;
        }
    }
}
