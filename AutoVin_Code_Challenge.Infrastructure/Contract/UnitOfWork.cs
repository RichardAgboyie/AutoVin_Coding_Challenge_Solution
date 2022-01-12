using AutoVin_Code_Challenge.Infrastructure.DbContexts;
using AutoVin_Code_Challenge.Infrastructure.Repositories;
using AutoVin_Code_Challenge.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;
using System.Threading.Tasks;

namespace AutoVin_Code_Challenge.Infrastructure.Contract
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;

        
        public UnitOfWork(AppDbContext dbContext)
        {
            TransactionReader = new TransactionRepository(dbContext);
            TransactionWriter = new TransactionRepository(dbContext);
            _dbContext = dbContext;
        }

        public ITransactionReader TransactionReader { get; }
        public ITransactionWriter TransactionWriter { get; }

        /// <summary>
        /// Saves all changes in the repository (memory) to database
        /// </summary>
        /// <returns>number of rows affected</returns>
        public async Task<int> SaveChangesAsync() => await _dbContext.SaveChangesAsync(System.Threading.CancellationToken.None);

        /// <summary>
        /// Performs db transactions on a two or more db write jobs
        /// </summary>
        /// <returns></returns>
        public async Task<IDbContextTransaction> TransactionAsync() => await _dbContext.Database.BeginTransactionAsync();
    }
}
