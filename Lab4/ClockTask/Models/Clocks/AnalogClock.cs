using ClockTask.Models.Clocks.Abstract;
using ClockTask.Models.Time;
using ClockTask.Strategies.Abstract;

namespace ClockTask.Models.Clocks
{
    internal class AnalogClock : IClock
    {
        private AnalogTime time;
        private readonly INotificationStrategy notificationStrategy;

        public AnalogClock(AnalogTime time, INotificationStrategy notificationStrategy)
        {
            this.time = time;
            this.notificationStrategy = notificationStrategy ?? throw new ArgumentNullException(nameof(notificationStrategy));
        }

        public void ShowTime()
        {
            string notification = $"Analog clock: The rotation angle of the hour hand - {time}";
            notificationStrategy.ShowNotification(notification);
        }
    }
}
