using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreadAndAysncProgramming.Threads
{
    public class ThreadWaitExamples
    {
        public void Execute()
        {
            // Move out of CPU for 1 second
            Thread.Sleep(1000);

            // Wait for 100 itegration in loop
            // Do not move out of CPU
            Thread.SpinWait(100);


            // Wait until the current second is multiple of 10 or timeout after 5 seconds
            // Do not move out of CPU
            SpinWait.SpinUntil(() => DateTime.Now.Second % 10 == 0, 5000);
        }
    }
}
