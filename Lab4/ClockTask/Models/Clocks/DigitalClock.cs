using ClockTask.Models.Clocks.Abstract;
using ClockTask.Models.Time;
using ClockTask.Strategies.Abstract;

namespace ClockTask.Models.Clocks
{
    internal class DigitalClock : IClock
    {
        private DigitalTime currentTime;
        private readonly INotificationStrategy notificationStrategy;

        public DigitalClock(DigitalTime time, INotificationStrategy notificationStrategy)
        {
            currentTime = time;
            this.notificationStrategy = notificationStrategy ?? throw new ArgumentNullException(nameof(notificationStrategy));
        }

        public void ShowTime()
        {
            string notification = $"Digital clock: Current time - {currentTime.time.ToString("HH:mm:ss")}";
            notificationStrategy.ShowNotification(notification);
        }
    }
}
