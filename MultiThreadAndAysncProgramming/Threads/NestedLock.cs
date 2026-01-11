

namespace MultiThreadAndAysncProgramming.Threads
{
    public class NestedLock
    {
        private readonly object userLock = new object();
        private readonly object orderLock = new object();
        public void Execute()
        {
            Thread thread = new Thread(ManageUser);
            ManageOrder();
            thread.Start();
            thread.Join();

            Console.ReadLine();

        }

        void ManageUser()
        {
            lock(userLock)
            {
                Console.WriteLine("User management accquired the user lock.");
                Thread.Sleep(2000); // Simulate some work with the user lock

                lock(orderLock)
                {
                    Console.WriteLine("User management accquired the order lock.");
                    
                }
            }
        
        }

        void ManageOrder()
        {
            lock (orderLock)
            {
                Console.WriteLine("Order management accquired the order lock.");
                Thread.Sleep(1000); // Simulate some work with the user lock

                lock (userLock)
                {
                    Console.WriteLine("Order management accquired the user lock.");
                   
                }
            }

        }
    }
}
