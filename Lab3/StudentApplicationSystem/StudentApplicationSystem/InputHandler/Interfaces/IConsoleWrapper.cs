namespace StudentApplicationSystem.InputHandler.Interfaces
{
    internal interface IConsoleWrapper
    {
        void Write(string message);
        void WriteLine(string message);
        string ReadLine();
    }
}
