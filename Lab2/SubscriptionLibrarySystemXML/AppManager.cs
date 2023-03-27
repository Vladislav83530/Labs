using SubscriptionLibrarySystemXML.ConsoleReader;
using SubscriptionLibrarySystemXML.ConsoleReader.Abstract;
using SubscriptionLibrarySystemXML.FileProcessor.Abstract;
using SubscriptionLibrarySystemXML.Models;
using SubscriptionLibrarySystemXML.Services.Abstract;
using SubscriptionLibrarySystemXML.XMLParser.Abstract;
using System.Xml.Linq;

namespace SubscriptionLibrarySystemXML
{
    internal class AppManager
    {
        private IConsoleReader _consoleReader;
        private readonly IFileProcessor fileProcessor;
        private readonly IReaderService readerService;
        private readonly IBookService bookService;
        private readonly ISubscriptionService subscriptionService;
        private readonly IStatisticService statisticService;
        private readonly IXmlParser xmlParser;


        public AppManager(
            IFileProcessor fileProcessor,
            IXmlParser xmlParser,
            IReaderService readerService,
            IBookService bookService,
            ISubscriptionService subscriptionService,
            IStatisticService statisticService)
        {
            this.fileProcessor = fileProcessor;
            this.readerService = readerService;
            this.xmlParser = xmlParser;
            this.bookService = bookService;
            this.subscriptionService = subscriptionService;
            this.statisticService = statisticService;
        }
        public void Main()
        {
            while (true)
            {
                Console.WriteLine("Make a choice:");
                Console.WriteLine("(1) - Write entity to XML used Console");
                Console.WriteLine("(2) - Upload XML file used XMLDocument");
                Console.WriteLine("(3) - Upload XML file user XMLSerializer");
                Console.WriteLine("(4) - Manipulation with data");
                Console.WriteLine("Enter 'exit' if you want to end");

                string choose = Console.ReadLine()!;
                Console.Clear();

                switch (choose.ToLower())
                {
                    case "1":
                        SaveData();
                        break;
                    case "2":
                        Console.Write("Enter file name: ");
                        string fileName = Console.ReadLine();
                        if (File.Exists(fileName))
                        {
                            var library = fileProcessor.ReadFile(fileName);
                            Console.WriteLine(library.ToString());
                        }
                        else
                            Console.WriteLine("File is not exists");
                        break;
                    case "3":
                        Console.Write("Enter file name: ");
                        string fileName_ = Console.ReadLine();
                        if (File.Exists(fileName_))
                        {
                            try
                            {
                                var library_ = fileProcessor.DeserializeFile(fileName_);
                                Console.WriteLine(library_.ToString());
                            }
                            catch
                            {
                                Console.WriteLine("Wrong file. PLease, try again");
                            }
                        }
                        else
                            Console.WriteLine("File is not exists");
                        break;
                    case "4":
                        Console.Write("Enter file name: ");
                        fileName = Console.ReadLine();
                        if (File.Exists(fileName))
                        {
                            DataManipulation(fileName);
                        }
                        else
                            Console.WriteLine("File is not exists");
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
        }

        private void SaveData()
        {
            Library library = new Library();
            bool isNotSave = true;
            while (isNotSave)
            {
                Console.WriteLine("Make a choice:");
                Console.WriteLine("(1) - Add reader");
                Console.WriteLine("(2) - Add book");
                Console.WriteLine("(3) - Add subscription");
                Console.WriteLine("Enter 'save' if you enter all value");

                string choice = Console.ReadLine()!;
                Console.Clear();

                switch (choice.ToLower())
                {
                    case "1":
                        _consoleReader = new CustomerDataReader();
                        try
                        {
                            library.Readers.Add(_consoleReader.ReadData() as Reader);
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Wrong format. Try again");
                            goto case "1";
                        }
                        break;
                    case "2":
                        _consoleReader = new BookDataReader();
                        try
                        {
                            library.Books.Add(_consoleReader.ReadData() as Book);
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Wrong format. Try again");
                            goto case "2";
                        }
                        break;
                    case "3":
                        _consoleReader = new SubscriptionDataReader(library);
                        try
                        {
                            var subscription = _consoleReader.ReadData() as Subscription;

                            if (subscription == null)
                                break;

                            library.Subscriptions.Add(subscription);
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Wrong format. Try again");
                            goto case "3";
                        }
                        break;
                    case "save":
                        while (true)
                        {
                            Console.WriteLine("Enter file name");
                            var fileName = Console.ReadLine()!;

                            if (string.IsNullOrEmpty(fileName) || File.Exists(fileName))
                                Console.WriteLine("File name can not be empty or file with this name is exists. Try again");
                            else
                            {
                                fileProcessor.WriteFile(fileName, library);
                                break;
                            }
                        }
                        Console.Clear();
                        isNotSave = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice\n");
                        break;
                }
            }
        }
        private void DataManipulation(string fileName)
        {
            XDocument doc = XDocument.Load(fileName);
            bool isNotExit = true;
            while (isNotExit)
            {
                Console.WriteLine("Press any key to continue");
                Console.ReadLine();
                Console.Clear();

                Console.WriteLine("Make a choice:");
                Console.WriteLine("(1) - Get all readers order by first name");
                Console.WriteLine("(2) - Get all adult readers");
                Console.WriteLine("(3) - Get reader by Id");
                Console.WriteLine("(4) - Get books by genre order by title descending");
                Console.WriteLine("(5) - Get most expensive book");
                Console.WriteLine("(6) - Get genre count");
                Console.WriteLine("(7) - Get reader with subscriptions"); 
                Console.WriteLine("(8) - Get reader unique addresses");
                Console.WriteLine("(9) - Get books by issued date");
                Console.WriteLine("(10) - Get readers and subscriptions"); 
                Console.WriteLine("(11) - Get subscriptions by reader id");
                Console.WriteLine("(12) - Get all active subscriptions");
                Console.WriteLine("(13) - Get 5 most expensive book title");
                Console.WriteLine("(14) - Get total total rental revenue");
                Console.WriteLine("(15) - Get average collateral price");
                Console.WriteLine("(16) - Get average daily rental price");
                Console.WriteLine("Enter 'exi reader unique addressest' if you want to end working with data");

                string choice = Console.ReadLine()!;
                Console.Clear();

                switch (choice.ToLower())
                {
                    case "1":
                        var readers = readerService.GetAllReaders(doc);
                        foreach (var reader in readers)
                            Console.WriteLine(xmlParser.ParseFromXML<Reader>(reader));
                        break;
                    case "2":
                        readers = readerService.GetAdultReaders(doc);
                        foreach (var reader in readers)
                            Console.WriteLine(xmlParser.ParseFromXML<Reader>(reader));
                        break;
                    case "3":
                        while (true)
                        {
                            try
                            {
                                Console.Write("Enter Id: ");
                                var id = int.Parse(Console.ReadLine());
                                var reader_ = readerService.GetReaderById(doc, id);
                                Console.WriteLine(xmlParser.ParseFromXML<Reader>(reader_));
                                break;
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Wrong id format. Must be number. Try again");
                            }
                        }
                        break;
                    case "4":
                        Console.Write("Enter genre: ");
                        var genre = Console.ReadLine();
                        var books = bookService.GetBookByGenre(doc, genre);
                        foreach (var book in books)
                            Console.WriteLine(xmlParser.ParseFromXML<Book>(book));
                        break;
                    case "5":
                        var book_ = bookService.GetMostExpensiveBook(doc);
                        Console.WriteLine(xmlParser.ParseFromXML<Book>(book_));
                        break;
                    case "6":
                        var genreCounts = bookService.GetGenreCounts(doc);
                        foreach (var group in genreCounts)
                            Console.WriteLine($"{group.Key} - {group.Value}");
                        break;
                    case "7":
                        readers = readerService.GetReaderWithSubscription(doc);
                        foreach (var reader in readers)
                            Console.WriteLine(xmlParser.ParseFromXML<Reader>(reader));
                        break;
                    case "8":
                        var addresses = readerService.GetUniquieReaderAddress(doc);
                        foreach (var address in addresses)
                            Console.WriteLine(address);
                        break;
                    case "9":
                        while (true)
                        {
                            try
                            {
                                Console.Write("Enter issued date: ");
                                var issueDate = DateTime.Parse(Console.ReadLine());
                                books = bookService.GetBooksByIssuedDate(doc, issueDate);
                                foreach(var book in books)
                                    Console.WriteLine(xmlParser.ParseFromXML<Book>(book));
                                break;
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Wrong id format. Try again");
                            }
                        }
                        break;
                    case "10":
                        var result = subscriptionService.GetReaderAndSubscriptions(doc);
                        foreach (var group in result)
                        {
                            Console.WriteLine($"{group.Key}");
                            foreach(var sub in group.Value)
                                Console.WriteLine(xmlParser.ParseFromXML<Subscription>(sub));
                        }
                        break;
                    case "11":
                        while (true)
                        {
                            try
                            {
                                Console.Write("Enter reader Id: ");
                                var readerid = int.Parse(Console.ReadLine());
                                var subscriptions = subscriptionService.GetSubscriptionsByReaderId(doc, readerid);
                                foreach(var sub in subscriptions)
                                    Console.WriteLine(xmlParser.ParseFromXML<Subscription>(sub));
                                break;
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Wrong id format. Must be number. Try again");
                            }
                        }
                        break;
                    case "12":
                        var subscriptions_ = subscriptionService.GetActiveSubscriptions(doc);
                        foreach (var sub in subscriptions_)
                            Console.WriteLine(xmlParser.ParseFromXML<Subscription>(sub));
                        break;
                    case "13":
                        var bookTitles = bookService.GetTop5Expensive(doc);
                        foreach (var title in bookTitles)
                            Console.WriteLine(title);
                        break;
                    case "14":
                        var priceResult = statisticService.GetTotalRentalRevenue(doc);
                        Console.WriteLine(priceResult);
                        break;
                    case "15":
                        priceResult = statisticService.GetAverageCollateralPrice(doc);
                        Console.WriteLine(priceResult);
                        break;
                    case "16":
                        priceResult = statisticService.GetAverageDailyRentalPrice(doc);
                        Console.WriteLine(priceResult);
                        break;
                    case "exit":
                        isNotExit = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice\n");
                        break;
                }
            }
        }
    }
}
