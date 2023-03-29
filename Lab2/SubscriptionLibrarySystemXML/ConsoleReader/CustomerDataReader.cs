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
            Console.Write("Id: ");
            reader.Id = int.Parse(Console.ReadLine()!);
            Console.Write("First name: ");
            reader.FirstName = Console.ReadLine()!;
            Console.Write("Last name: ");
            reader.LastName = Console.ReadLine()!;
            Console.Write("Address: ");
            reader.Address = Console.ReadLine()!;
            Console.Write("Phone: ");
            reader.Phone = Console.ReadLine()!;
            while (true)
            {
                Console.Write("Category (1-Child; 2-Adult): ");
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
