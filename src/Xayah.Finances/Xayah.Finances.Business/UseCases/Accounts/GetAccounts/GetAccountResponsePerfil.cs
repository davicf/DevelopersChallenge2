using AutoMapper;
using Xayah.Finances.Contracts.Business.UseCases.Accounts.GetAccounts;
using Xayah.Finances.Domain.Accounts;
using Xayah.Finances.Domain.Accounts.Transactions;

namespace Xayah.Finances.Business.UseCases.Accounts.GetAccounts
{
    public class GetAccountResponsePerfil : Profile
    {
        public GetAccountResponsePerfil()
        {
            CreateMap<Account, GetAccountResponse>();
            CreateMap<Transaction, TransactionResponse>();
        }
    }
}