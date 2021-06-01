using System;

namespace Timesheets.Domain.ValueObjects
{
    public sealed class Money: ValueObject
    {
        public decimal Amount { get; }
        
        private Money(){}

        private Money(decimal amount)
        {
            Amount = amount;
        }

        public static Money FromDecimal(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("amount cannot be negative.");
            }
            
            return new Money(amount);
        }
    }
}