using PersonalFinanceTracker.Constants.Enums;
using PersonalFinanceTracker.Domain.Exceptions;

namespace PersonalFinanceTracker.Domain.Entities
{
    public class Transaction
    {
        public int Id { get; private set; }
        public int AccountId { get; private set; }
        public int? TargetAccountId { get; private set; }
        public int? CategoryId { get; private set; }
        public TransactionType Type { get; private set; }
        public decimal Amount { get; private set; }
        public decimal? ExchangeRate { get; private set; }
        public string? Description { get; private set; }
        public DateTime DateUtc { get; private set; }

        private Transaction() { }

        public static Transaction CreateIncome(Account account, Category category, decimal amount, string? description, DateTime? dateUtc)
        {
            if (account == null) throw new DomainException("Account can't be null");
            if (category == null) throw new DomainException("Category can't be null");
            if (amount <= 0) throw new DomainException("Amount must be greater than 0");
            if (category.Type != TransactionType.Income) throw new DomainException("Invalid category type for income transaction");

            return new()
            {
                AccountId = account.Id,
                CategoryId = category.Id,
                Type = TransactionType.Income,
                Amount = amount,
                Description = description,
                DateUtc = dateUtc ?? DateTime.UtcNow
            };
        }

        public static Transaction CreateExpense(Account account, Category category, decimal amount, string? description, DateTime? dateUtc)
        {
            if (account == null) throw new DomainException("Account can't be null");
            if (category == null) throw new DomainException("Category can't be null");
            if (amount <= 0) throw new DomainException("Amount must be greater than 0");
            if (category.Type != TransactionType.Expense) throw new DomainException("Invalid category type for expense transaction");

            return new()
            {
                AccountId = account.Id,
                CategoryId = category.Id,
                Type = TransactionType.Expense,
                Amount = amount,
                Description = description,
                DateUtc = dateUtc ?? DateTime.UtcNow
            };
        }

        public static Transaction CreateTransfer(Account source, Account target, decimal amount, DateTime? dateUtc, decimal? exchangeRate, string? description)
        {
            if (source == null) throw new DomainException("Source can't be null");
            if (target == null) throw new DomainException("Target can't be null");
            if (ReferenceEquals(source, target) || (source.Id != 0 && source.Id == target.Id)) throw new DomainException("Source and target can't be the same");

            if (amount <= 0) throw new DomainException("Amount must be greater than 0");
            if (source.Currency != target.Currency && (!exchangeRate.HasValue || exchangeRate <= 0)) throw new DomainException("Exchange rate must be greater than 0 for different currencies");

            return new Transaction
            {
                AccountId = source.Id,
                TargetAccountId = target.Id,
                Type = TransactionType.Transfer,
                Amount = amount,
                ExchangeRate = source.Currency == target.Currency ? null : exchangeRate,
                Description = description,
                DateUtc = dateUtc ?? DateTime.UtcNow
            };

        }
    }
}
