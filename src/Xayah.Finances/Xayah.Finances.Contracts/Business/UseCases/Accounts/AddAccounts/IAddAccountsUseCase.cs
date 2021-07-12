using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Xayah.Finances.Contracts.Business.UseCases.Accounts.AddAccounts
{
    public interface IAddAccountsUseCase
    {
        Task<IList<AddAccountResponse>> AddAccountsAsync(IList<IFormFile> files);
    }
}