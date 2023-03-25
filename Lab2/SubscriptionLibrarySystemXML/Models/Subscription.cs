using System.Globalization;
using System.Text;
using System.Xml.Serialization;

namespace SubscriptionLibrarySystemXML.Models
{
    [Serializable]
    public class Subscription
    {
        private Library library;

        public Subscription() { }
        public Subscription(Library library)
        {
            this.library = library;
        }

        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlAttribute("readerid")]
        public int ReaderId { get; set; }

        [XmlAttribute("bookid")]
        public int BookId { get; set; }

        private DateTime issuedDate;

        [XmlIgnore]
        public DateTime IssuedDate
        {
            get { return issuedDate; }
            set
            {
                if (value > DateTime.Now)
                    throw new ArgumentException("Issued date cannot be in the future.");
                issuedDate = value;
            }
        }

        [XmlAttribute("issueddate")]
        public string IssuedDateString
        {
            get { return IssuedDate.ToString("M/d/yyyy h:mm:ss tt"); }
            set { IssuedDate = DateTime.ParseExact(value, "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture); }
        }

        private DateTime expectedReturnDate;
        [XmlIgnore]
        public DateTime ExpectedReturnDate
        {
            get { return expectedReturnDate; }
            set
            {
                if (value < IssuedDate)
                    throw new ArgumentException("Expected return date cannot be before issued date.");
                expectedReturnDate = value;
            }
        }

        [XmlAttribute("expectedreturndate")]
        public string ExpectedReturnDateString
        {
            get { return ExpectedReturnDate.ToString("M/d/yyyy h:mm:ss tt"); }
            set { ExpectedReturnDate = DateTime.ParseExact(value, "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture); }
        }

        private DateTime? returnDate;
        [XmlIgnore]
        public DateTime? ReturnDate
        {
            get { return returnDate; }
            set
            {
                if (value != null && value < IssuedDate)
                    throw new ArgumentException("Return date cannot be before issued date.");
                returnDate = value;
            }
        }

        private decimal rentalFee;
        [XmlAttribute("rentalfee")]
        public decimal RentalFee
        {
            get
            {
                if (library != null)
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
                return rentalFee;
            }
            set { rentalFee = value; }
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
            return output.ToString();
        }
    }
}
