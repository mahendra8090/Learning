using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreadAndAysncProgramming.Threads
{
    // This Class demonstrates thread synchronization using lock statements in C#.
    public class ThreadSynchronization
    {
        public object counterObject = new object();
        public object monitorObject = new object();
        int counter1 = 0;
        int counter2 = 0;
        Queue<string> bookingQueue = new Queue<string>();
        public object bookingObject = new object();

        int availableSeats = 10;
        public void Execute()
        {
            #region[- Simple counter Increment Task -]
            //SimpleCounterIncrementTask();
            #endregion

            #region[-- AirPlane Seat booking system --]
            //AirPlaneSeatBookingSystemUsingLock();
            #endregion

            #region [-- Use of Monitor --]
            //SimpleCounterIncrementTaskUsingMonitor();
            #endregion

            #region[-- AirPlane Seat booking system using Monitor --]
            AirPlaneSeatBookingSystemUsingMonitor();
            #endregion
        }

        private void AirPlaneSeatBookingSystemUsingMonitor()
        {
            Console.WriteLine("AirPlane Seat Booking System Started using monitor. Please B to Book and C to cancle a ticket. Exit to exit");
            new Thread(BookingMonitorUsingMonitor).Start();
            while (true)
            {
                var request = Console.ReadLine();
                if (request.ToLower() == "exit")
                    break;
                bookingQueue.Enqueue(request.ToLower());
            }
        }
        private void AirPlaneSeatBookingSystemUsingLock()
        {
            Console.WriteLine("AirPlane Seat Booking System Started. Please B to Book and C to cancle a ticket. Exit to exit");
            new Thread(BookingMonitorUsingLock).Start();
            while (true)
            {
                var request = Console.ReadLine();
                if (request.ToLower() == "exit")
                    break;
                bookingQueue.Enqueue(request.ToLower());
            }
        }

        private void SimpleCounterIncrementTaskUsingMonitor()
        {
            Thread thread1 = new Thread(IncrementCounterWithSyncUsingMonitor);
            thread1.Start();

            Thread thread2 = new Thread(IncrementCounterWithSyncUsingMonitor);
            thread2.Start();

            thread1.Join();// Why we are using Join here? To make sure Main thread waits for this thread to complete before moving forward.
            thread2.Join();

            Console.WriteLine($"Final Counter Value after sync using monitor: {counter2}");
        }

        
        private void BookingMonitorUsingMonitor()
        {
            while (true)
            {
                if (bookingQueue.Count > 0)
                {
                    var bookingRequest = bookingQueue.Dequeue();
                    new Thread(() => ProcessBookingUsingMonitor(bookingRequest)).Start();
                }
                Thread.Sleep(100);
            }
        }
        private void BookingMonitorUsingLock()
        {
            while (true)
            {
                if(bookingQueue.Count > 0)
                {
                    var bookingRequest = bookingQueue.Dequeue();
                    new Thread(()=>ProcessBookingUsingLock(bookingRequest)).Start();
                }
                Thread.Sleep(100);
            }
        }
        private void ProcessBookingUsingLock(string bookingRequest)
        {
            Thread.Sleep(100); // Simulate some processing time
            lock (bookingObject)
            {
                if (bookingRequest == "b")
                {
                    if (availableSeats > 0)
                    {
                        availableSeats--;
                        Console.WriteLine($"Booking Successful. Seats left: {availableSeats}");
                    }
                    else
                    {
                        Console.WriteLine("Booking Failed. No seats available.");
                    }
                }
                else if (bookingRequest == "c")
                {
                    if (availableSeats < 10)
                    {
                        availableSeats++;
                        Console.WriteLine($"Cancellation Successful. Seats left: {availableSeats}");
                    }
                    else
                    {
                        Console.WriteLine($"Can not cancel any ticket");
                    }

                }
            }

        }
        private void ProcessBookingUsingMonitor(string bookingRequest)
        {
            
            if(Monitor.TryEnter(bookingObject, 10)){
                try
                {
                    Thread.Sleep(100); // Simulate some processing time
                    if (bookingRequest == "b")
                    {
                        if (availableSeats > 0)
                        {
                            availableSeats--;
                            Console.WriteLine($"Booking Successful. Seats left: {availableSeats}");
                        }
                        else
                        {
                            Console.WriteLine("Booking Failed. No seats available.");
                        }
                    }
                    else if (bookingRequest == "c")
                    {
                        if (availableSeats < 10)
                        {
                            availableSeats++;
                            Console.WriteLine($"Cancellation Successful. Seats left: {availableSeats}");
                        }
                        else
                        {
                            Console.WriteLine($"Can not cancel any ticket");
                        }

                    }
                }
                finally
                {
                    Monitor.Exit(bookingObject);
                }
            }
            else
            {
               Console.WriteLine("Could not acquire the lock within the specified timeout.");

            }

        }

        private void SimpleCounterIncrementTask()
        {
            SimpleCounterIncrementTaskWithOutSynchronization();
            SimpleCounterIncrementTaskWithSynchronization();
        }

        private void SimpleCounterIncrementTaskWithSynchronization()
        {
            Thread thread1 = new Thread(IncrementCounterWithSync);
            thread1.Start();

            Thread thread2 = new Thread(IncrementCounterWithSync);
            thread2.Start();

            thread1.Join();// Why we are using Join here? To make sure Main thread waits for this thread to complete before moving forward.
            thread2.Join();

            Console.WriteLine($"Final Counter Value after sync: {counter2}");
        }

        private void IncrementCounterWithSync()
        {
            for (int i = 0; i < 100000; i++)
            {
                // Locking the critical section to ensure only one thread can access it at a time 
                // lock has built in try -finally to release the lock. so if exception occurs it will release the lock.
                lock (counterObject)
                {
                    counter2 = counter2 + 1;
                }
            }
        }

        private void IncrementCounterWithSyncUsingMonitor()
        {
            for (int i = 0; i < 100000; i++)
            {
                // Using Monitor to lock the critical section
                // Monitor requires explicit try-finally to release the lock.
                if (Monitor.TryEnter(monitorObject, 2000))
                {
                    try
                    {
                        counter2 = counter2 + 1;
                    }
                    finally
                    {
                        Monitor.Exit(monitorObject);
                    }
                }
                else
                {
                    Console.WriteLine("Could not acquire the lock within the specified timeout.");

                }

            }
        }

        private void SimpleCounterIncrementTaskWithOutSynchronization()
        {
            Thread thread1 = new Thread(IncrementCounter);
            thread1.Start();

            Thread thread2 = new Thread(IncrementCounter);
            thread2.Start();

            thread1.Join();// Why we are using Join here? To make sure Main thread waits for this thread to complete before moving forward.
            thread2.Join();

            Console.WriteLine($"Final Counter Value: {counter1}");
        }

        private void IncrementCounter()
        {
            for(int i=0; i<100000; i++)
            {
                counter1 = counter1 + 1;
            }
        }   
    }
}
