using System.Text;

namespace SubscriptionLibrarySystem.Models
{
    internal class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public decimal CollateralPrice { get; set; }
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
