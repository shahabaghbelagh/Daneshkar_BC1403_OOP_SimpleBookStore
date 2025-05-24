using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models
{
    class Category
    {
        public string BookCategory { get; set; }

        public Category(string cat)
        {
            BookCategory = cat;
        }
    }
}
