using AutoVin_Code_Challenge.Core.Features.Transactions.Interfaces;
using AutoVin_Code_Challenge.Infrastructure.Contract;
using AutoVin_Code_Challenge.Infrastructure.Entities;
using AutoVin_Code_Challenge.Shared.DTO.Response;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AutoVin_Code_Challenge.Core.Features.Transactions.Queries
{
    public class TransactionQueries : ITransactionQueries
    {
        private readonly IUnitOfWork _unitOfWork;
        public TransactionQueries(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        /// <summary>
        /// Get all transaction details
        /// </summary>
        /// <returns></returns>
        public async Task<ListResponse<TransactionResponse>> GetAll()
        {
            var trans =await _unitOfWork.TransactionReader.GetQueryable().ToListAsync();
            return new()
            {
                ResponseHeader = new() { Success = true },
                ResponseBodyList = trans.Select(TransactionEntity)
            };
        }

        private static TransactionResponse TransactionEntity(Transaction tran)
        {
            return new()
            {
                Bank = tran.CustomerAccount.AccountType.Bank.Name,
                FirstName = tran.CustomerAccount.Customer.FirstName,
                OtherName = tran.CustomerAccount.Customer.OtherName,
                Surname = tran.CustomerAccount.Customer.Surname,
                AccountType = tran.CustomerAccount.AccountType.Name,
                AccountNumber = tran.CustomerAccount.AccountNumber,
                TransactionType = tran.TransactionType.Name,
                Amount = tran.Amount
            };
        }
    }
}
