using SubscriptionLibrarySystemXML.ConsoleReader.Abstract;
using SubscriptionLibrarySystemXML.Models;

namespace SubscriptionLibrarySystemXML.ConsoleReader
{
    internal class BookDataReader : IConsoleReader 
    {
        /// <summary>
        /// Read book data from console
        /// </summary>
        /// <returns>Book</returns>
        public object ReadData()
        {
            Book book = new();
            Console.WriteLine("Id: ");
            book.Id = int.Parse(Console.ReadLine()!);
            Console.WriteLine("Title: ");
            book.Title = Console.ReadLine()!;
            Console.WriteLine("Author: ");
            book.Author = Console.ReadLine()!;
            Console.WriteLine("Genre: ");
            book.Genre = Console.ReadLine()!;
            Console.WriteLine("Collateral price: ");
            book.CollateralPrice = decimal.Parse(Console.ReadLine()!);
            Console.WriteLine("Daily rental price: ");
            book.DailyRentalPrice = decimal.Parse(Console.ReadLine()!);

            return book;
        }
    }
}