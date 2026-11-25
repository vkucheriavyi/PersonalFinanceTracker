using PersonalFinanceTracker.Abstractions.Repositories;
using PersonalFinanceTracker.Data.Context;
using PersonalFinanceTracker.Domain.Entities;

namespace PersonalFinanceTracker.Data.Repositories
{
    public sealed class TransactionRepository : ITransactionRepository
    {
        private readonly PersonalFinanceTrackerDbContext _dbContext;
        public TransactionRepository(PersonalFinanceTrackerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Transaction transaction, CancellationToken cancellationToken = default)
        {
            await _dbContext.Transactions.AddAsync(transaction, cancellationToken);
        }
    }
}
