using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreadAndAysncProgramming.Threads
{
    /*
     Thread mainly 2 purpose solve karte hi
     1. Divide and Conquer
     2. Offloading Long Running Task
     */
    public class LearnThread
    {
        Queue<string> inputQueue = new Queue<string>();
        public void Execute()
        {
            #region [ - To Print ThreadId- ]
            //PrintThreadIdExample();
            #endregion

            #region [ - Print ThreadId from 2 Thread to check time slicing - ]
            //CheckTimeSlicing();
            #endregion

            #region[-- Thread Priority --]
            //ThreadPriorityExample();
            #endregion

            #region [- Give Custom name to thread-]
            //ThreadName();
            #endregion

            #region [- Why Threading: Divideand Conquer -]
            //DivideAndConquer();
            #endregion

            #region[- Why Threading : Offloading Long Running Task -]
            //OffLoadLongRunningTask();
            #endregion

            #region[-- simulate Web Server --]
            SimulateWebServer();
            #endregion

            #region [ - Paramaterized Function -]
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
            while(true)
            {
                if(inputQueue.Count > 0 )
                {
                    string? input = inputQueue.Dequeue();
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
            Thread.Sleep(2000); // Simulate processing time
            Console.WriteLine($"Processed input - {request}");
        }

        private void OffLoadLongRunningTask()
        {
            Console.WriteLine("OffLoadLongRunningTask Start");
            OffLoadLongRunningTaskWithOutThread();
            OffLoadLongRunningTaskWithThread();

            Console.ReadLine();
        }

        private void OffLoadLongRunningTaskWithThread()
        {
            var startTime = DateTime.Now;
            // Simulating a long-running task
            Thread thread = new Thread(() =>
            {
                Thread.Sleep(5000); // 5 seconds
                Console.WriteLine("Long-running task completed.");
            });
            thread.Start();
            var endTime = DateTime.Now;
            var timeTaken = endTime - startTime;
            Console.WriteLine($"Time taken with threading: {timeTaken.TotalMilliseconds} ms");
        }

        private void OffLoadLongRunningTaskWithOutThread()
        {
            var startTime = DateTime.Now;
            // Simulating a long-running task
            Thread.Sleep(5000); // 5 seconds
            var endTime = DateTime.Now;
            var timeTaken = endTime - startTime;
            Console.WriteLine($"Time taken without threading: {timeTaken.TotalMilliseconds} ms");
        }

        private void DivideAndConquer()
        {
            WithOutThread();
            WithThread();
            
        }

        private void WithThread()
        {
            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int sum1 = 0,sum2 = 0, sum3=0,sum4 =0;
            int numThreads = 4;
            int segmentLength = array.Length / numThreads;
            Thread[] threads = new Thread[numThreads];

            var startTime = DateTime.Now;
            threads[0] = new Thread(() => { sum1 = SumArrayPart(array, 0, segmentLength); });
            threads[1] = new Thread(() => { sum2 = SumArrayPart(array, segmentLength, segmentLength * 2); });
            threads[2] = new Thread(() => { sum3 = SumArrayPart(array, segmentLength * 2, segmentLength * 3); });
            threads[3] = new Thread(() => { sum4 = SumArrayPart(array, segmentLength * 3, array.Length); });

            for (int i = 0; i < numThreads; i++)
            {
                threads[i].Start();
            }
            for (int i = 0; i < numThreads; i++)
            {
                threads[i].Join();
            }
            var endTime = DateTime.Now;

            var timeTaken = endTime - startTime;
            Console.WriteLine($"Sum: {sum1 + sum2 +sum3+sum4}, Time taken with threading: {timeTaken.TotalMilliseconds} ms");
        }
        int SumArrayPart(int[] array, int startIndex, int endIndex)
        {
            int sum = 0;
            for (int i = startIndex; i < endIndex; i++)
            { 
                Thread.Sleep(100);
                sum += array[i];
            }
            return sum;
        }

        private void WithOutThread()
        {
            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int sum = 0;
            var startTime = DateTime.Now;
            foreach (var item in array)
            {
                Thread.Sleep(100);
                sum += item;
            }
            var endTime = DateTime.Now;

            var timeTaken = endTime - startTime;
            Console.WriteLine($"Sum: {sum}, Time taken without threading: {timeTaken.TotalMilliseconds} ms");
        }

        private void ThreadName()
        {
            Thread.CurrentThread.Name = "Main Thread";
            WriteThreadName();
            var customNamedThread = new Thread(WriteThreadName);
            customNamedThread.Name = "Custom Named Thread";
            customNamedThread.Start();
        }

        private void ThreadPriorityExample()
        {
            var additionalThread4 = new Thread(WriteThreadId100Times);
            var additionalThread5 = new Thread(WriteThreadId100Times);
            additionalThread4.Priority = ThreadPriority.Highest;
            additionalThread5.Priority = ThreadPriority.Lowest;
            additionalThread4.Start();
            additionalThread5.Start();
        }

        private void CheckTimeSlicing()
        {
            WriteThreadId100Times();
            var additionalThread2 = new Thread(WriteThreadId100Times);
            var additionalThread3 = new Thread(WriteThreadId100Times);
            additionalThread3.Start();
            additionalThread2.Start();
        }

        private void PrintThreadIdExample()
        {
            WriteThreadId();
            var additionalThread = new Thread(WriteThreadId);
            additionalThread.Start();
        }

        private void WriteThreadId100Times()
        {
            for (int i = 0; i < 100; i++)
            {
                //Thread.Sleep(10);
                Console.WriteLine($"Thread Id : {Thread.CurrentThread.ManagedThreadId} - Count : {i}");
            }
        }

        private void WriteThreadId()
        {
            Console.WriteLine($"Thread Id : {Thread.CurrentThread.ManagedThreadId}");
        }

        private void WriteThreadName()
        {
            Console.WriteLine($"Thread Name : {Thread.CurrentThread.Name}");
        }


    }
}
