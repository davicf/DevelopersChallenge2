using System.Collections.Generic;
using Xayah.Finances.Contracts.Business.UseCases.Accounts.AddAccounts;
using Xayah.Finances.Domain.Accounts;

namespace Xayah.Finances.Business.UseCases.Accounts.AddAccounts
{
    public partial class AddAccountsUseCase
    {
        private IList<AddAccountResponse> ResponseReturn(List<Account> accounts)
        {
            var response = new List<AddAccountResponse>();

            foreach (var account in accounts)
            {
                response.Add(new AddAccountResponse { Id = account.Id });
            }

            return response;
        }
    }
}