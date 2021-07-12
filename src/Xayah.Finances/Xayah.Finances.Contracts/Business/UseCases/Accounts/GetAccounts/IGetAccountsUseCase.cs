using System.Collections.Generic;
using System.Threading.Tasks;

namespace Xayah.Finances.Contracts.Business.UseCases.Accounts.GetAccounts
{
    public interface IGetAccountsUseCase
    {
        Task<IList<GetAccountResponse>> GetAccountsAsync();
    }
}