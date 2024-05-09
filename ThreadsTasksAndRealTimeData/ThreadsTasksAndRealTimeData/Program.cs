public class Program
{
    public static decimal _Data = 0.50m;
    public static void Main(string[] args)
    {
        var mainThread = Thread.CurrentThread;
        mainThread.Name = "Main Console Thread";

        Console.WriteLine($"{mainThread.Name} is now starting!");

        //make a task to continuously run to generate realtime data
        var DataTask = Task.Run(() => GenerateRealTimeData(80, 250));

        //run the tasks and print the real time data
        var Task1 = Task.Run(() => WriteToConsoleWithIncrement(10, 1000, "Task1"));
        var Task2 = Task.Run(() => WriteToConsoleWithIncrement(5, 1700, "Task2"));

        //await all tasks to complete
        Task.WaitAll([Task1, Task2]);

        //run the threads and print the real time data
        var thread1 = new Thread(() => WriteToConsoleWithIncrement(10, 1000, "Thread1"));
        var thread2 = new Thread(() => WriteToConsoleWithIncrement(5, 1700, "Thread2"));

        thread1.Start();
        thread2.Start();

        Console.WriteLine($"{mainThread.Name} is now complete!");

        Console.ReadKey();
    }
    public static void WriteToConsoleWithIncrement(int Max, int Milliseconds, string Name) 
    { 
        for (int i = 0; i <= Max; i++)
        {
            Console.WriteLine($"Writing... {i} {Name}, current value of Data : {_Data}");
            Thread.Sleep(Milliseconds);
        }
    }

    public static void GenerateRealTimeData(int Max, int milliseconds)
    {
        for(int i = 0;i <= Max; i++)
        {
            var rand = new Random();
            _Data = new decimal(rand.NextDouble());
            Thread.Sleep(milliseconds);
        }
    }
}