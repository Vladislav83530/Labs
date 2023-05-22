using ClockTask.ClockDecorators.Abstract;
using ClockTask.Models.Clocks.Abstract;
using ClockTask.Strategies.Abstract;
using System.Diagnostics;

namespace ClockTask.ClockDecorators
{
    internal class StopwatchClockDecorator : ClockDecorator
    {
        private Stopwatch stopwatch;

        public StopwatchClockDecorator(IClock clock, INotificationStrategy notificationStrategy) : base(clock, notificationStrategy)
        {
            stopwatch = new Stopwatch();
        }

        public override void ShowTime()
        {
            stopwatch.Stop();
            TimeSpan elapsed = stopwatch.Elapsed;

            clock.ShowTime();
            Console.WriteLine($"Stopwatch: Spent time - {elapsed.TotalSeconds} seconds");
        }

        public void StartStopwatch()
        {
            stopwatch.Start();
        }
    }
}
