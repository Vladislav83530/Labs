namespace SubscriptionLibrarySystem.Models
{
    internal class ResponseDTO
    {
        public Reader Reader {get; set;}
        public Book Book { get; set; } 
        public DateTime IssuedDate { get; set; }
        public DateTime ExpectedReturnDate { get; set; }
    }
}