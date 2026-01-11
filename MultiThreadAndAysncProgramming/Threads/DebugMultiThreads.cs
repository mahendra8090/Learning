using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreadAndAysncProgramming.Threads
{
    public class DebugMultiThreads
    {
        public void Execute()
        {
            for (int i = 0; i < 10; i++)
            {
                var thread = new Thread(Work);
                thread.Name = "My thread " + (i + 1);
                thread.Start();
            }
        }
        void Work()
        { 
            Console.WriteLine("Working...");
            Thread.Sleep(1000);
            Console.WriteLine("Work completed.");
        }
    }
}
