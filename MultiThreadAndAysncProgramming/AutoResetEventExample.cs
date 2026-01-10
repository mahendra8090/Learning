using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreadAndAysncProgramming
{
    // This Class demonstrates AutoResetEvent synchronization in C#.
    // An AutoResetEvent is a synchronization primitive that can be used to signal between threads.
    // When one thread signals the AutoResetEvent, it releases a single waiting thread and then automatically resets to the non-signaled state.
    public class AutoResetEventExample
    {
        AutoResetEvent autoResetEvent = new AutoResetEvent(false);
        public void Execute()
        {
            Console.WriteLine("AutoResetEvent Example Started");
            for (int i = 0; i < 3; i++)
            {
                var pig = new Thread(WorkerThread);
                pig.Name = $"Pig-{i + 1}";
                pig.Start();
            }



           while(true)
            {
                var input = Console.ReadLine();
                if(input?.ToLower() == "g")
                {
                    autoResetEvent.Set();
                }
            }
        }

        private void WorkerThread()
        {
            while (true)
            {
                Console.WriteLine("Worker Thread is waiting for signal...");
                autoResetEvent.WaitOne();
                Console.WriteLine($"Worker Thread  is proceeding... Thread name - {Thread.CurrentThread.Name}");
                Thread.Sleep(1000);
            }
        }
    }
}
