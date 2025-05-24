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

    }
}
