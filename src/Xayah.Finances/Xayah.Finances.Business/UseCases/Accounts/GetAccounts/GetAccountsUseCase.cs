using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xayah.Finances.Contracts.Business.UseCases.Accounts.GetAccounts;
using Xayah.Finances.Contracts.Data.Repository;
using Xayah.Finances.Domain.Accounts;

namespace Xayah.Finances.Business.UseCases.Accounts.GetAccounts
{
    public class GetAccountsUseCase : IGetAccountsUseCase
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Account> _accountRepository;

        public GetAccountsUseCase(IMapper mapper, IRepository<Account> accountRepository)
        {
            _mapper = mapper;
            _accountRepository = accountRepository;
        }

        public async Task<IList<GetAccountResponse>> GetAccountsAsync()
        {
            var accounts = await _accountRepository.ListAsync();

            return _mapper.Map<IList<GetAccountResponse>>(accounts);
        }
    }
}