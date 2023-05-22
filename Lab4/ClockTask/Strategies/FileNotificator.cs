using ClockTask.Strategies.Abstract;

namespace ClockTask.Strategies
{
    public class FileNotificator : INotificationStrategy
    {
        private string filePath;

        public FileNotificator(string path)
        {
            filePath = path;
        }

        public void ShowNotification(string time)
        {
            File.WriteAllText(filePath, time);
        }
    }
}
