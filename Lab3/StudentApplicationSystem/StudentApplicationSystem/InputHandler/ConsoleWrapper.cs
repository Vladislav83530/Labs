using StudentApplicationSystem.InputHandler.Interfaces;

namespace StudentApplicationSystem.InputHandler
{
    internal class ConsoleWrapper : IConsoleWrapper
    {
        public void Write(string message)
        {
            Console.Write(message);
        }

        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void WriteLineException(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
