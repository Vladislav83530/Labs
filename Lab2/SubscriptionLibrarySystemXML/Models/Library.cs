using System.Text;
using System.Xml.Serialization;

namespace SubscriptionLibrarySystemXML.Models
{
    [XmlRoot("library")]
    public class Library
    {
        [XmlArray("books")]
        [XmlArrayItem("book")]
        public List<Book> Books { get; set; } = new List<Book>();
        [XmlArray("readers")]
        [XmlArrayItem("reader")]
        public List<Reader> Readers { get; set; } = new List<Reader>();
        [XmlArray("subscriptions")]
        [XmlArrayItem("subscription")]
        public List<Subscription> Subscriptions { get; set; } = new List<Subscription>();

        public override string ToString()
        {
            StringBuilder output = new();
            foreach (var reader in Readers)
                output.AppendLine(reader.ToString());

            foreach (var book in Books)
                output.AppendLine(book.ToString());

            foreach (var subscription in Subscriptions)
                output.AppendLine(subscription.ToString());

            return output.ToString();
        }
    }
}
