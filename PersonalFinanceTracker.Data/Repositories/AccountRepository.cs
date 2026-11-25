using Microsoft.EntityFrameworkCore;
using PersonalFinanceTracker.Abstractions.Repositories;
using PersonalFinanceTracker.Data.Context;
using PersonalFinanceTracker.Domain.Entities;

namespace PersonalFinanceTracker.Data.Repositories
{
    public sealed class AccountRepository : IAccountRepository
    {
        private readonly PersonalFinanceTrackerDbContext _dbContext;

        public AccountRepository(PersonalFinanceTrackerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Account account, CancellationToken cancellationToken = default) => await _dbContext.Accounts.AddAsync(account, cancellationToken);

        public async Task<Account?> GetByIdAsync(int id, CancellationToken cancellationToken = default) =>
            await _dbContext.Accounts.FirstOrDefaultAsync(a => a.Id == id, cancellationToken);

    }
}
