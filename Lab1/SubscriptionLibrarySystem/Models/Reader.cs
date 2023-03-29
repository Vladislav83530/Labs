using System.Text;

namespace SubscriptionLibrarySystem.Models
{
    internal class Reader
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
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
