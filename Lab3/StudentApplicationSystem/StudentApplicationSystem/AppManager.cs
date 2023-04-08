using StudentApplicationSystem.Models;

namespace StudentApplicationSystem
{
    internal class AppManager
    {
        private readonly InputManager _inputManager;

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
                Console.WriteLine("(2) - ");
                Console.WriteLine("(3) - ");
                Console.WriteLine("(4) - ");
                Console.WriteLine("Enter 'exit' if you want to end");

                string choose = Console.ReadLine()!;
                Console.Clear();

                switch (choose.ToLower())
                {
                    case "1":
                        SaveData();
                        break;
                    case "2":
                        break;
                    case "3":
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
                        while (true)
                        {
                            Console.WriteLine("Enter file name:");
                            var fileName = Console.ReadLine()!;

                            Console.WriteLine("Enter format:");
                            var fileFormat = Console.ReadLine()!;

                            if (string.IsNullOrEmpty(fileName) || File.Exists(fileName))
                                Console.WriteLine("File name can not be empty or file with this name is exists. Try again");
                            else
                            {
                                //use abstract factory 
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
       private void LoadData() { }
    }
}
