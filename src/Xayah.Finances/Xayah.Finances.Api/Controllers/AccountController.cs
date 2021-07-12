using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xayah.Finances.Api.Shared;
using Xayah.Finances.Contracts.Business.UseCases.Accounts.AddAccounts;
using Xayah.Finances.Contracts.Business.UseCases.Accounts.GetAccounts;

namespace Xayah.Finances.Api.Controllers
{
    [Route("accounts")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAddAccountsUseCase _AddAccountsUseCase;
        private readonly IGetAccountsUseCase _getAccountsUseCase;

        public AccountController(IAddAccountsUseCase AddAccountsUseCase,
                                 IGetAccountsUseCase getAccountsUseCase)
        {
            _AddAccountsUseCase = AddAccountsUseCase;
            _getAccountsUseCase = getAccountsUseCase;
        }

        /// <summary> Add Accounts by files</summary>
        /// <response code="201">Created</response>
        /// <response code="400">Request invalid</response>
        /// <response code="401">No authorization of the resource</response>
        /// <response code="404">Resource not found</response>
        /// <response code="422">Business error</response>
        /// <response code="500">Internal server error</response>
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(IList<AddAccountResponse>))]
        [ProducesResponseType(400, Type = typeof(ErrorDto))]
        [ProducesResponseType(401, Type = typeof(ErrorDto))]
        [ProducesResponseType(404, Type = typeof(ErrorDto))]
        [ProducesResponseType(422, Type = typeof(ErrorDto))]
        [ProducesResponseType(500, Type = typeof(ErrorDto))]
        public async Task<IActionResult> AddAccounts(IList<IFormFile> files)
        {
            return Created("", await _AddAccountsUseCase.AddAccountsAsync(files));
        }

        /// <summary> Add Accounts by files</summary>
        /// <response code="200">Ok</response>
        /// <response code="400">Request invalid</response>
        /// <response code="401">No authorization of the resource</response>
        /// <response code="404">Resource not found</response>
        /// <response code="422">Business error</response>
        /// <response code="500">Internal server error</response>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IList<GetAccountResponse>))]
        [ProducesResponseType(400, Type = typeof(ErrorDto))]
        [ProducesResponseType(401, Type = typeof(ErrorDto))]
        [ProducesResponseType(404, Type = typeof(ErrorDto))]
        [ProducesResponseType(422, Type = typeof(ErrorDto))]
        [ProducesResponseType(500, Type = typeof(ErrorDto))]
        public async Task<IActionResult> GetAccounts()
        {
            return Ok(await _getAccountsUseCase.GetAccountsAsync());
        }
    }
}