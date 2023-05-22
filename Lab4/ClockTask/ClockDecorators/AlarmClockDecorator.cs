using ClockTask.ClockDecorators.Abstract;
using ClockTask.Models.Clocks;
using ClockTask.Models.Clocks.Abstract;
using ClockTask.Models.Time;
using ClockTask.Strategies.Abstract;

namespace ClockTask.ClockDecorators
{
    internal class AlarmClockDecorator :  ClockDecorator
    {
        private ITime alarmTime;

        public AlarmClockDecorator(IClock clock, INotificationStrategy notificationStrategy, ITime alarmTime) : base(clock, notificationStrategy)
        {
            if (clock is AnalogClock && alarmTime is DigitalTime)
            {
                throw new ArgumentException("Analog clock cannot work with digital time.");
            }

            if (clock is DigitalClock && alarmTime is AnalogTime)
            {
                throw new ArgumentException("Digital clock cannot work with analog time.");
            }

            this.alarmTime = alarmTime;
        }

        public override void ShowTime()
        {
            clock.ShowTime();

            string notification = $"Alarm: Trigger time - {alarmTime}";
            notificationStrategy.ShowNotification(notification);
        }
    }
}
