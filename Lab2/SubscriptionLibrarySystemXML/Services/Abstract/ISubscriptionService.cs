using System.Xml.Linq;

namespace SubscriptionLibrarySystemXML.Services.Abstract
{
    internal interface ISubscriptionService
    {
        Dictionary<string, List<XElement>> GetReaderAndSubscriptions(XDocument doc);
        IEnumerable<XElement> GetSubscriptionsByReaderId(XDocument doc, int readerId);
        IEnumerable<XElement> GetActiveSubscriptions(XDocument doc);
    }
}
