using System;
using System.Collections.Generic;


namespace Insight_Book_Store
{
    class Program
    {
        static void Main()
        {
            const double discount = .05;
            double bookPrice, orderPriceExclGST, orderPriceInclGST;
            string bookCategory;

            List<Book> bookList = new List<Book>(6);

            //Add Books to List

            Book book1 = new Book("Unsolved murders", "Emily G.Thompson", "Crime", 10.99);
            book1.AddBookToList(bookList, book1);

            Book book2 = new Book("Alice in Wonderland", "Lewis Carroll", "Fantasy", 5.99);
            book1.AddBookToList(bookList, book2);

            Book book3 = new Book("A Little Love Story", "Roland Merullo", "Romance", 2.40);
            book1.AddBookToList(bookList, book3);

            Book book4 = new Book("Heresy", "S J Parris", "Fantasy", 6.80);
            book1.AddBookToList(bookList, book4);

            Book book5 = new Book("The Neverending Story", "Michael Ende", "Fantasy", 7.99);
            book1.AddBookToList(bookList, book5);

            Book book6 = new Book("Jack the Ripper", "Philip Sugden", "Crime", 16.00);
            book1.AddBookToList(bookList, book6);

            Book book7 = new Book("The Tolkien Years", "Greg Hildebrandt", "Fantasy", 22.90);
            book1.AddBookToList(bookList, book7);

            //Calculate Order Price

            orderPriceExclGST = 0;

            foreach (Book curBook in bookList)
            {
                bookCategory = curBook.genre;
                if (bookCategory == "Crime")
                {
                    bookPrice = curBook.price - (curBook.price * discount);
                }
                else
                {
                    bookPrice = curBook.price;
                }
                orderPriceExclGST = orderPriceExclGST + bookPrice;
            }

            Book emptyBook = new Book();
            orderPriceInclGST = emptyBook.PriceWithGST(orderPriceExclGST);

            var priceExclGST = Math.Round(orderPriceExclGST, 2);
            var priceInclGST = Math.Round(orderPriceInclGST, 2);

            Console.WriteLine("ORDER COST");
            Console.WriteLine("Price (excl GST) " + priceExclGST);
            Console.WriteLine("Price (incl GST) " + priceInclGST);
        }    
    }

    public class Book
    {
        public string title;
        public string author;
        public string genre;
        public double price;

        // Default Constructor
        public Book() {}

        public Book(string bookTitle, string bookAuthor, string bookGenre, double bookPrice) {
           title = bookTitle;
           author = bookAuthor;
           genre = bookGenre;
           price = bookPrice;
        }

        public void AddBookToList(List<Book> books, Book newBook)
        {
            books.Add(newBook);
        }

        public double PriceWithGST(double orderPrice)
        {
            double addGST = orderPrice / 10;
            return orderPrice + addGST;
        }
    }
}
