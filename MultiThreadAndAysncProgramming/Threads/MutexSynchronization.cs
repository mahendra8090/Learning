using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreadAndAysncProgramming.Threads
{
    // This Class demonstrates mutex synchronization in C#.
    // A mutex is a synchronization primitive that can be used to protect shared data from being simultaneously accessed by multiple threads.
    // Unlike a lock, a mutex can be used for inter-process synchronization as well.
    // However, mutexes are generally slower than locks due to the overhead of kernel mode transitions.
    // Therefore, they should be used only when necessary.
    // In this example, we will create a simple mutex to synchronize access to a shared resource.
    public class MutexSynchronization
    {
        public void Execute()
        {
            #region[-- Increament Counter using Mutex in file--]
            IncrementCounterUsingMutex();
            #endregion
        }

        private void IncrementCounterUsingMutex()
        {
            string filePath = "counter.txt";
            using(var mutex =  new Mutex(false,$"GlobalMutex:{filePath}"))
            {
                for (int i = 0; i < 1000; i++)
                {
                    mutex.WaitOne();
                    try
                    {
                        Thread.Sleep(1);
                        int counter = ReadCounterFromFile(filePath);
                        counter++;
                        WriteCounterFromFile(filePath, counter);
                    }
                    finally
                    {
                        mutex.ReleaseMutex();
                    }
                }
            }
            
        }

        public int ReadCounterFromFile(string filePath)
        {
            using (var stream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Read, FileShare.ReadWrite))
                using (var reader = new StreamReader(stream)) { 
                string content =  reader.ReadToEnd(); 
                return string.IsNullOrEmpty(content) ? 0 : int.Parse(content);
            }
        }
        public void WriteCounterFromFile(string filePath,int counter) {
            using (var stream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite))
            using (var writer = new StreamWriter(stream))
            {
                writer.Write(counter.ToString());
            }
        }
    }
}
