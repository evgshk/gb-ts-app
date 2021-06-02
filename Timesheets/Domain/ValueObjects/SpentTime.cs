using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheets.Domain.ValueObjects
{
    public class SpentTime: ValueObject
    {
        public int Amount { get; }

        private SpentTime() { }

        private SpentTime(int amount)
        {
            Amount = amount;
        }

        public static SpentTime FromInt(int amount)
        {
            if (amount < 0 || amount > 8)
            {
                throw new ArgumentException("amount should be between 0 and 8.");
            }
            return new SpentTime(amount);
        }
    }
}
