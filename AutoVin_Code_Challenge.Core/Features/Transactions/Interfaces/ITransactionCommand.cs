using AutoVin_Code_Challenge.Shared.DTO.Request;
using AutoVin_Code_Challenge.Shared.DTO.Response;
using System.Threading.Tasks;

namespace AutoVin_Code_Challenge.Core.Features.Transactions.Interfaces
{
    public interface ITransactionCommand
    {
        /// <summary>
        /// Saves all transactions
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ResponseHeader> SaveAsync(TransactionRequest request);
    }
}
