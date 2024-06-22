using Core.RequestInputs;
using Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Apps.Controllers
{
    public class TransactionController : Controller
    {
        private readonly TransactionService _transactionService;
        public TransactionController(TransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet("master/getlocation")]
        public async Task<IActionResult> GetAllLocation()
        {
            return Ok(await _transactionService.GetLocation());
        }

        [HttpGet("transaction/getbpkbtransaction")]
        public async Task<IActionResult> GetAllBpkb()
        {
            return Ok(await _transactionService.GetAllBpkb());
        }

        [HttpPost("transaction/createbpkb")]
        public async Task<IActionResult> CreateBpkb([FromBody] BpkbInput input)
        {
            return Ok(await _transactionService.CreateBpkb(input));
        }
    }
}
