namespace ClockTask.Models.Time
{
    internal class DigitalTime : ITime
    {
        public DateTime time { get; set; }
        public DigitalTime(DateTime time)
        {
            this.time = time != default ? time : throw new ArgumentException("Time cannot have an undefined value.");
        }

        public override string ToString()
        {
            return time.ToString();
        }
    }
}
