using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreadAndAysncProgramming.Tasks
{
    public class TaskExceptionHandling
    {
        public void Execute()
        {
            try
            {
                Task task = Task.Run(() =>
                {
                    // Simulate some work
                    Task.Delay(1000).Wait();
                    throw new InvalidOperationException("An error occurred in the task.");
                });
                task.Wait(); // This will re-throw the exception if the task failed
            }
            catch (AggregateException aggEx)
            {
                foreach (var ex in aggEx.InnerExceptions)
                {
                    Console.WriteLine($"Caught exception: {ex.Message}");
                }
            }
        }
    }
}
