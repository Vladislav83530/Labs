using ClockTask.Strategies.Abstract;

namespace ClockTask.Strategies
{
    internal class ConsoleNotoficator : INotificationStrategy
    {
        public void ShowNotification(string message)
        {
            Console.WriteLine(message);
        }
    }
}
