using ClockTask.Models.Clocks.Abstract;
using ClockTask.Strategies.Abstract;

namespace ClockTask.ClockDecorators.Abstract
{
    internal abstract class ClockDecorator : IClock
    {
        protected IClock clock;
        protected readonly INotificationStrategy notificationStrategy;

        public ClockDecorator(IClock clock, INotificationStrategy notificationStrategy)
        {
            this.clock = clock ?? throw new ArgumentNullException(nameof(clock));
            this.notificationStrategy = notificationStrategy ?? throw new ArgumentNullException(nameof(notificationStrategy));
        }

        public abstract void ShowTime();
    }
}
