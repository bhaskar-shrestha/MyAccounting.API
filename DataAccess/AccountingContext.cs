using Microsoft.EntityFrameworkCore;
using MyAccounting.Api.Models.DbModels;

namespace MyAccounting.Api.DataAccess
{
    public class AccountingContext : DbContext
    {
        public AccountingContext(DbContextOptions<AccountingContext> options) : base(options)
        { }

        public DbSet<TransactionData> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TransactionData>().ToTable("TransactionData");
        }
    }
}