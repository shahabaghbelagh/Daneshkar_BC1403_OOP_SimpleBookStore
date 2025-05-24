using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using BookStore.Models;

namespace BookStore
{
    class Program
    { 
        static void Main(string[] args)
        {
            List<Book> booklist = new List<Book>();
            List<Category> category = new List<Category>();
            List<Customer> customers = new List<Customer>();
            List<Order> orders = new List<Order>();

            //ایجاد دسته بندی
            category.Add(new Category("Short Story"));
            category.Add(new Category("Novel"));
            category.Add(new Category("Art"));
            category.Add(new Category("Science"));
            category.Add(new Category("History"));
            category.Add(new Category("Engineering"));
            category.Add(new Category("Politics"));
            category.Add(new Category("Economy"));
            category.Add(new Category("Psychology"));
            category.Add(new Category("Ethics"));
            category.Add(new Category("Theology"));
            category.Add(new Category("Programming"));
            category.Add(new Category("Computer and IT"));
            category.Add(new Category("AI"));
            category.Add(new Category("Math"));
            category.Add(new Category("Physics"));
            category.Add(new Category("Chemistry"));
            category.Add(new Category("Biology"));
            category.Add(new Category("Medicine"));
            category.Add(new Category("Health"));
            category.Add(new Category("Environment"));
            category.Add(new Category("Culture"));
            category.Add(new Category("Foreign Language"));

            // ایجاد کتابها
            booklist.Add(new Book("Antoine de Saint-Exupery", "Little Prince", 10, new Category("Short Story")));
            booklist.Add(new Book("Joseph Albahari", "C# in A Nutshell", 100, new Category("Programming")));
            booklist.Add(new Book("Jami Chan", "Learn C# in One Day", 20, new Category("Programming")));
            booklist.Add(new Book("Adam Freeman", "Pro ASP.Net Core 6", 100, new Category("Programming")));
            booklist.Add(new Book("John", "John Bible", 10, new Category("Theology")));
            booklist.Add(new Book("Allah", "Quran", 1, new Category("Theology")));
            booklist.Add(new Book("Imam Ali, Seyed Razi", "Nahjolbalagheh", 10, new Category("Ethics")));

            Console.Clear();
            Console.ForegroundColor = (ConsoleColor)5;
            Console.WriteLine("*************** Menu ***************");
            Console.ForegroundColor = (ConsoleColor)3;
            Console.WriteLine("1- Main Program By Masoud");
            Console.WriteLine("2-Find your book");
            Console.ForegroundColor = (ConsoleColor)5;
            Console.WriteLine("************************************");
            Console.ForegroundColor = (ConsoleColor)7;
            Console.Write("\nPlease enter your choice: ");
            var input = Console.ReadLine();

            if (input != null)
            {
                Console.Clear();

                var selectedMenu = int.Parse(input);

                switch (selectedMenu)
                {
                    case 1:
                        {
                            // ایجاد مشتری
                            Console.Write("\nPlease enter your name: ");
                            var customerName = Console.ReadLine();

                            Console.Write("\nPlease enter your Email address: ");
                            var customerEmail = Console.ReadLine();
                            Customer customer = new Customer(customerName, customerEmail);
                            customers.Add(customer);

                            Console.WriteLine("You have been successfully added to our customers list.");

                            Console.Write("\nNow, please enter your the category of your desired book: ");
                            var customerBookCat = Console.ReadLine();

                            Console.Write("\nPlease enter the title of your desired book: ");
                            var customerBookTitle = Console.ReadLine();

                            Console.Write("\nPlease enter the name of the author of the book: ");
                            var customerBookAuthor = Console.ReadLine();

                            Book Foundbook = booklist.Find(t => t.BookTitle == customerBookTitle || t.Author == customerBookAuthor);

                            if (Foundbook != null)
                            {

                                // ایجاد سفارش
                                Order order = new Order();
                                order.Ourcustomer = customer;
                                order.AddBook(Foundbook);

                                //order.AddBook(book1);
                                //order.AddBook(book2);
                                //Console.WriteLine(order);


                                // محاسبه و اعمال تخفیف درصدی
                                IDiscount percentageDiscount = new PercentageDiscount(10); // 10% تخفیف
                                decimal total = order.CalculateTotal();
                                decimal discountedTotalPercentage = percentageDiscount.ApplyDiscount(total);
                                Console.WriteLine($"Total after percentage discount: ${discountedTotalPercentage}");

                                // محاسبه و اعمال تخفیف به مبلغ ثابت
                                IDiscount fixedAmountDiscount = new FixedAmountDiscount(15); // 15 دلار تخفیف
                                decimal discountedTotalFixedAmount = fixedAmountDiscount.ApplyDiscount(total);
                                Console.WriteLine($"Total after fixed amount discount: ${discountedTotalFixedAmount}");
              


                            }
                            else
                            {
                                Console.WriteLine("Sorry! There isn't such book in our library.");
                            }

                            break;

                        }
                    case 2:
                        {
                            
                            //string BookTitle = "aaa";
                            
                            //SearchBook searchbook = new SearchBook();
                            //searchbook.Search(BookTitle);

                            break;
                        }
                }
            }
            Console.WriteLine("Nothing");
            Console.WriteLine("Nothing2");
        }
    }
}
