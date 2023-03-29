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
            Console.Write("Id: ");
            book.Id = int.Parse(Console.ReadLine()!);
            Console.Write("Title: ");
            book.Title = Console.ReadLine()!;
            Console.Write("Author: ");
            book.Author = Console.ReadLine()!;
            Console.Write("Genre: ");
            book.Genre = Console.ReadLine()!;
            Console.Write("Collateral price: ");
            book.CollateralPrice = decimal.Parse(Console.ReadLine()!);
            Console.Write("Daily rental price: ");
            book.DailyRentalPrice = decimal.Parse(Console.ReadLine()!);

            return book;
        }
    }
}