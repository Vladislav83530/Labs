namespace ClockTask.Models.Time
{
    internal class AnalogTime : ITime
    {
        private int hourHandRotation;
        private int minuteHandRotation;
        private int secondHandRotation;
        public AnalogTime(int hourRotation, int minuteRotation, int secondRotation)
        {
            if (hourRotation < 0 || hourRotation > 360)
            {
                throw new ArgumentException("The rotation angle of the hour hand must be in the range from 0 to 360.");
            }

            if (minuteRotation < 0 || minuteRotation > 360)
            {
                throw new ArgumentException("The rotation angle of the minute hand must be in the range from 0 to 360.");
            }

            if (secondRotation < 0 || secondRotation > 360)
            {
                throw new ArgumentException("The rotation angle of the second hand must be in the range from 0 to 360.");
            }

            hourHandRotation = hourRotation;
            minuteHandRotation = minuteRotation;
            secondHandRotation = secondRotation;
        }

        public override string ToString()
        {
            return $"Hours: {hourHandRotation} degrees, Minutes: {minuteHandRotation} degrees, Seconds: {secondHandRotation} degrees";
        }
    }
}
