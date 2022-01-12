using AutoVin_Code_Challenge.Core.Features.Transactions.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AutoVin_Code_Challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionCommand _tranCommand;
        private readonly ITransactionQueries _tranQueries;
        public TransactionController(ITransactionCommand tranCommand, ITransactionQueries tranQueries)
        {
            _tranCommand = tranCommand;
            _tranQueries = tranQueries;
        }
        [HttpPost]
        public async Task<IActionResult> Post()
        {
            var result = await _tranCommand.SaveAsync(new() 
            { 
                Amount = 500, 
                AccountType = Shared.Enums.AccountType.Individual,
                TransactionTypeId = System.Guid.Parse("FC1EB2A3-15E2-473F-849F-EBE128716A05"),
                CustomerAccountId = System.Guid.Parse("AE7E0C28-FE19-44FD-8FB5-6A9EB8C7046B")              
            });
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _tranQueries.GetAll());
    }
}
