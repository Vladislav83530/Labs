namespace RegisterOrderLib.Models
{
    internal class Order
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public DeliveryType DeliveryType { get; set; }
        public int PostOfficeNumber { get; set; }   
    }
}
