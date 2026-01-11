using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreadAndAysncProgramming.Threads
{
    // Thread Pool is specific to Application not OS level
    // 

    /*
     Whats Thread Minimum and Maximum in .NET?
     In .NET, the ThreadPool class manages a pool of worker threads that can be used to execute tasks asynchronously. 
     The minimum and maximum number of threads in the ThreadPool can be configured using the SetMinThreads and SetMaxThreads methods.
        By default, the minimum number of threads is set to the number of processors on the machine, and the maximum number of threads is set to 32767.
        You can retrieve the current minimum and maximum thread counts using the GetMinThreads and GetMaxThreads methods.

     
     */
    public class ThreadPoolExample
    {
        public void Execute()
        {
            var threadCount = ThreadPool.ThreadCount;
            Thread thread = ThreadPool.();
        }
    }
}
