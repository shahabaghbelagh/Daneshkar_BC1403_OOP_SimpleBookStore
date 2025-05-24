using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models
{
    class Book
    {
        public string BookTitle { get; set; }

        public string Author { get; set; }

        public decimal Price { get; set; }

        public Category BookCat{ get; set; }


        public Book(string title, string author, decimal price, Category cat)
        {
            BookTitle = title;

            Author = author;

            Price = price;

            BookCat = cat;
        }

    }
}
