using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreadAndAysncProgramming.Threads
{

    public class CancelingThread
    {
        CancellationTokenSource cts = new CancellationTokenSource();
        public void Execute()
        {
          Thread workerThread = new Thread(() =>
          {
              while (true)
              {
                  // Check for cancellation request
                  if (cts.Token.IsCancellationRequested)
                  {
                      Console.WriteLine("Cancellation requested. Exiting thread.");
                      break;
                  }
                  // Simulate work
                  Work();
              }
          });
            workerThread.Start();

            var input = Console.ReadLine(); // Wait for user input to start
            if(input.ToLower()=="c")
            {
                cts.Cancel(); // Request cancellation
            }

        }   

        void Work() {
        
            Console.WriteLine("Working...");
            Thread.Sleep(1000); // Simulate work by sleeping

        }
    }
}
