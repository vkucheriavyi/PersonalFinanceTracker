using PersonalFinanceTracker.Domain.Entities;

namespace PersonalFinanceTracker.Abstractions.Repositories
{
    public interface ITransactionRepository
    {
        Task AddAsync(Transaction transaction, CancellationToken cancellationToken = default);
    }
}
