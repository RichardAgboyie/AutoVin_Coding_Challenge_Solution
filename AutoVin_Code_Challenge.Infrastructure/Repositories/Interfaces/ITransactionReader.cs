using System.Linq;
using AutoVin_Code_Challenge.Infrastructure.Entities;

namespace AutoVin_Code_Challenge.Infrastructure.Repositories.Interfaces
{
    public interface ITransactionReader
    {
        /// <summary>
        ///  Gets Transactions as queryable with no tracking of changes
        /// </summary>
        /// <returns></returns>
       IQueryable<Transaction> GetQueryable();
    }
}
