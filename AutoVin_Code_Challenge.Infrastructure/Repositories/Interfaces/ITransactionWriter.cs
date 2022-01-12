using AutoVin_Code_Challenge.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoVin_Code_Challenge.Infrastructure.Repositories.Interfaces
{
    public interface ITransactionWriter
    {
        /// <summary>
        /// Attaches a new transaction's record into repository
        /// </summary>
        /// <param name="sale"></param>
        Task AddAsync(Transaction tran);
    }
}
