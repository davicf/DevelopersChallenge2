using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xayah.Finances.Contracts.Business.Accounts;

namespace Xayah.Finances.Api.Controllers
{
    [Route("accounts")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("transaction")]
        public async Task<IActionResult> AddTransactions(IEnumerable<IFormFile> files)
        {
            await _accountService.AddTransactionsAsync(files);

            return NoContent();
        }
    }
}