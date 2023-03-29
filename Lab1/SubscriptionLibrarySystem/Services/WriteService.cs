using SubscriptionLibrarySystem.Models;
using SubscriptionLibrarySystem.Services.Abstract;
using System.Text;

namespace SubscriptionLibrarySystem.Services
{
    internal class WriteService : IWriteService
    {
        public StringBuilder WriteBooks(IEnumerable<Book> books)
        {
            var output = new StringBuilder();
            output.AppendLine("---Selected books---");
            foreach (var book in books)
                output.AppendLine(book.ToString());

            return output;
        }

        public StringBuilder WriteGroupingData(Dictionary<string, int> groupData)
        {
            var output = new StringBuilder();
            output.AppendLine("---Result: ---");
            foreach (var group in groupData)
                output.AppendLine($"{group.Key} - {group.Value}");

            return output;
        }

        public StringBuilder WriteReaders(IEnumerable<Reader> readers)
        {
            var output = new StringBuilder();
            output.AppendLine("---Selected readers---");
            foreach (var reader in readers)
                output.AppendLine(reader.ToString());

            return output;
        }

        public StringBuilder WriteSubscriptions(IEnumerable<Subscription> subscriptions)
        {
            var output = new StringBuilder();
            output.AppendLine("---Selected subscription---");
            foreach (var subscription in subscriptions)
                output.AppendLine(subscription.ToString());

            return output;
        }

        public StringBuilder WriteReaderAndSubscription(Dictionary<string, List<Subscription>> readerAndSubscription)
        {
            var output = new StringBuilder();
            output.AppendLine("---Selected subscription---");
            foreach (var item in readerAndSubscription) { 
                output.AppendLine($"{item.Key.ToString()}");
                foreach(var sub in item.Value)
                output.AppendLine($"{sub.ToString()}");
            }

            return output;
        }

        public StringBuilder WriteResponseDTO(IEnumerable<ResponseDTO> response)
        {
            var output = new StringBuilder();
            output.AppendLine("---Selected active suscriptions---");
            foreach (var item in response)
            {
                output.AppendLine(item.Book.ToString());
                output.AppendLine(item.Reader.ToString());
                output.AppendLine($"Issued date: {item.IssuedDate}");
                output.AppendLine($"Expected return date: {item.ExpectedReturnDate}");
                output.AppendLine(new string('-', 50));
            }

            return output;
        }
    }
}
