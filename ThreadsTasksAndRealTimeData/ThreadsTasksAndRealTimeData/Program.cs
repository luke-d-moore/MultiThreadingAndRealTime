public class Program
{
    static void Main(string[] args)
    {
        var mainThread = Thread.CurrentThread;
        mainThread.Name = "Main Console Thread";

        Console.WriteLine($"{mainThread.Name} is now starting!");

        var Task1 = Task.Run(() => WriteToConsoleWithIncrement(10, 1000, "Task1"));
        var Task2 = Task.Run(() => WriteToConsoleWithIncrement(5, 2000, "Task2"));

        Task.WaitAll([Task1, Task2]);

        var thread1 = new Thread(() => WriteToConsoleWithIncrement(10, 1000, "Thread1"));
        var thread2 = new Thread(() => WriteToConsoleWithIncrement(5, 2000, "Thread2"));

        thread1.Start();
        thread2.Start();

        Console.WriteLine($"{mainThread.Name} is now complete!");

        Console.ReadKey();
    }
    public static void WriteToConsoleWithIncrement(int Max, int Milliseconds, string Name) 
    { 
        for (int i = 0; i < Max; i++)
        {
            Console.WriteLine($"Writing... {i} {Name}");
            Thread.Sleep(Milliseconds);
        }
    }
}