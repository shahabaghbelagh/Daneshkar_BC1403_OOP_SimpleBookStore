using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore
{
    public class PercentageDiscount : IDiscount
    {
        private decimal _percentage;

        public PercentageDiscount(decimal percentage)
        {
            _percentage = percentage;
        }

        public decimal ApplyDiscount(decimal total)
        {
            return total - (total * _percentage / 100);
        }
    }


    public class FixedAmountDiscount : IDiscount
    {
        private decimal _fixedAmount;

        public FixedAmountDiscount(decimal fixedAmount)
        {
            _fixedAmount = fixedAmount;
        }

        public decimal ApplyDiscount(decimal total)
        {
            // اطمینان از اینکه تخفیف بیشتر از مجموع کل نباشد
            return total - Math.Min(_fixedAmount, total);
        }
    }
}
