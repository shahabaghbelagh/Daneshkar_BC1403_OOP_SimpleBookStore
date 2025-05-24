using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BookStore.Models;

namespace BookStore.Models
{
    class Order : IDiscount
    {
        public Customer Ourcustomer { get; set; }

        public void AddBook(Book book)
        {
            Ourcustomer.bookroders.Add(book);
        }

        public decimal ApplyDiscount(decimal amount)
        {
            decimal z = amount;
            return z;
        }

        public decimal CalculateTotal()
        {
            decimal x= 10;
            
            return x;
        }

    }
}
