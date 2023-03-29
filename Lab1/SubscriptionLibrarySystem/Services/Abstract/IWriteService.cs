using SubscriptionLibrarySystem.Models;
using System.Text;

namespace SubscriptionLibrarySystem.Services.Abstract
{
    internal interface IWriteService
    {
        StringBuilder WriteBooks(IEnumerable<Book> books);
        StringBuilder WriteGroupingData(Dictionary<string, int> groupData);
        StringBuilder WriteReaders(IEnumerable<Reader> readers);
        StringBuilder WriteSubscriptions(IEnumerable<Subscription> subscriptions);
        StringBuilder WriteReaderAndSubscription(Dictionary<string, List<Subscription>> readerAndSubscription);
        StringBuilder WriteResponseDTO(IEnumerable<ResponseDTO> response);
    }
}
