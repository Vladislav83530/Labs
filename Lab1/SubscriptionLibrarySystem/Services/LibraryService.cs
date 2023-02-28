using SubscriptionLibrarySystem.Models;
using SubscriptionLibrarySystem.Services.Abstract;

namespace SubscriptionLibrarySystem.Services
{
    internal class LibraryService : ILibraryService
    {
        private readonly Library _library;

        public LibraryService()
        {
            _library = new Library();
        }

        /// <summary>
        /// Get all books order by title
        /// </summary>
        /// <returns>Books</returns>
        public IEnumerable<Book> GetAllBooks() =>
            _library.Books.OrderBy(x => x.Title);

        /// <summary>
        /// Get books by genre
        /// </summary>
        /// <param name="genre">e.g. fiction</param>
        /// <returns>Books</returns>
        public IEnumerable<Book> GetBooksByGenre(string genre) => 
            _library.Books.Where(x => x.Genre.ToLower() == genre.ToLower());

        /// <summary>
        /// Get books by min daily rental price and max daily rental price
        /// </summary>
        /// <param name="minPrice"></param>
        /// <param name="maxPrice"></param>
        /// <returns>Books</returns>
        public IEnumerable<Book> GetBooksByPrice(decimal minPrice, decimal maxPrice) =>
            _library.Books.Where(x => x.DailyRentalPrice >= minPrice && x.DailyRentalPrice <= maxPrice);

        /// <summary>
        /// Get most expensive book (collateral price)
        /// </summary>
        /// <returns>Book</returns>
        public Book GetMostExpensiveBook() =>
            _library.Books.OrderByDescending(book => book.CollateralPrice).First();

        /// <summary>
        /// Get genre counts
        /// </summary>
        /// <returns>Genre</returns>
        public Dictionary<string, int> GetGenreCounts()
        {
            var genreCounts = _library.Books.GroupBy(b => b.Genre)
                       .Select(g => new { Genre = g.Key, Count = g.Count() });

            return genreCounts.ToDictionary(group => group.Genre, group => group.Count);
        }

        /// <summary>
        /// Get adult readers and group by name
        /// </summary>
        /// <returns>Readers</returns>
        public Dictionary<string, int> GetAdultReaders()
        {
            var groupingReaders = from reader in _library.Readers
                                  where reader.Category == Category.Adult
                                  group reader by reader.FirstName into readerGroup
                                  select new
                                  {
                                      Name = readerGroup.Key,
                                      Count = readerGroup.Count()
                                  };

            return groupingReaders.ToDictionary(group => group.Name, group => group.Count);
        }

        /// <summary>
        /// Get readers with subscriptions
        /// </summary>
        /// <returns>Readers</returns>
        public IEnumerable<Reader> GetReadersWithSubscriptions()
        {
            var readersWithSubscriptions = from r in _library.Readers
                                           where _library.Subscriptions.Any(s => s.ReaderId == r.Id)
                                           select r;

            return readersWithSubscriptions;
        }

        /// <summary>
        /// Get total rental revenue
        /// </summary>
        /// <returns>sum price</returns>
        public decimal GetTotalRentalRevenue() =>
            _library.Subscriptions.Sum(b => b.RentalFee);

        /// <summary>
        /// Get average collateral price
        /// </summary>
        /// <returns>average price</returns>
        public decimal GetAverageCollateralPrice() =>
            _library.Books.Average(b => b.CollateralPrice);

        /// <summary>
        /// Get Unique Addresses
        /// </summary>
        /// <returns>list of adresses</returns>
        public IEnumerable<string> GetUniqueAddresses() =>
            _library.Readers.Select(reader => reader.Address).Distinct();

        /// <summary>
        /// Get subscriptions by reader id
        /// </summary>
        /// <param name="readerId"></param>
        /// <returns>readers subscriptions</returns>
        public IEnumerable<Subscription> GetSubscriptionsByReaderId(int readerId)
        {
            var subscriptions = from subscription in _library.Subscriptions
                                where subscription.ReaderId == readerId
                                select subscription;
            return subscriptions;
        }

