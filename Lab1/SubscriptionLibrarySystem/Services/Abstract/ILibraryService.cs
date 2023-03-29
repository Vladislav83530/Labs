using SubscriptionLibrarySystem.Models;

namespace SubscriptionLibrarySystem.Services.Abstract
{
    internal interface ILibraryService
    {
        IEnumerable<Book> GetAllBooks();
        IEnumerable<Book> GetBooksByGenre(string genre);
        IEnumerable<Book> GetBooksByPrice(decimal minPrice, decimal maxPrice);
        Book GetMostExpensiveBook();
        Dictionary<string, int> GetGenreCounts();
        Dictionary<string, int> GetAdultReaders();
        IEnumerable<Reader> GetReadersWithSubscriptions();
        decimal GetTotalRentalRevenue();
        decimal GetAverageCollateralPrice();
        IEnumerable<string> GetUniqueAddresses();
        IEnumerable<Subscription> GetSubscriptionsByReaderId(int readerId);
        IEnumerable<Book> GetBooksByIssuedDate(DateTime startDate);
        Dictionary<string, int> GroupBookByAuthor();
        IEnumerable<Reader> GetReadersWithUnreturnedBooks();
        IEnumerable<Reader> GetReadersWithoutBook();
        IEnumerable<Book> GetUnIssuedBook();
        Dictionary<string, List<Subscription>> GetReaderAndSubscriptions();
        IEnumerable<ResponseDTO> GetActiveSubscriptions(DateTime currentDate);
        IEnumerable<string> GetTop5Expensive();
        IEnumerable<Book> GetBookStartedEnteredLetter(char letter);
    }
}
