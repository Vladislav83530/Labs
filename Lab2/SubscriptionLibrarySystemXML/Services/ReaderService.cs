using SubscriptionLibrarySystemXML.Services.Abstract;
using System.Xml.Linq;

namespace SubscriptionLibrarySystemXML.Services
{
    internal class ReaderService : IReaderService
    {
        /// <summary>
        /// Get all reader order by title
        /// </summary>
        /// <returns>Readers</returns>
        public IEnumerable<XElement> GetAllReaders(XDocument doc)
        {
            return from reader in doc.Descendants("reader")
                   orderby (string)reader.Attribute("firstname")
                   select reader;    
        }

        /// <summary>
        /// Get adult readers
        /// </summary>
        /// <param name="doc"></param>
        /// <returns>Readers</returns>
        public IEnumerable<XElement> GetAdultReaders(XDocument doc)
        {
            return from reader in doc.Descendants("reader")
                   where reader.Attribute("category").Value == "Adult"
                   select reader;
        }

        /// <summary>
        /// Get reader by Id
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="readerId"></param>
        /// <returns>Reader</returns>
        public XElement GetReaderById(XDocument doc, int readerId)
        {
            return (from reader in doc.Descendants("reader")
                    where (int)reader.Attribute("id") == readerId
                    select reader).SingleOrDefault();
        }

        /// <summary>
        /// Get reader with subscriptions
        /// </summary>
        /// <param name="doc"></param>
        /// <returns>Readers</returns>
        public IEnumerable<XElement> GetReaderWithSubscription(XDocument doc) 
        {
            return from reader in doc.Descendants("reader")
            where doc.Descendants("subscription")
            .Any(sub => (int)sub.Attribute("readerid") == (int)reader.Attribute("id"))
            select reader;       
        }

        /// <summary>
        /// Get unique reader address
        /// </summary>
        /// <param name="doc"></param>
        /// <returns>Addresses</returns>
        public IEnumerable<string> GetUniquieReaderAddress(XDocument doc)
        {
            return doc.Descendants("reader")
            .Select(r => (string)r.Attribute("address"))
            .Distinct();
        }
    }
}
