using BankAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BankAPI
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }
        public DbSet<Person> People { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Account> Accounts { get; set; }
    }
}
