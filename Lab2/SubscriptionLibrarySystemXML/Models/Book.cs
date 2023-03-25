using System.Text;
using System.Xml.Serialization;

namespace SubscriptionLibrarySystemXML.Models
{
    public class Book
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
        [XmlAttribute("title")]
        public string Title { get; set; }
        [XmlAttribute("author")]
        public string Author { get; set; }
        [XmlAttribute("genre")]
        public string Genre { get; set; }
        [XmlAttribute("collateralprice")]
        public decimal CollateralPrice { get; set; }
        [XmlAttribute("dailyrentalprice")]
        public decimal DailyRentalPrice { get; set; }

        public override string ToString()
        {
            StringBuilder output = new();
            output.AppendLine($"Title: {Title}");
            output.AppendLine($"Author: {Author}");
            output.AppendLine($"Genre: {Genre}");
            output.AppendLine(String.Format($"Collateral price: {CollateralPrice:C}"));
            output.AppendLine(String.Format($"Daily rental price: {DailyRentalPrice:C}\n"));
            return output.ToString();
        }
    }
}
