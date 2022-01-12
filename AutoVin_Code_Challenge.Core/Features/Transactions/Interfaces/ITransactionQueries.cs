using AutoVin_Code_Challenge.Shared.DTO.Response;
using System.Threading.Tasks;

namespace AutoVin_Code_Challenge.Core.Features.Transactions.Interfaces
{
    public interface ITransactionQueries
    {
        /// <summary>
        /// Get all transaction details
        /// </summary>
        /// <returns></returns>
        Task<ListResponse<TransactionResponse>> GetAll();
    }
}
