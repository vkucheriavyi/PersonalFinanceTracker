using PersonalFinanceTracker.Constants.Enums;
using PersonalFinanceTracker.Domain.Exceptions;

namespace PersonalFinanceTracker.Domain.Entities
{
    public class Category
    {
        public int Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public TransactionType Type { get; private set; }

        private Category() { }
        public Category(string name, TransactionType type)
        {
            if(string.IsNullOrWhiteSpace(name))
                throw new DomainException("Category name can't be null or whitespace");

            Name = name.Trim();
            Type = type;
        }
    }
}
