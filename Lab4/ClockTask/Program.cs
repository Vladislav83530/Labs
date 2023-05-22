using ClockTask.ClockDecorators;
using ClockTask.Models.Clocks;
using ClockTask.Models.Clocks.Abstract;
using ClockTask.Models.Time;
using ClockTask.Strategies;
using ClockTask.Strategies.Abstract;

INotificationStrategy consoleStrategy = new ConsoleNotoficator();
INotificationStrategy fileStrategy = new FileNotificator("time.txt");

AnalogTime analogTime = new AnalogTime(90, 180, 270);
DigitalTime digitalTime = new DigitalTime(DateTime.Now);

Console.WriteLine("Analog Clock");
IClock analogClock = new AnalogClock(analogTime, consoleStrategy);
analogClock.ShowTime();
Console.WriteLine("\n");

Console.WriteLine("Alarm (analog clock)");
ITime alarmAnalogTime = new AnalogTime(90, 210, 300);
IClock alarmAnalogClock = new AlarmClockDecorator(analogClock, consoleStrategy, alarmAnalogTime);
alarmAnalogClock.ShowTime();
Console.WriteLine("\n");

Console.WriteLine("Digital Clock)");
IClock digitalClock = new DigitalClock(digitalTime, consoleStrategy);
digitalClock.ShowTime();
Console.WriteLine("\n");

Console.WriteLine("Alarm (digital clock)");
ITime alarmDigitalTime = new DigitalTime(DateTime.Now.AddMinutes(10));
IClock alarmDigitalClock = new AlarmClockDecorator(digitalClock, consoleStrategy, alarmDigitalTime);
alarmDigitalClock.ShowTime();
Console.WriteLine("\n");

Console.WriteLine("Timer (digital clock)");
TimeSpan duration = TimeSpan.FromMinutes(5);
IClock timerClock = new TimerClockDecorator(digitalClock, consoleStrategy, duration);
timerClock.ShowTime();
Console.WriteLine("\n");

Console.WriteLine("Stopwatch (digital clock)");
IClock stopwatchClock = new StopwatchClockDecorator(digitalClock, consoleStrategy);
((StopwatchClockDecorator)stopwatchClock).StartStopwatch();
Thread.Sleep(4000);
stopwatchClock.ShowTime();
Console.WriteLine("\n");


Console.WriteLine("Analog Clock (write to file)");
IClock analogClock2 = new AnalogClock(analogTime, fileStrategy);
analogClock2.ShowTime();
Console.WriteLine("\n");
