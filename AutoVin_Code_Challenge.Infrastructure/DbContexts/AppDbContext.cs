using AutoVin_Code_Challenge.Infrastructure.Contract;
using AutoVin_Code_Challenge.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AutoVin_Code_Challenge.Infrastructure.DbContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Bank> Banks { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<CustomerAccount> CustomerAccounts { get; set; }
        public DbSet<TransactionType> TransactionTypes { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>().ToList())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedOn = DateTime.UtcNow;
                        break;

                    case EntityState.Modified:
                        entry.Entity.LastModifiedOn = DateTime.UtcNow;
                        break;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Bank Seeder
            var bankId = Guid.NewGuid();
            modelBuilder.Entity<Bank>().HasData(new Bank 
            { 
                Id = bankId,
                Name = "Test Bank",
                CreatedOn = DateTime.UtcNow,
                LastModifiedOn = DateTime.UtcNow
            });
            #endregion

            #region Account Type Seeder
            var checkingAccountTypeId = Guid.NewGuid();
            modelBuilder.Entity<AccountType>().HasData(new AccountType
            {
                Id = checkingAccountTypeId,
                BankId = bankId,
                Name = "Checking",
                CreatedOn = DateTime.UtcNow,
                LastModifiedOn = DateTime.UtcNow
            });

            var individualInvestmentAccountId = Guid.NewGuid();
            modelBuilder.Entity<AccountType>().HasData(new AccountType
            {
                Id = individualInvestmentAccountId,
                BankId = bankId,
                Name = "Individual Investment",
                CreatedOn = DateTime.UtcNow,
                LastModifiedOn = DateTime.UtcNow
            });

            var corporateInvestmentAccountId = Guid.NewGuid();
            modelBuilder.Entity<AccountType>().HasData(new AccountType
            {
                Id = corporateInvestmentAccountId,
                BankId = bankId,
                Name = "Corporate Investment",
                CreatedOn = DateTime.UtcNow,
                LastModifiedOn = DateTime.UtcNow
            });
            #endregion

            #region Transaction Type Seeder
            var depositId = Guid.NewGuid();
            modelBuilder.Entity<TransactionType>().HasData(new TransactionType 
            { 
                Id = depositId,
                Name = "Deposit",
                CreatedOn = DateTime.UtcNow
            });

            var withdrawalId = Guid.NewGuid();
            modelBuilder.Entity<TransactionType>().HasData(new TransactionType
            {
                Id = withdrawalId,
                Name = "Withdraw",
                CreatedOn = DateTime.UtcNow
            });

            var transferId = Guid.NewGuid();
            modelBuilder.Entity<TransactionType>().HasData(new TransactionType
            {
                Id = transferId,
                Name = "Transfer",
                CreatedOn = DateTime.UtcNow
            });
            #endregion

            #region Customer Seeder
            var customerId = Guid.NewGuid();
            modelBuilder.Entity<Customer>().HasData(new Customer 
            {   
                Id = customerId,
                BankId = bankId,
                FirstName = "Richard",
                Surname = "Aidoo",
                CreatedOn = DateTime.UtcNow
            });

            var accountId = Guid.NewGuid();
            modelBuilder.Entity<CustomerAccount>().HasData(new CustomerAccount { 
                Id = accountId,
                CustomerId=customerId,
                AccountTypeId = individualInvestmentAccountId,
                AccountNumber = "5000123456789"
            });
            #endregion

            #region Transaction Seeder
            modelBuilder.Entity<Transaction>().HasData(new Transaction
            {
                Id = Guid.NewGuid(),
                CustomerAccountId = accountId,
                TransactionTypeId = depositId,
                Amount = 10000,
                CreatedOn = DateTime.UtcNow
            });

            modelBuilder.Entity<Transaction>().HasData(new Transaction
            {
                Id = Guid.NewGuid(),
                CustomerAccountId = accountId,
                TransactionTypeId = withdrawalId,
                Amount = 500,
                CreatedOn = DateTime.UtcNow.AddDays(90)
            });

            modelBuilder.Entity<Transaction>().HasData(new Transaction
            {
                Id = Guid.NewGuid(),
                CustomerAccountId = accountId,
                TransactionTypeId = withdrawalId,
                Amount = 1500,
                CreatedOn = DateTime.UtcNow.AddDays(36)
            });
            #endregion
        }
    }
}
