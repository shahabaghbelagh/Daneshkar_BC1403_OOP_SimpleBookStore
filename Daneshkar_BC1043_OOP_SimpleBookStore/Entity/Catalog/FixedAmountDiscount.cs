using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Models
{
    class FixedAmountDiscount : IDiscount
    {
        public decimal discount { get; set; }

        public FixedAmountDiscount(decimal disc)
        {
            discount = disc;
        }

        public decimal ApplyDiscount(decimal amount)
        {

            decimal Fprice = amount - (amount * discount / 100);
            return Fprice;
        }
    }
}
