using SubscriptionLibrarySystemXML.ConsoleReader.Abstract;
using SubscriptionLibrarySystemXML.Models;

namespace SubscriptionLibrarySystemXML.ConsoleReader
{
    internal class SubscriptionDataReader : IConsoleReader
    {
        private readonly Library library;
        public SubscriptionDataReader(Library library)
        {
           this.library = library;
        }

        /// <summary>
        /// Read subscription data from console
        /// </summary>
        /// <returns></returns>
        public object ReadData()
        {
            Subscription subscription = new(library);
            Console.WriteLine("Id: ");
            subscription.Id = int.Parse(Console.ReadLine()!);
            while (true)
            {
                Console.WriteLine("Reader Id: ");
                var value = Console.ReadLine()!;
                if (value.ToLower() == "exit")
                    goto exit;
                else
                {
                    var readerId = int.Parse(value);
                    if (library.Readers.Where(x => x.Id == readerId).FirstOrDefault() != null)
                    {
                        subscription.ReaderId = readerId;
                        break;
                    }
                    else
                        Console.WriteLine($"Reader with {readerId} not found. Try again\nIf you want to come back enter 'exit'");
                }
            }
            while (true)
            {
                Console.WriteLine("Book Id: ");
                var value = Console.ReadLine()!;
                if (value.ToLower() == "exit")
                    goto exit;
                else
                {
                    var bookId = int.Parse(value);
                    if (library.Books.Where(x => x.Id == bookId).FirstOrDefault() != null)
                    {
                        subscription.BookId = bookId;
                        break;
                    }
                    else
                        Console.WriteLine($"Book with {bookId} not found. Try again\nIf you want to come back enter 'exit'");
                }
            }
            Console.WriteLine("Issued date: ");
            subscription.IssuedDate = DateTime.Parse(Console.ReadLine()!);
            Console.WriteLine("Expected return date: ");
            subscription.ExpectedReturnDate = DateTime.Parse(Console.ReadLine()!);
            Console.WriteLine("Return date: ");
            var inputReturnDate = Console.ReadLine();
            subscription.ReturnDate = string.IsNullOrEmpty(inputReturnDate) ? null : DateTime.Parse(inputReturnDate);
            if (subscription != null)
                return subscription;

            exit:
                return null; 
        }     
    }
}
