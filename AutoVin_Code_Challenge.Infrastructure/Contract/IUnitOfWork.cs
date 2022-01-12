using AutoVin_Code_Challenge.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;
using System.Threading.Tasks;

namespace AutoVin_Code_Challenge.Infrastructure.Contract
{
    public interface IUnitOfWork
    {
        public ITransactionWriter TransactionWriter { get; }
        public ITransactionReader TransactionReader { get; }

        /// <summary>
        /// Saves all changes in the repository (memory) to database
        /// </summary>
        /// <returns>number of rows affected</returns>
        Task<int> SaveChangesAsync();

        /// <summary>
        /// Performs db transactions on a two or more db write jobs
        /// </summary>
        /// <returns></returns>
        Task<IDbContextTransaction> TransactionAsync();
    }
}
