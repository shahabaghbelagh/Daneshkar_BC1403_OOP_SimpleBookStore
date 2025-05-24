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
            //نرخ تخفیف
            int DynamicDiscountCode = 1224;
            int FixedDiscountCode = 2412;

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
            booklist.Add(new Book() { BookTitle = "Little Prince", Author = "Antoine de Saint-Exupery", Price = 10, BookCat = new Category("Short Story") });
            booklist.Add(new Book() { BookTitle = "C# in A Nutshell", Author = "Joseph Albahari", Price = 100, BookCat = new Category("Programming") });
            booklist.Add(new Book() { BookTitle = "C# in A Nutshell", Author = "Joseph Albahari", Price = 100, BookCat= new Category("Programming") });
            booklist.Add(new Book() { BookTitle = "Learn C# in One Day", Author = "Jami Chan", Price = 20, BookCat = new Category("Programming") });
            booklist.Add(new Book() { BookTitle = "Pro ASP.Net Core 6", Author = "Adam Freeman", Price = 100, BookCat = new Category("Programming") });
            booklist.Add(new Book() { BookTitle = "John Bible", Author = "John", Price = 10, BookCat= new Category("Theology") });
            booklist.Add(new Book() { BookTitle = "Quran", Author = "Allah", Price = 1, BookCat = new Category("Theology") });
            booklist.Add(new Book() { BookTitle = "Nahjolbalagheh", Author = "Imam Ali, Seyed Razi", Price = 10, BookCat = new Category("Ethics") });

            Console.Clear();
            Console.ForegroundColor = (ConsoleColor)5;
            Console.WriteLine("*************** Menu ***************");
            Console.ForegroundColor = (ConsoleColor)3;
            Console.WriteLine("1- Order a book");
            Console.WriteLine("2- Search for your desired book");
            Console.WriteLine("3- Exit from the program");
            Console.ForegroundColor = (ConsoleColor)5;
            Console.WriteLine("************************************");
            Console.ForegroundColor = (ConsoleColor)7;
            Inputchoice:  Console.Write("\nPlease enter your choice: ");
            var input = Console.ReadLine();

            if (input != null)
            {
                Console.Clear();

                var selectedMenu = int.Parse(input);

                if(selectedMenu !=1 && selectedMenu != 2 && selectedMenu != 3)
                {
                    Console.ForegroundColor = (ConsoleColor)6;
                    Console.WriteLine("You have entered a wrong input! Please try again.");
                    Console.ForegroundColor = (ConsoleColor)7;
                    goto Inputchoice;
                }
                else
                {
                    switch (selectedMenu)
                    {
                        case 1:
                            {
                                decimal totalPrice;
                                List<Book> bbl = new List<Book>();

                                // ایجاد مشتری
                                Console.Write("\nPlease enter your name: ");
                                var customerName = Console.ReadLine();

                                Console.Write("\nPlease enter your Email address: ");
                                var customerEmail = Console.ReadLine();
                                Customer customer = new Customer(customerName, customerEmail);
                                customers.Add(customer);

                                Console.ForegroundColor = (ConsoleColor)3;
                                Console.WriteLine("You have been successfully added to our customers list.");
                                Console.ForegroundColor = (ConsoleColor)7;

                                bookfind:  Console.Write("\nNow, please enter your the category of your desired book: ");
                                var customerBookCat = Console.ReadLine();

                                Console.Write("\nPlease enter the title of your desired book: ");
                                var customerBookTitle = Console.ReadLine();

                                Console.Write("\nPlease enter the name of the author of the book: ");
                                var customerBookAuthor = Console.ReadLine();

                                Book Foundbook=new Book();

                                foreach (var item in booklist)
                                {
                                   if(item.BookTitle == customerBookTitle || item.Author == customerBookAuthor || item.BookTitle.ToString().ToLower() == customerBookTitle.ToString().ToLower() || item.Author.ToString().ToLower() == customerBookAuthor.ToString().ToLower())
                                    {
                                        Foundbook.BookTitle = item.BookTitle;
                                        Foundbook.Author = item.Author;
                                        Foundbook.Price = item.Price;
                                        Foundbook.BookCat = item.BookCat;
                                    }
                                    
                                }

                                if (Foundbook != null)
                                {
                                    decimal discountRate;

                                    // محاسبه و اعمال تخفیف درصدی
                                    repeatdisc: Console.Write("\nDo you have discount code?(Yes/No): ");
                                    var customerDiscount = Console.ReadLine();

                                    if (customerDiscount == "Yes" || customerDiscount == "YES" || customerDiscount == "yes" || customerDiscount == "Y" || customerDiscount == "y")
                                    {
                                    repeatcode: Console.Write("\nPlease enter the discount code: ");
                                        var customerDiscountCode = int.Parse(Console.ReadLine());

                                        if (customerDiscountCode == DynamicDiscountCode)
                                        {
                                            if (Foundbook.BookCat.BookCategory == "Programming" || Foundbook.BookCat.BookCategory == "Computer and IT" || Foundbook.BookCat.BookCategory == "AI")
                                            {
                                                discountRate = 20;
                                            }
                                            else if (Foundbook.BookCat.BookCategory == "Science" || Foundbook.BookCat.BookCategory == "Math" || Foundbook.BookCat.BookCategory == "Physics" || Foundbook.BookCat.BookCategory == "Chemistry")
                                            {
                                                discountRate = 15;
                                            }
                                            else if (Foundbook.BookCat.BookCategory == "Environment" || Foundbook.BookCat.BookCategory == "Culture" || Foundbook.BookCat.BookCategory == "Art" || Foundbook.BookCat.BookCategory == "Psychology")
                                            {
                                                discountRate = 25;
                                            }
                                            else if (Foundbook.BookCat.BookCategory == "Ethics" || Foundbook.BookCat.BookCategory == "Theology")
                                            {
                                                discountRate = 30;
                                            }
                                            else if (Foundbook.BookCat.BookCategory == "Economy" || Foundbook.BookCat.BookCategory == "Politics")
                                            {
                                                discountRate = 5;
                                            }
                                            else if (Foundbook.BookCat.BookCategory == "Short Story" || Foundbook.BookCat.BookCategory == "Novel")
                                            {
                                                discountRate = 10;
                                            }
                                            else
                                            {
                                                discountRate = 1;
                                            }


                                            // ایجاد سفارش
                                            bbl.Add(Foundbook);
                                            Order order = new Order(customer, discountRate, bbl);

                                            totalPrice = order.ApplyDiscount(Foundbook.Price);
                                        }
                                        else if (customerDiscountCode == FixedDiscountCode)
                                        {
                                            discountRate = 10;

                                            // ایجاد سفارش
                                            bbl.Add(Foundbook);
                                            Order order = new Order(customer, discountRate, bbl);

                                            totalPrice = order.ApplyDiscount(Foundbook.Price);
                                            // محاسبه و اعمال تخفیف به مبلغ ثابت
                                            IDiscount fixedAmountDiscount = new FixedAmountDiscount(15); // 15 دلار تخفیف
                                            totalPrice = fixedAmountDiscount.ApplyDiscount(totalPrice);
                                        }
                                        else
                                        {
                                            Console.ForegroundColor = (ConsoleColor)6;
                                            Console.WriteLine("You have entered a wrong input! Please try again.");
                                            Console.ForegroundColor = (ConsoleColor)7;
                                            goto repeatcode;
                                        }

                                    }

                                    else if (customerDiscount == "No" || customerDiscount == "NO" || customerDiscount == "no" || customerDiscount == "N" || customerDiscount == "n")
                                    {
                                        discountRate = 0;

                                        // ایجاد سفارش
                                        bbl.Add(Foundbook);
                                        Order order = new Order(customer, discountRate, bbl);
                                        
                                        totalPrice = order.ApplyDiscount(Foundbook.Price);
                                    }
                                    else
                                    {
                                        Console.ForegroundColor = (ConsoleColor)6;
                                        Console.WriteLine("You have entered a wrong input! Please try again.");
                                        Console.ForegroundColor = (ConsoleColor)7;
                                        goto repeatdisc;
                                    }


                                    Console.WriteLine($"Total price of the book after percentage discount is: {totalPrice}");
                                    goto Inputchoice;

                                }
                                else
                                {
                                    Console.ForegroundColor = (ConsoleColor)6;
                                    Console.WriteLine("Sorry! There isn't such book in our library.");
                                    Console.ForegroundColor = (ConsoleColor)3;
                                    Console.WriteLine("Please try again.");
                                    Console.ForegroundColor = (ConsoleColor)7;
                                    goto bookfind;
                                }

                            }
                        case 2:
                            {

                                booksearch:  Console.Write("\nPlease enter the title of your desired book: ");
                                var Title = Console.ReadLine();
                                string customerBookTitle = Title.ToString();

                                Console.Write("\nPlease enter the name of the author of the book: ");
                                var bAuthor = Console.ReadLine();
                                string customerBookAuthor = bAuthor.ToString();
                                bool decide = true ;


                                foreach (var it in booklist)
                                {
                                    if (String.Compare(it.BookTitle, customerBookTitle)==0 || String.Compare(it.BookTitle.ToString().ToLower(), customerBookTitle.ToString().ToLower()) == 0 || String.Compare(it.Author, customerBookAuthor) == 0 || String.Compare(it.Author.ToString().ToLower(), customerBookAuthor.ToString().ToLower()) == 0)
                                    {

                                        Book Searchedbook = new Book();
                                        Searchedbook.BookTitle=it.BookTitle;
                                        Searchedbook.Author = it.Author;
                                        Searchedbook.Price = it.Price;
                                        Searchedbook.BookCat=it.BookCat;
                                        
                                        Console.ForegroundColor = (ConsoleColor)3;
                                        Console.WriteLine("Good news! We have this book in our library :)");
                                        Console.ForegroundColor = (ConsoleColor)7;
                                        Console.WriteLine("Book identifications are as follow:");
                                        Console.WriteLine($"Author Name: {Searchedbook.Author}");
                                        Console.WriteLine($"Book Category: {Searchedbook.BookCat.ToString()}");
                                        Console.WriteLine($"Price: {Searchedbook.Price}");

                                        Console.ForegroundColor = (ConsoleColor)3;
                                        Console.Write("\nIf you want to continue with this program, again repeat your choice.");
                                        Console.ForegroundColor = (ConsoleColor)7;
                                        goto Inputchoice;
                                        
                                    }
                                    
                                   
                                }
                                if(decide == false)
                                {
                                    Console.ForegroundColor = (ConsoleColor)6;
                                    Console.WriteLine("Sorry! There isn't such book in our library.");
                                    Console.ForegroundColor = (ConsoleColor)3;
                                    Console.WriteLine("Please try again.");
                                    Console.ForegroundColor = (ConsoleColor)7;
                                    goto booksearch;
                                }

                                break;
                            }
                        case 3:
                            {
                                break;
                            }
                    }
                }

                
            }

            Console.ForegroundColor = (ConsoleColor)6;
            Console.WriteLine("This is the end of the program.");
            Console.ForegroundColor = (ConsoleColor)7;
        }
    }
}
