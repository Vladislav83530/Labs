using SubscriptionLibrarySystemXML.Services.Abstract;
using System.Xml.Linq;

namespace SubscriptionLibrarySystemXML.Services
{
    internal class SubscriptionService : ISubscriptionService
    {
        /// <summary>
        /// Get subscription by reader name
        /// </summary>
        /// <param name="doc"></param>
        /// <returns>reader name - list of subscriptions</returns>
        public Dictionary<string, List<XElement>> GetReaderAndSubscriptions(XDocument doc)
        {
            var readerSubscriptions = from reader in doc.Descendants("reader")
                                      join subscription in doc.Descendants("subscription")
                                      on (int)reader.Attribute("id") equals (int)subscription.Attribute("readerid")
                                      group subscription 
                                      by new { 
                                          firstName =  (string)reader.Attribute("firstname"), 
                                          lastName = (string)reader.Attribute("lastname") 
                                      } 
                                      into readerGroup
                                      select new { Name = $"{readerGroup.Key.firstName} {readerGroup.Key.lastName}", Subscriptions = readerGroup };

            return readerSubscriptions.ToDictionary(x => x.Name, x => x.Subscriptions.ToList());
        }

        /// <summary>
        /// Get Subscription by reader Id
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="readerId"></param>
        /// <returns>Subscriptions</returns>
        public IEnumerable<XElement> GetSubscriptionsByReaderId(XDocument doc, int readerId)
        {
            return from subscription in doc.Descendants("subscription")
                                where (int)subscription.Attribute("readerid") == readerId
                                select subscription;
        }

        /// <summary>
        /// Get all active subscription
        /// </summary>
        /// <param name="doc"></param>
        /// <returns>Subscriptions</returns>
        public IEnumerable<XElement> GetActiveSubscriptions(XDocument doc) =>
            doc.Descendants("subscription")
            .Where(x => string.IsNullOrEmpty((string)x.Attribute("returndate")));       
    }
}
