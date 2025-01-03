using System;
using System.Diagnostics;
namespace CounterTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Clock clock = new Clock();

            Stopwatch stopwatch = new Stopwatch();
            Process proc = Process.GetCurrentProcess();
            long memoryBefore = proc.WorkingSet64;
            stopwatch.Start();

            for (int i = 0; i < 25 * 3600; i++)
            {
                clock.Tick();
                Console.WriteLine(clock.GetTime());
                System.Threading.Thread.Sleep(1);
            }

            stopwatch.Stop();

            long memoryAfter = proc.WorkingSet64;
            Console.WriteLine($"Execution Time: {stopwatch.ElapsedMilliseconds} ms");
            Console.WriteLine($"Memory Usage Before: {memoryBefore} bytes");
            Console.WriteLine($"Memory Usage After: {memoryAfter} bytes");
            Console.WriteLine($"Memory Increase: {memoryAfter - memoryBefore} bytes");
        }
    }
}



