using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Models
{
    class FixedAmountDiscount : IDiscount
    {
        public decimal dol { get; set; }

        public FixedAmountDiscount(decimal doll)
        {
            dol = doll;
        }

        public decimal ApplyDiscount(decimal amount)
        {

            decimal finalPrice = amount;
            return finalPrice;
        }
    }
}
