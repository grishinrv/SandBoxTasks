namespace GcDemo;

public class Program
{
    private const string EXIT_COMMAND = "exit";
    public static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine($"Type a name, then press  Enter to spawn EventPublisher object, OR type {EXIT_COMMAND} to close app");
            string input = Console.ReadLine();
            if (string.Equals(input, EXIT_COMMAND, StringComparison.InvariantCultureIgnoreCase))
            {
                break;
            }
            EventPublisher.Create(input).SomethingHappened += s => Console.WriteLine(s);
        }
    }
}