using Microsoft.Extensions.DependencyInjection;
using SubscriptionLibrarySystem.Services;
using SubscriptionLibrarySystem.Services.Abstract;

var serviceProvider = new ServiceCollection()
                .AddScoped<ILibraryService, LibraryService>()
                .AddSingleton<IWriteService, WriteService>()
                .BuildServiceProvider();

var libraryService = serviceProvider.GetRequiredService<ILibraryService>();
var writeService = serviceProvider.GetRequiredService<IWriteService>();

while (true)
{
    Console.WriteLine("Make a choice:");
    Console.WriteLine("(1) - All books in library");
    Console.WriteLine("(2) - Get books by genre");
    Console.WriteLine("(3) - Get books by min and max daily rental price");
    Console.WriteLine("(4) - Get most expensive book (collateral price)");
    Console.WriteLine("(5) - Get adult readers and group by name");
    Console.WriteLine("(6) - Get genre count");
    Console.WriteLine("(7) - Get readers with subscriptions");
    Console.WriteLine("(8) - Get total rental revenue");
    Console.WriteLine("(9) - Get average collateral price");
    Console.WriteLine("(10) - Get unique addresses");
    Console.WriteLine("(11) - Get subscriptions by reader Id");
    Console.WriteLine("(12) - Get books after issued date");
    Console.WriteLine("(13) - Group books by author");
    Console.WriteLine("(14) - Get readers without books");
    Console.WriteLine("(15) - Get readers with unreturned books");
    Console.WriteLine("(16) - Get unissued book");
    Console.WriteLine("(17) - Get readers and subscriptions");
    Console.WriteLine("(18) - Get active subscriptions by entered date");
    Console.WriteLine("(19) - Get top 5 expensive");
    Console.WriteLine("(20) - Get books started entered letter");
    Console.WriteLine("Enter 'exit' if you want to end");

    string choose = Console.ReadLine()!;
    Console.Clear();


    switch (choose.ToLower())
    {
        case "1":
            var result1 = libraryService.GetAllBooks();
            var output = writeService.WriteBooks(result1);
            Console.WriteLine(output);
            break;
        case "2":
            Console.Write("Enter genre: ");
            var genre = Console.ReadLine()!;
            var result2 = libraryService.GetBooksByGenre(genre);
            var output2 = writeService.WriteBooks(result2);
            Console.WriteLine(output2);
            break;
        case "3":
            try
            {
                Console.Write("Enter min daily rental price: ");
                var minPrice = decimal.Parse(Console.ReadLine()!);
                Console.Write("Enter max daily rental price: ");
                var maxPrice = decimal.Parse(Console.ReadLine()!);

                var result3 = libraryService.GetBooksByPrice(minPrice, maxPrice);
                var output3 = writeService.WriteBooks(result3);
                Console.WriteLine(output3);
            }
            catch
            {
                Console.WriteLine("Min and max daily rental price must be number. Try again");
            }
            break;
        case "4":
            var result4 = libraryService.GetMostExpensiveBook();
            Console.WriteLine(result4.ToString());
            break;
        case "5":
            var result5 = libraryService.GetAdultReaders();
            var output5 = writeService.WriteGroupingData(result5);
            Console.WriteLine(output5);
            break;
        case "6":
            var result6 = libraryService.GetGenreCounts();
            var output6 = writeService.WriteGroupingData(result6);
            Console.WriteLine(output6);
            break;
        case "7":
            var result7 = libraryService.GetReadersWithSubscriptions();
            var output7 = writeService.WriteReaders(result7);
            Console.WriteLine(output7);
            break;
        case "8":
            var result8 = libraryService.GetTotalRentalRevenue();
            Console.WriteLine(string.Format($"{result8:C}"));
            break;
        case "9":
            var result9 = libraryService.GetAverageCollateralPrice();
            Console.WriteLine(string.Format($"{result9:C}"));
            break;
        case "10":
            var result10 = libraryService.GetUniqueAddresses();
            Console.WriteLine(string.Join(",\n", result10));
            break;
        case "11":
            try
            {
                Console.Write("Enter reader Id: ");
                var readerId = int.Parse(Console.ReadLine()!);
                var result11 = libraryService.GetSubscriptionsByReaderId(readerId);
                var output11 = writeService.WriteSubscriptions(result11);
                Console.WriteLine(output11);
            }
            catch
            {
                Console.WriteLine("Reader Id must be number");
            }
            break;
        case "12":
            try
            {
                Console.WriteLine("Enter issued date: ");
                var issuedDate = DateTime.Parse(Console.ReadLine()!);
                var result12 = libraryService.GetBooksByIssuedDate(issuedDate);
                var output12 = writeService.WriteBooks(result12);
                Console.WriteLine(output12);
            }
            catch
            {
                Console.WriteLine("Wrong date format");
            }
            break;
        case "13":
            var result13 = libraryService.GroupBookByAuthor();
            var output13 = writeService.WriteGroupingData(result13);
            Console.WriteLine(output13);
            break;
        case "14":
            var result14 = libraryService.GetReadersWithoutBook();
            var output14 = writeService.WriteReaders(result14);
            Console.WriteLine(output14);
            break;
        case "15":
            var result15= libraryService.GetReadersWithUnreturnedBooks();
            var output15 = writeService.WriteReaders(result15);
            Console.WriteLine(output15);
            break;
        case "16":
            var result16 = libraryService.GetUnIssuedBook();
            var output16 = writeService.WriteBooks(result16);
            Console.WriteLine(output16);
            break;
        case "17":
            var result17 = libraryService.GetReaderAndSubscriptions();
            var output17 = writeService.WriteReaderAndSubscription(result17);
            Console.WriteLine(output17);
            break;
        case "18":
            try
            {
                Console.WriteLine("Enter date: ");
                var date = DateTime.Parse(Console.ReadLine()!);
                var result18 = libraryService.GetActiveSubscriptions(date);
                var output18 = writeService.WriteResponseDTO(result18);
                Console.WriteLine(output18);
            }
            catch
            {
                Console.WriteLine("Wrong date format");
            }
            break;
        case "19":
            var result19 = libraryService.GetTop5Expensive();
            Console.WriteLine(string.Join(",\n", result19));
            break;
        case "20":
            try
            {
                Console.WriteLine("Enter letter: ");
                var letter = char.Parse(Console.ReadLine()!);
                var result20 = libraryService.GetBookStartedEnteredLetter(letter);
                var output20 = writeService.WriteBooks(result20);
                Console.WriteLine(output20);
            }
            catch
            {
                Console.WriteLine("Invalid data");
            }
            break;
        case "exit":
            Console.Clear();
            Environment.Exit(0);
            break;
        default:
            Console.WriteLine("Invalid choice\n");
            break;
    }
    Console.WriteLine("Press any key to continue");
    Console.ReadKey();
    Console.Clear();
}