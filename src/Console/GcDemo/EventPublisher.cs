namespace GcDemo;

public sealed class EventPublisher
{
    private readonly Random _random;
    private readonly Timer _timer;
    private readonly string _name;
    public event Action<string> SomethingHappened;
    private long _i;

    private EventPublisher(string name)
    {
        _name = name;
        _random = new Random();
        _timer = new Timer(TimerOnElapsed);
        _timer.Change(300, _random.NextInt64(1, 5) * 1000);
    }

    public static EventPublisher Create(string name)
    {
        return new EventPublisher(name);
    }

    private void TimerOnElapsed(object sender)
    {
        _timer.Change(_random.NextInt64(1, 5) * 1000, Timeout.Infinite);
        SomethingHappened?.Invoke($"Hello #{Interlocked.Increment(ref _i)} from {_name}!");
    }

    public void StopEventsSpawn()
    {
        _timer.Change(Timeout.Infinite, Timeout.Infinite);
        _timer.Dispose();
    }
}