using PersonalFinanceTracker.Domain.Entities;

namespace PersonalFinanceTracker.Abstractions.Repositories
{
    public interface IAccountRepository
    {
        Task<Account?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task AddAsync(Account account, CancellationToken cancellationToken = default);
    }
}
