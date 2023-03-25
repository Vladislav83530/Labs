using System.Text;
using System.Xml.Serialization;

namespace SubscriptionLibrarySystemXML.Models
{
    public class Reader
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
        [XmlAttribute("firstname")]
        public string FirstName { get; set; }
        [XmlAttribute("lastname")]
        public string LastName { get; set; }
        [XmlAttribute("address")]
        public string Address { get; set; }
        [XmlAttribute("phone")]
        public string Phone { get; set; }
        [XmlAttribute("category")]
        public Category Category { get; set; }

        public override string ToString()
        {
            StringBuilder output = new();
            output.AppendLine($"{FirstName} {LastName}");
            output.AppendLine($"Address: {Address}");
            output.AppendLine($"Phone: {Phone}");
            output.AppendLine($"Category: {Category.ToString()}");
            return output.ToString();
        }
    }

    public enum Category {
        Child, 
        Adult
    }
}
