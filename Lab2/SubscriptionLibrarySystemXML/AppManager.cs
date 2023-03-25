using SubscriptionLibrarySystemXML.ConsoleReader;
using SubscriptionLibrarySystemXML.ConsoleReader.Abstract;
using SubscriptionLibrarySystemXML.FileProcessor.Abstract;
using SubscriptionLibrarySystemXML.Models;

namespace SubscriptionLibrarySystemXML
{
    internal class AppManager
    {
        private IConsoleReader _consoleReader;
        private readonly IFileProcessor fileProcessor;

        public AppManager(IFileProcessor fileProcessor)
        {
            this.fileProcessor = fileProcessor;
        }
        public void Main()
        {
            while (true)
            {
                Console.WriteLine("Make a choice:");
                Console.WriteLine("(1) - Write entity to XML used Console");
                Console.WriteLine("(2) - Upload XML file used XMLDocument");
                Console.WriteLine("(3) - Upload XML file user XMLSerializer");
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
                        var library = fileProcessor.ReadFile(fileName);
                        Console.WriteLine(library.ToString());
                        break;
                    case "3":
                        Console.Write("Enter file name: ");
                        string fileName_ = Console.ReadLine();
                        try
                        {
                            var library_ = fileProcessor.DeserializeFile(fileName_);
                            Console.WriteLine(library_.ToString());
                        }
                        catch
                        {
                            Console.WriteLine("Wrong file. PLease, try again");
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
                        catch(FormatException)
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
                        catch(FormatException)
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
    }
}
