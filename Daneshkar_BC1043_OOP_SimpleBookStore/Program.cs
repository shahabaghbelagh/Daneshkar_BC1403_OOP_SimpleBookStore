using System;

namespace BookStore
{
    class Program
    {
        static void Main(string[] args)
        {
            // ایجاد مشتری
            Customer customer = new Customer("Alice", "alice@example.com");
            Console.WriteLine(customer);

            //ایجاد دسته بندی
            Category Category1 = new Category("Programming");
            Category Category2 = new Category("AI");

            // ایجاد کتاب‌ها
            Book book1 = new Book("C# Programming", "John Doe", 29.99m,Category1);
            Book book2 = new Book("Learning ASP.NET", "Jane Smith", 39.99m,Category2);
            Console.WriteLine(book1);
            Console.WriteLine(book2);

            // ایجاد سفارش
            Order order = new Order();
            order.AddBook(book1);
            order.AddBook(book2);
            Console.WriteLine(order);

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
    }
}
