using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Xayah.Finances.Contracts.Business.Accounts
{
    public interface IAccountService
    {
        Task AddTransactionsAsync(IEnumerable<IFormFile> files);
    }
}