using Microsoft.EntityFrameworkCore;
using PersonalFinanceTracker.Abstractions.Repositories;
using PersonalFinanceTracker.Data.Context;
using PersonalFinanceTracker.Domain.Entities;

namespace PersonalFinanceTracker.Data.Repositories
{
    public sealed class CategoryRepository : ICategoryRepository
    {
        private readonly PersonalFinanceTrackerDbContext _dbContext;
        public CategoryRepository(PersonalFinanceTrackerDbContext dbContext) { _dbContext = dbContext; }

        public async Task CreateAsync(Category category, CancellationToken cancellationToken = default) =>
            await _dbContext.Categories.AddAsync(category, cancellationToken);

        public async Task<Category?> GetByIdAsync(int id, CancellationToken cancellationToken = default) =>
            await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
    }
}
