using SubscriptionLibrarySystemXML.Services.Abstract;
using System.Xml.Linq;

namespace SubscriptionLibrarySystemXML.Services
{
    internal class BookService : IBookService
    {
        /// <summary>
        /// Get book by genre
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="genre"></param>
        /// <returns></returns>
        public IEnumerable<XElement> GetBookByGenre(XDocument doc, string genre) =>
            doc.Descendants("book")
            .Where(x => x.Attribute("genre").Value.ToLower() == genre.ToLower())
            .OrderByDescending(x => x.Attribute("title").Value);

        /// <summary>
        /// Get most expensive book
        /// </summary>
        /// <param name="doc"></param>
        /// <returns>Book</returns>
        public XElement GetMostExpensiveBook(XDocument doc) =>
            doc.Descendants("book")
            .OrderByDescending(x => (decimal)x.Attribute("collateralprice"))
            .First();

        /// <summary>
        /// Get genre count
        /// </summary>
        /// <param name="doc"></param>
        /// <returns>genreName - count</returns>
        public Dictionary<string, int> GetGenreCounts(XDocument doc)
        {
            var genreCounts = doc.Descendants("book")
                .GroupBy(x=>(string)x.Attribute("genre"))
                .Select(g => new { Genre = g.Key, Count = g.Count() });

            return genreCounts.ToDictionary(group => group.Genre, group => group.Count);
        }

        /// <summary>
        /// Get books by issuedDate
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="startDate"></param>
        /// <returns></returns>
        public IEnumerable<XElement> GetBooksByIssuedDate(XDocument doc, DateTime startDate)
        {
            var result = from subscription in doc.Descendants("subscription")
                         join book in doc.Descendants("book") on (int)subscription.Attribute("bookid") equals (int)book.Attribute("id")
                         where (DateTime)subscription.Attribute("issueddate") == startDate
                         select book;

            return result;
        }

        /// <summary>
        /// Get 5 expensive books
        /// </summary>
        /// <param name="doc"></param>
        /// <returns>Books</returns>
        public IEnumerable<string> GetTop5Expensive(XDocument doc) =>
            doc.Descendants("book")
            .OrderByDescending(x => (decimal)x.Attribute("dailyrentalprice"))
            .Take(5)
            .Select(x => (string)x.Attribute("title"));
    }
}
