using System.Xml.Linq;

namespace SubscriptionLibrarySystemXML.Services.Abstract
{
    internal interface IReaderService
    {
        IEnumerable<XElement> GetAllReaders(XDocument doc);
        IEnumerable<XElement> GetAdultReaders(XDocument doc);
        XElement GetReaderById(XDocument doc, int readerId);
        IEnumerable<XElement> GetReaderWithSubscription(XDocument doc);
        IEnumerable<string> GetUniquieReaderAddress(XDocument doc);
    }
}
