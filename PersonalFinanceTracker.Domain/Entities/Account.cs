using PersonalFinanceTracker.Constants.Enums;
using PersonalFinanceTracker.Domain.Exceptions;

namespace PersonalFinanceTracker.Domain.Entities
{
    public class Account
    {
        private Account() { }

        public Account(decimal initialBalance, string name, Currency currency)
        {
            if (initialBalance < 0)
                throw new DomainException("Initial balance can't be negative");

            if (string.IsNullOrWhiteSpace(name))
                throw new DomainException("Account name can't be null or whitespace");

            this.Balance = initialBalance;
            this.Name = name.Trim();
            this.Currency = currency;
            CreatedAt = DateTime.UtcNow;
        }

        public int Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public Currency Currency { get; private set; }
        public decimal Balance { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public void Deposit(decimal amount)
        {
            if (amount <= 0) throw new DomainException("Deposit amount must be greater than zero");
            this.Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
                throw new DomainException("Withdrawal amount must be greater than zero");

            if (amount > this.Balance)
                throw new DomainException("Insufficient funds for this withdrawal");
            
            this.Balance -= amount;
        }
    }
}
