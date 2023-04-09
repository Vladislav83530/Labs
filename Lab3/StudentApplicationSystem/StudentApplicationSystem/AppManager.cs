using StudentApplicationSystem.ApplicantFactory.Interfaces;
using StudentApplicationSystem.ApplicantFactory.Json;
using StudentApplicationSystem.ApplicantFactory.Xml;
using StudentApplicationSystem.Models;

namespace StudentApplicationSystem
{
    internal class AppManager
    {
        private readonly InputManager _inputManager;
        private string schema;

        public AppManager( InputManager inputManager)
        {
            _inputManager = inputManager;
        }

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("Make a choice:");
                Console.WriteLine("(1) - Enter applicants and save");
                Console.WriteLine("(2) - Load applicant from json file");
                Console.WriteLine("(3) - Load applicant from xml file");
                Console.WriteLine("Enter 'exit' if you want to end");

                string choose = Console.ReadLine()!;
                Console.Clear();

                switch (choose.ToLower())
                {
                    case "1":
                        SaveData();
                        break;
                    case "2":
                        LoadData(".json");
                        break;
                    case "3":
                        LoadData(".xml");
                        break;
                    case "4":
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
            List<Applicant> applicants = new List<Applicant>();
            bool isNotSave = true;
            while (isNotSave)
            {
                Console.WriteLine("Make a choice:");
                Console.WriteLine("(1) - Add applicants");
                Console.WriteLine("Enter 'save' if you enter all value");

                string choice = Console.ReadLine()!;
                Console.Clear();

                switch (choice.ToLower())
                {
                    case "1":
                        Applicant applicant = _inputManager.ReadApplicant();
                        applicants.Add(applicant);
                        break;
                    case "save":
                        SaveApplicants(applicants);
                        Console.Clear();
                        isNotSave = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice\n");
                        break;
                }
            }
        }
        private void SaveApplicants(List<Applicant> applicants)
        {
            while (true)
            {
                Console.WriteLine("Enter file name:");
                var fileName = Console.ReadLine()!;

                Console.WriteLine("Enter format:");
                var fileFormat = Console.ReadLine()!;

                if (string.IsNullOrEmpty(fileName) || File.Exists(fileName))
                {
                    Console.WriteLine("File name can not be empty or file with this name is exists. Try again");
                    continue;
                }
                else
                {
                    IApplicantFileFactory factory;
                    if (fileFormat.ToLower() == ".json")
                        factory = new ApplicantJsonFactory();
                    else if (fileFormat.ToLower() == ".xml")
                       factory = new ApplicantXmlFactory();
                    else
                    {
                        Console.WriteLine("Invalid format. Try again.");
                        continue;
                    }

                    var saver = factory.CreateFileSaver();
                    saver.Save(applicants, fileName);
                    break;
                }
            }
        }
        private void LoadData(string fileFormat)
        {
            while (true)
            {
                Console.WriteLine("Enter file name:");
                var fileName = Console.ReadLine()!;
                string fileExtension = Path.GetExtension(fileName);

                if (string.IsNullOrEmpty(fileName) || !File.Exists(fileName) || fileExtension != fileFormat)
                {
                    Console.WriteLine("File name can not be empty or file with this name is not exists. Try again");
                    continue;
                }

                IApplicantFileFactory factory;
                if (fileFormat.ToLower() == ".json")
                {
                    factory = new ApplicantJsonFactory();
                    schema = "JsonShema.json";
                }
                else if (fileFormat.ToLower() == ".xml")
                {
                    factory = new ApplicantXmlFactory();
                    schema = "XmlSchema";
                }
                else
                {
                    Console.WriteLine("Invalid format. Try again.");
                    continue;
                }

                bool isValidFile = factory.CreateFileValidator().IsValid(fileName, schema);
                if (!isValidFile)
                {
                    Console.WriteLine("File is not valid");
                    continue;
                }

                var loader = factory.CreateFileLoader();
                var applicants = loader.Load(fileName);
                foreach ( var applicant in applicants) 
                {
                    Console.WriteLine(applicant.ToString());
                    Console.WriteLine(new string('-', 50));
                }
                break;
            }
        }
    }
}