        /// <summary>
        /// Get books by Issued date
        /// </summary>
        /// <param name="startDate"></param>
        /// <returns></returns>
        public IEnumerable<Book> GetBooksByIssuedDate(DateTime startDate)
        {
            var result = from subscription in _library.Subscriptions
                         join book in _library.Books on subscription.BookId equals book.Id
                         where subscription.IssuedDate > startDate
                         select book;

            return result;
        }

        /// <summary>
        /// Group book by author
        /// </summary>
        /// <returns>grouping books by author</returns>
        public Dictionary<string, int> GroupBookByAuthor()
        {
            var booksByAuthor = _library.Books.GroupBy(book => book.Author).Select(group => new { Author = group.Key, Count = group.Count() });

            return booksByAuthor.ToDictionary(group => group.Author, group => group.Count);
        }

        /// <summary>
        /// Get readers without book
        /// </summary>
        /// <returns>Readers</returns>
        public IEnumerable<Reader> GetReadersWithoutBook()
        {
            var readersWithNoBooks = from reader in _library.Readers
                                     where !(from subscription in _library.Subscriptions
                                             where subscription.ReaderId == reader.Id && subscription.ReturnDate == null
                                             select subscription)
                                            .Any()
                                     select reader;
            return readersWithNoBooks;
        }

        /// <summary>
        /// Get Readers With Unreturned Books
        /// </summary>
        /// <returns>Readers</returns>
        public IEnumerable<Reader> GetReadersWithUnreturnedBooks()
        {
            var readersWithUnreturnedBooks = from reader in _library.Readers
                                             where (from subscription in _library.Subscriptions
                                                    where subscription.ReaderId == reader.Id && subscription.ReturnDate == null
                                                    select subscription)
                                                   .Any()
                                             select reader;
            return readersWithUnreturnedBooks;
        }

        /// <summary>
        /// Get Unissued books
        /// </summary>
        /// <returns>Books</returns>
        public IEnumerable<Book> GetUnIssuedBook() =>
            _library.Books.Where(book => !_library.Subscriptions.Any(subscription => subscription.BookId == book.Id));

        /// <summary>
        /// Get Reader And Subscriptions
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, List<Subscription>> GetReaderAndSubscriptions()
        {
            var readerSubscriptions = from reader in _library.Readers
                                      join subscription in _library.Subscriptions
                                      on reader.Id equals subscription.ReaderId
                                      group subscription by new { reader.FirstName, reader.LastName } into readerGroup
                                      select new { Name = $"{readerGroup.Key.FirstName} {readerGroup.Key.LastName}", Subscriptions = readerGroup };

            return readerSubscriptions.ToDictionary(x => x.Name, x => x.Subscriptions.ToList());
        }


        /// <summary>
        /// Get active subscriptions
        /// </summary>
        /// <param name="currentDate"></param>
        /// <returns>subscriptions</returns>
        public IEnumerable<ResponseDTO> GetActiveSubscriptions(DateTime currentDate)
        {
            var activeSubscriptions = _library.Subscriptions
                .Where(sub => sub.IssuedDate <= currentDate && (!sub.ReturnDate.HasValue || sub.ReturnDate > currentDate))
                .Select(sub => new ResponseDTO
                {
                     Reader = _library.Readers.FirstOrDefault(r => r.Id == sub.ReaderId),
                     Book = _library.Books.FirstOrDefault(b => b.Id == sub.BookId),
                     IssuedDate = sub.IssuedDate,
                     ExpectedReturnDate = sub.ExpectedReturnDate
                });

            return activeSubscriptions;
        }

        /// <summary>
        /// Get top 5 expensive
        /// </summary>
        /// <returns>Books</returns>
        public IEnumerable<string> GetTop5Expensive() =>
            _library.Books.OrderByDescending(x=>x.DailyRentalPrice).Take(5).Select(x=>x.Title);
        
        /// <summary>
        /// Get books started entered letter
        /// </summary>
        /// <param name="letter"></param>
        /// <returns></returns>
        public IEnumerable<Book> GetBookStartedEnteredLetter(char letter)
        {
            var books = from book in _library.Books
                        where book.Title.StartsWith(letter.ToString(), StringComparison.OrdinalIgnoreCase)
                        select book;

            return books;
        }
    }
}
