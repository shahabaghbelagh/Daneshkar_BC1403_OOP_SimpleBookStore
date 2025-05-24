using System;
using System.Collections.Generic;
using System.Text;
using BookStore.Models;

namespace BookStore.Models
{
    static class SearchBook
    {
        public static List<Book> booklists { get; set; }

        public static void Search(string title)
        {
             
            if (booklists.Exists(t=>t.BookTitle == title))
            {
                Console.WriteLine("We have this book.");
            }
            else
            {
                Console.WriteLine("We don't have this book!");

            }
        }
    }
}
