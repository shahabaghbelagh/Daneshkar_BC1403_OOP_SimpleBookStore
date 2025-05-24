using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Models
{
    interface IDiscount
    {
        decimal ApplyDiscount(decimal amount);
    }
}
