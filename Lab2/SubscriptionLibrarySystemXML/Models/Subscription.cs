using System.Text;

namespace SubscriptionLibrarySystemXML.Models
{
    internal class Subscription
    {
        private Library library;
        public Subscription(Library library)
        {
            this.library = library;
        }

        public int Id { get; set; }
        public int ReaderId { get; set; }
        public int BookId { get; set; }
        public DateTime IssuedDate { get; set; }
        public DateTime ExpectedReturnDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public decimal RentalFee
        {
            get
            {
                var book = library.Books.FirstOrDefault(b => b.Id == BookId);
                if (ReturnDate == null)
                {
                    var price = book.DailyRentalPrice * (ExpectedReturnDate - IssuedDate).Days - book.CollateralPrice;
                    return price;
                }
                else
                {
                    var price = book.DailyRentalPrice * (ReturnDate - IssuedDate).Value.Days - book.CollateralPrice;
                    return price;
                }
            }
            set { }
        }

        public override string ToString()
        {
            StringBuilder output = new();
            output.AppendLine($"Book: {BookId}");
            output.AppendLine($"Reader: {ReaderId}");
            output.AppendLine($"Issued Date: {IssuedDate}");
            output.AppendLine($"Expected Return Date: {ExpectedReturnDate}");
            output.AppendLine($"Return Date: {ReturnDate}");
            output.AppendLine($"Price: {RentalFee}");
            output.AppendLine(new string('-', 50));
            return output.ToString();
        }
    }
}
