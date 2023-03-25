using SubscriptionLibrarySystemXML.ConsoleReader.Abstract;
using SubscriptionLibrarySystemXML.Models;

namespace SubscriptionLibrarySystemXML.ConsoleReader
{
    internal class CustomerDataReader : IConsoleReader
    {
        /// <summary>
        /// Read reader data from console
        /// </summary>
        /// <returns>Reader</returns>
        public object ReadData()
        {
            Reader reader = new();
            Console.WriteLine("Id: ");
            reader.Id = int.Parse(Console.ReadLine()!);
            Console.WriteLine("First name: ");
            reader.FirstName = Console.ReadLine()!;
            Console.WriteLine("Last name: ");
            reader.LastName = Console.ReadLine()!;
            Console.WriteLine("Address: ");
            reader.Address = Console.ReadLine()!;
            Console.WriteLine("Phone: ");
            reader.Phone = Console.ReadLine()!;
            while (true)
            {
                Console.WriteLine("Category (1-Child; 2-Adult): ");
                var category = int.Parse(Console.ReadLine()!);
                if (category == 1)
                {
                    reader.Category = Category.Child;
                    break;
                }
                if (category == 2)
                {
                    reader.Category = Category.Adult;
                    break;
                }
                else
                    Console.WriteLine("Wrong number. Try again");     
            }
            return reader;
        }
    }
}
