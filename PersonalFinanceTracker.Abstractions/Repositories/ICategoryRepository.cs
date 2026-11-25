using PersonalFinanceTracker.Domain.Entities;

namespace PersonalFinanceTracker.Abstractions.Repositories
{
    public interface ICategoryRepository
    {
        Task<Category?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task CreateAsync(Category category, CancellationToken cancellationToken = default);
    }
}
