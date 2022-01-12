using AutoVin_Code_Challenge.Infrastructure.DbContexts;
using AutoVin_Code_Challenge.Infrastructure.Entities;
using AutoVin_Code_Challenge.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AutoVin_Code_Challenge.Infrastructure.Repositories
{
    public class TransactionRepository : ITransactionWriter, ITransactionReader
    {
        private readonly AppDbContext _dbContext;
        public TransactionRepository(AppDbContext dbContext) => _dbContext = dbContext;

        /// <summary>
        ///  Gets Transactions as queryable with no tracking of changes
        /// </summary>
        /// <returns></returns>
        public IQueryable<Transaction> GetQueryable()
            => _dbContext.Transactions
            .Include(t => t.TransactionType)
            .Include(t => t.CustomerAccount.Customer)
            .Include(t => t.CustomerAccount)
            .ThenInclude(c => c.AccountType)
            .ThenInclude(a => a.Bank)
            .AsNoTrackingWithIdentityResolution();

        /// <summary>
        /// Attaches a new transaction's record into repository
        /// </summary>
        /// <param name="sale"></param>
        public async Task AddAsync(Transaction tran) => await _dbContext.Transactions.AddAsync(tran);
    }
}
