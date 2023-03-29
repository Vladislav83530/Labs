using System.Xml.Linq;

namespace SubscriptionLibrarySystemXML.Services.Abstract
{
    internal interface IBookService
    {
        IEnumerable<XElement> GetBookByGenre(XDocument doc, string genre);
        XElement GetMostExpensiveBook(XDocument doc);
        Dictionary<string, int> GetGenreCounts(XDocument doc);
        IEnumerable<XElement> GetBooksByIssuedDate(XDocument doc, DateTime startDate);
        IEnumerable<string> GetTop5Expensive(XDocument doc);
    }
}
