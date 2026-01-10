using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreadAndAysncProgramming
{
    // This Class demonstrates ManualResetEvent synchronization in C#.
    // A ManualResetEvent is a synchronization primitive that can be used to signal between threads.
    // Take Pig and Farmer example where Farmer needs to signal all Pigs to start eating.
    // When the Farmer signals the ManualResetEvent, all waiting threads (Pigs) are released and can proceed.
    // The ManualResetEvent remains in the signaled state until it is manually reset, allowing multiple threads to proceed.
    // Difference between AutoResetEvent and ManualResetEvent is that AutoResetEvent automatically resets after releasing a single thread,
    // whereas ManualResetEvent remains signaled until explicitly reset, allowing multiple threads to proceed.
    public class ManualResetEventExample
    {
        ManualResetEvent consumerResetEvent = new ManualResetEvent(false);
        ManualResetEvent producerResetEvent = new ManualResetEvent(true);
        object lockObject = new object();
        Queue<int> queue = new Queue<int>();
        int consumerCount = 0;
        public void Execute()
        {
            #region [-- Pig Farmer --]
            //PigFarmer();
            #endregion

            #region[-- Two way signaling in Producer and Consumer--]
            TwoWaySignalingInProducerAndConsumer();
            #endregion

        }

        private void TwoWaySignalingInProducerAndConsumer()
        {
            Thread[] pigs = new Thread[3];
            for (int i = 0; i < 3; i++)
            {
                pigs[i] = new Thread(EatFood);
                pigs[i].Name = $"Pig-{i + 1}";
                pigs[i].Start();
            }

            while (true)
            {
                producerResetEvent.WaitOne();
                producerResetEvent.Reset();
                Console.WriteLine("Press 'p' to produce item");
                var input = Console.ReadLine();
                if(input.ToLower() == "p")
                {
                    for (int i = 0; i < 10; i++)
                    {
                        queue.Enqueue(i+1);
                    }
                    Console.WriteLine("Items produced. Signaling consumer to consume items.");
                    consumerResetEvent.Set();
                }
            }
        }

        private void EatFood()
        {
            while (true)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name} is waiting for food");
                consumerResetEvent.WaitOne();
                while(queue.TryDequeue(out var input))
                {
                    Thread.Sleep(1000);
                    Console.WriteLine($"{Thread.CurrentThread.Name} is eating item {input}");

                }
                lock (lockObject)
                {
                    consumerCount++;
                    if (consumerCount == 3)
                    {
                        consumerResetEvent.Reset();
                        producerResetEvent.Set();
                        consumerCount = 0;
                    }
                }
                   
                   

            }
            
        }

        private void PigFarmer()
        {
            Console.WriteLine("Please enter to get eat all pigs");
            for (int i = 0; i < 3; i++)
            {
                var pig = new Thread(WorkerThread);
                pig.Name = $"Pig-{i + 1}";
                pig.Start();
            }

            Console.ReadLine();
            consumerResetEvent.Set();

            Console.ReadLine();
        }

        private void WorkerThread(object? obj)
        {
            Console.WriteLine($"{Thread.CurrentThread.Name} Waiting for food");
            consumerResetEvent.WaitOne();
            Thread.Sleep(1000);
            Console.WriteLine($"{Thread.CurrentThread.Name} Eating food");

        }
    }

}
