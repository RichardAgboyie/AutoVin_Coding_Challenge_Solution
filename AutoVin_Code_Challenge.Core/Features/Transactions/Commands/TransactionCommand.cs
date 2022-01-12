using AutoVin_Code_Challenge.Core.Features.Transactions.Interfaces;
using AutoVin_Code_Challenge.Infrastructure.Contract;
using AutoVin_Code_Challenge.Infrastructure.Entities;
using AutoVin_Code_Challenge.Shared.DTO.Request;
using AutoVin_Code_Challenge.Shared.DTO.Response;
using System.Threading.Tasks;

namespace AutoVin_Code_Challenge.Core.Features.Transactions.Commands
{
    public class TransactionCommand : ITransactionCommand
    {
        private readonly IUnitOfWork _unitOfWork;
        public TransactionCommand(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        /// <summary>
        /// Saves all transactions
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ResponseHeader> SaveAsync(TransactionRequest request)
        {
            var tran = new SingleResponse<Transaction>();
            switch (request.AccountType)
            {
                case Shared.Enums.AccountType.Checking:
                case Shared.Enums.AccountType.Corporate:
                    tran = DepositOrTransfer(request);
                    break;
                case Shared.Enums.AccountType.Individual:
                    tran = Withdrawal(request);
                    break;
                default:
                    break;
            }

            if (tran.ResponseHeader.Success)
            {
                await _unitOfWork.TransactionWriter.AddAsync(tran.ResponseBody);
                var numRows = await _unitOfWork.SaveChangesAsync();
                return numRows > 0 ? new() { Success = true, Message = "Transaction completed." } : new() { Message = "Transaction failed."};
            }

            return tran.ResponseHeader;
        }

        /// <summary>
        /// private method to handle transaction entity builder
        /// </summary>
        /// <param name="request"></param>
        /// <returns>a Transaction object</returns>
        private static Transaction TransactionData(TransactionRequest request)
        {
            return new()
            {
                Amount = request.Amount,
                CustomerAccountId = request.CustomerAccountId,
                TransactionTypeId = request.TransactionTypeId
            };
        }

        /// <summary>
        /// private method to handle Deposit/Transfer transaction data builder
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private static SingleResponse<Transaction> DepositOrTransfer(TransactionRequest request)
            =>  new()
            {
                ResponseHeader = new() { Success = true},
                ResponseBody = TransactionData(request)
            };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private static SingleResponse<Transaction> Withdrawal(TransactionRequest request) 
        {
            if (request.Amount > 500 && request.AccountType == Shared.Enums.AccountType.Individual) 
                return new()
                {
                    ResponseHeader = new() { Message = "Withdrawal limit exceeded fro this account. Withdrawal limit is 500 dollars." }
                };

            return new()
            {
                ResponseHeader = new() { Success = true},
                ResponseBody = TransactionData(request)
            };
        }
    }
}
