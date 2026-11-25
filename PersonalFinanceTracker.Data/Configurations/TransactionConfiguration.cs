using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalFinanceTracker.Domain.Entities;

namespace PersonalFinanceTracker.Data.Configurations
{
    public sealed class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable("Transactions");

            builder.HasKey(t => t.Id);

            builder.HasOne<Account>()
                .WithMany()
                .HasForeignKey(t => t.AccountId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<Account>()
                .WithMany()
                .HasForeignKey(t => t.TargetAccountId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(t => t.DateUtc)
                .IsRequired();

            builder.Property(t => t.ExchangeRate)
                .HasPrecision(18, 6);

            builder.HasOne<Category>().WithMany()
                .HasForeignKey(t => t.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(t => t.Amount)
                .HasPrecision(18, 2);

            builder.Property(t => t.Type)
                .HasConversion<string>()
                .HasMaxLength(20);

            builder.Property(t => t.Description)
                .HasMaxLength(500);
        }
    }
}
