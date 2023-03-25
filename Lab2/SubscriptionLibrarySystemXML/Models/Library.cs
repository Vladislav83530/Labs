namespace SubscriptionLibrarySystemXML.Models
{
    internal class Library
    {
        public List<Book> Books { get; set; } = new List<Book>();
        public List<Reader> Readers { get; set; } = new List<Reader>();
        public List<Subscription> Subscriptions { get; set; } = new List<Subscription>();

        //Set library data
        public Library()
        {
            //Books = new List<Book>() {
            //    new Book { Id = 1, Title = "To Kill a Mockingbird", Author = "Harper Lee", Genre = "Fiction", CollateralPrice = 2.50m, DailyRentalPrice = 0.50m },
            //    new Book { Id = 2, Title = "1984", Author = "George Orwell", Genre = "Science Fiction", CollateralPrice = 3.00m, DailyRentalPrice = 0.75m },
            //    new Book { Id = 3, Title = "Pride and Prejudice", Author = "Jane Austen", Genre = "Romance", CollateralPrice = 2.00m, DailyRentalPrice = 0.50m },
            //    new Book { Id = 4, Title = "The Hobbit", Author = "J.R.R. Tolkien", Genre = "Fantasy", CollateralPrice = 3.50m, DailyRentalPrice = 1.00m },
            //    new Book { Id = 5, Title = "The Catcher in the Rye", Author = "J.D. Salinger", Genre = "Fiction", CollateralPrice = 2.25m, DailyRentalPrice = 0.50m },
            //    new Book { Id = 6, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", Genre = "Fiction", CollateralPrice = 2.75m, DailyRentalPrice = 0.75m },
            //    new Book { Id = 7, Title = "Lord of the Flies", Author = "William Golding", Genre = "Fiction", CollateralPrice = 2.50m, DailyRentalPrice = 0.50m },
            //    new Book { Id = 8, Title = "The Chronicles of Narnia", Author = "C.S. Lewis", Genre = "Fantasy", CollateralPrice = 4.00m, DailyRentalPrice = 1.25m },
            //    new Book { Id = 9, Title = "The Adventures of Huckleberry Finn", Author = "Mark Twain", Genre = "Fiction", CollateralPrice = 2.75m, DailyRentalPrice = 0.50m },
            //    new Book { Id = 10, Title = "The Picture of Dorian Gray", Author = "Oscar Wilde", Genre = "Fiction", CollateralPrice = 3.25m, DailyRentalPrice = 0.75m },
            //    new Book { Id = 11, Title = "The Picture of Dorian Gray", Author = "Oscar Wilde", Genre = "Fiction", CollateralPrice = 3.25m, DailyRentalPrice = 0.75m }
            //};

            //Readers = new List<Reader>() {
            //    new Reader { Id = 1, FirstName = "John", LastName = "Doe", Address = "123 Main St", Phone = "555-1234", Category = Category.Adult },
            //    new Reader { Id = 2, FirstName = "Jane", LastName = "Smith", Address = "456 Oak Ave", Phone = "555-5678", Category = Category.Child },
            //    new Reader { Id = 3, FirstName = "David", LastName = "Brown", Address = "789 Elm St", Phone = "555-9012", Category = Category.Adult },
            //    new Reader { Id = 4, FirstName = "Sarah", LastName = "Lee", Address = "321 Maple Ave", Phone = "555-3456", Category = Category.Child },
            //    new Reader { Id = 5, FirstName = "Michael", LastName = "Johnson", Address = "654 Pine St", Phone = "555-7890", Category = Category.Adult },
            //    new Reader { Id = 6, FirstName = "Emily", LastName = "Davis", Address = "987 Cedar Ave", Phone = "555-2345", Category = Category.Child },
            //    new Reader { Id = 7, FirstName = "William", LastName = "Taylor", Address = "246 Birch St", Phone = "555-6789", Category = Category.Adult },
            //    new Reader { Id = 8, FirstName = "Emma", LastName = "Martin", Address = "135 Elmwood Dr", Phone = "555-0123", Category = Category.Child },
            //    new Reader { Id = 9, FirstName = "Ryan", LastName = "Anderson", Address = "864 Oakwood Rd", Phone = "555-4567", Category = Category.Adult },
            //    new Reader { Id = 10, FirstName = "Olivia", LastName = "Wilson", Address = "975 Pine Ave", Phone = "555-8901", Category = Category.Child }
            //};

            //Subscriptions = new List<Subscription>() {
            //    new Subscription { Id = 1, ReaderId =1, BookId = 1, IssuedDate = new DateTime(2023, 2, 1), ExpectedReturnDate = new DateTime(2023, 2, 15), ReturnDate = new DateTime(2023, 2, 14)},
            //    new Subscription { Id = 2,ReaderId =2, BookId = 2, IssuedDate = new DateTime(2023, 2, 2), ExpectedReturnDate = new DateTime(2023, 2, 16), ReturnDate = new DateTime(2023, 2, 16) },
            //    new Subscription { Id = 3,ReaderId =3, BookId = 3, IssuedDate = new DateTime(2023, 2, 3), ExpectedReturnDate = new DateTime(2023, 2, 17), ReturnDate = new DateTime(2023, 2, 17) },
            //    new Subscription { Id = 4,ReaderId =4, BookId = 4, IssuedDate = new DateTime(2023, 2, 4), ExpectedReturnDate = new DateTime(2023, 2, 18), ReturnDate = new DateTime(2023, 2, 18) },
            //    new Subscription { Id = 5,ReaderId =5, BookId = 5, IssuedDate = new DateTime(2023, 2, 5), ExpectedReturnDate = new DateTime(2023, 2, 19), ReturnDate = new DateTime(2023, 2, 19) },
            //    new Subscription { Id = 6,ReaderId =6, BookId = 6, IssuedDate = new DateTime(2023, 2, 6), ExpectedReturnDate = new DateTime(2023, 2, 20), ReturnDate = new DateTime(2023, 2, 20) },
            //    new Subscription { Id = 7,ReaderId =7, BookId = 7, IssuedDate = new DateTime(2023, 2, 7), ExpectedReturnDate = new DateTime(2023, 2, 21), ReturnDate = null },
            //    new Subscription { Id = 8,ReaderId =8, BookId = 8, IssuedDate = new DateTime(2023, 2, 8), ExpectedReturnDate = new DateTime(2023, 2, 22), ReturnDate = null },
            //    new Subscription { Id = 9,ReaderId =9, BookId = 9, IssuedDate = new DateTime(2023, 2, 9), ExpectedReturnDate = new DateTime(2023, 2, 23), ReturnDate = null },
            //    new Subscription { Id = 10,ReaderId = 10, BookId = 1, IssuedDate = new DateTime(2023, 2, 10), ExpectedReturnDate = new DateTime(2023, 2, 24), ReturnDate = null },
            //    new Subscription { Id = 11,ReaderId = 1, BookId =2, IssuedDate = new DateTime(2023, 2, 12), ExpectedReturnDate = new DateTime(2023, 2, 26), ReturnDate = null},
            //    new Subscription { Id = 13,ReaderId = 1, BookId =3, IssuedDate = new DateTime(2023, 2, 13), ExpectedReturnDate = new DateTime(2023, 2, 27), ReturnDate = null },
            //    new Subscription { Id = 14,ReaderId = 5, BookId =4, IssuedDate = new DateTime(2023, 2, 14), ExpectedReturnDate = new DateTime(2023, 2, 28), ReturnDate = null },
            //    new Subscription { Id = 15,ReaderId = 6, BookId =5, IssuedDate = new DateTime(2023, 2, 15), ExpectedReturnDate = new DateTime(2023, 3, 1), ReturnDate = null },
            //    new Subscription { Id = 16,ReaderId = 8, BookId =6, IssuedDate = new DateTime(2023, 2, 16), ExpectedReturnDate = new DateTime(2023, 3, 2), ReturnDate = null }
            //};
        }
    }
}
