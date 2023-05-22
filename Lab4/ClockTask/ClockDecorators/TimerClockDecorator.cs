using ClockTask.ClockDecorators.Abstract;
using ClockTask.Models.Clocks.Abstract;
using ClockTask.Strategies.Abstract;

namespace ClockTask.ClockDecorators
{
    internal class TimerClockDecorator : ClockDecorator
    {
        private TimeSpan duration;

        public TimerClockDecorator(IClock clock, INotificationStrategy notificationStrategy, TimeSpan duration) : base(clock, notificationStrategy)
        {
            this.duration = duration;
        }

        public override void ShowTime()
        {
            clock.ShowTime();

            string notification = $"Alarm: Trigger time - {duration}";
            notificationStrategy.ShowNotification(notification);
        }
    }
}
