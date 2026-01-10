using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreadAndAysncProgramming
{
    // This Class demonstrates semaphore synchronization in C#.
    // A semaphore is a synchronization primitive that can be used to limit the number of threads that can access a shared resource concurrently.
    // Unlike a lock or mutex, a semaphore allows multiple threads to enter the critical section up to a specified limit.
    // This is useful when you have a resource that can handle multiple concurrent accesses, such as a connection pool or a limited number of database connections.
    // In this example, we will create a simple semaphore to limit access to a shared resource.
    // Allow up to 3 concurrent accesses
    public class SemaPhoreExample
    {
        Queue<string> inputQueue = new Queue<string>();
        SemaphoreSlim semaphore = new SemaphoreSlim(3,3);
        public void Execute()
        {
            #region[-- simulate Web Server --]
            SimulateWebServer();
            #endregion
        }
        private void SimulateWebServer()
        {
            Console.WriteLine("SimulateWebServer Start. Please type 'exit' to stop");
            new Thread(MonitorQueue).Start();
            while (true)
            {
                Console.Write("Enter request (type 'exit' to quit): ");
                string request = Console.ReadLine();
                if (request.ToLower() == "exit")
                    break;
                inputQueue.Enqueue(request);
            }


        }
        private void MonitorQueue()
        {
            while (true)
            {
                if (inputQueue.Count > 0)
                {
                    string? input = inputQueue.Dequeue();
                    semaphore.Wait();
                    Thread processingThread = new Thread(() =>
                    {
                        ProcessRequest(input);
                    });
                    processingThread.Start();
                }
                Thread.Sleep(100);
            }
        }

        private void ProcessRequest(string request)
        {
            try
            {
                Thread.Sleep(2000); // Simulate processing time
                Console.WriteLine($"Processed input - {request}");
                Console.WriteLine($"Current thread - {semaphore.CurrentCount}" );
            }
            finally
            {
             semaphore.Release();
            }

        }
    }
}
