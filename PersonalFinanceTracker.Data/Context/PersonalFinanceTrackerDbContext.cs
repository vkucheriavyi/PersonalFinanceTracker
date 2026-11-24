using Microsoft.EntityFrameworkCore;
using PersonalFinanceTracker.Abstractions.Repositories;
using PersonalFinanceTracker.Domain.Entities;

namespace PersonalFinanceTracker.Data.Context
{
    public class PersonalFinanceTrackerDbContext : DbContext, IUnitOfWork
    {
        public PersonalFinanceTrackerDbContext(DbContextOptions<PersonalFinanceTrackerDbContext> options) : base(options) { }

        public DbSet<Account> Accounts => Set<Account>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Transaction> Transactions => Set<Transaction>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PersonalFinanceTrackerDbContext).Assembly);
        }

    }
}
